﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using KissU.Core.CPlatform.Convertibles;
using KissU.Core.CPlatform.Ids;
using KissU.Core.ProxyGenerator.Utilitys;
using KissU.Core.CPlatform.Runtime.Client;
using KissU.Core.CPlatform.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#if !NET

using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;

#endif

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using KissU.Core.CPlatform;

namespace KissU.Core.ProxyGenerator.Implementation
{
    public class ServiceProxyGenerater : IServiceProxyGenerater,IDisposable
    {
        #region Field

        private readonly IServiceIdGenerator _serviceIdGenerator;
        private readonly ILogger<ServiceProxyGenerater> _logger;
        #endregion Field

        #region Constructor

        public ServiceProxyGenerater(IServiceIdGenerator serviceIdGenerator, ILogger<ServiceProxyGenerater> logger)
        {
            _serviceIdGenerator = serviceIdGenerator;
            _logger = logger;
        }

        #endregion Constructor

        #region Implementation of IServiceProxyGenerater

        /// <summary>
        /// 生成服务代理。
        /// </summary>
        /// <param name="interfacTypes">需要被代理的接口类型。</param>
        /// <returns>服务代理实现。</returns>
        public IEnumerable<Type> GenerateProxys(IEnumerable<Type> interfacTypes, IEnumerable<string> namespaces)
        {
#if NET
            var assemblys = AppDomain.CurrentDomain.GetAssemblies();
#else
            var assemblys = DependencyContext.Default.RuntimeLibraries.SelectMany(i => i.GetDefaultAssemblyNames(DependencyContext.Default).Select(z => Assembly.Load(new AssemblyName(z.Name))));
#endif
            assemblys = assemblys.Where(i => i.IsDynamic == false).ToArray();
            var types = assemblys.Select(p => p.GetType());
            types = interfacTypes.Except(types);
            foreach (var t in types)
            {
                assemblys = assemblys.Append(t.Assembly);
            }
            var trees = interfacTypes.Select(p=>GenerateProxyTree(p,namespaces)).ToList();
            var stream = CompilationUtilitys.CompileClientProxy(trees,
                assemblys
                    .Select(a => MetadataReference.CreateFromFile(a.Location))
                    .Concat(new[]
                    {
                        MetadataReference.CreateFromFile(typeof(Task).GetTypeInfo().Assembly.Location)
                    }),
                _logger);

            using (stream)
            {
#if NET
                var assembly = Assembly.Load(stream.ToArray());
#else
                var assembly = AssemblyLoadContext.Default.LoadFromStream(stream);
#endif
               return assembly.GetExportedTypes();
            }
        }

        /// <summary>
        /// 生成服务代理代码树。
        /// </summary>
        /// <param name="interfaceType">需要被代理的接口类型。</param>
        /// <returns>代码树。</returns>
        public SyntaxTree GenerateProxyTree(Type interfaceType, IEnumerable<string> namespaces)
        {
            var className = interfaceType.Name.StartsWith("I") ? interfaceType.Name.Substring(1) : interfaceType.Name;
            className += "ClientProxy";

            var members = new List<MemberDeclarationSyntax>
            {
                GetConstructorDeclaration(className)
            };

            members.AddRange(GenerateMethodDeclarations(interfaceType.GetMethods()));
            return SyntaxFactory.CompilationUnit()
                .WithUsings(GetUsings(namespaces))
                .WithMembers(
                    SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                        SyntaxFactory.NamespaceDeclaration(
                            SyntaxFactory.QualifiedName(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.IdentifierName("KissU"),
                                    SyntaxFactory.IdentifierName("Cores")),
                                SyntaxFactory.IdentifierName("ClientProxys")))
                .WithMembers(
                    SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                        SyntaxFactory.ClassDeclaration(className)
                            .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                            .WithBaseList(
                                SyntaxFactory.BaseList(
                                    SyntaxFactory.SeparatedList<BaseTypeSyntax>(
                                        new SyntaxNodeOrToken[]
                                        {
                                            SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName("ServiceProxyBase")),
                                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                                            SyntaxFactory.SimpleBaseType(GetQualifiedNameSyntax(interfaceType))
                                        })))
                            .WithMembers(SyntaxFactory.List(members))))))
                .NormalizeWhitespace().SyntaxTree;
        }

        #endregion Implementation of IServiceProxyGenerater

        #region Private Method

        private static QualifiedNameSyntax GetQualifiedNameSyntax(Type type)
        {
            var fullName = type.Namespace + "." + type.Name;
            return GetQualifiedNameSyntax(fullName);
        }

        private static QualifiedNameSyntax GetQualifiedNameSyntax(string fullName)
        {
            return GetQualifiedNameSyntax(fullName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries));
        }

        private static QualifiedNameSyntax GetQualifiedNameSyntax(IReadOnlyCollection<string> names)
        {
            var ids = names.Select(SyntaxFactory.IdentifierName).ToArray();

            var index = 0;
            QualifiedNameSyntax left = null;
            while (index + 1 < names.Count)
            {
                left = left == null ? SyntaxFactory.QualifiedName(ids[index], ids[index + 1]) : SyntaxFactory.QualifiedName(left, ids[index + 1]);
                index++;
            }
            return left;
        }

        private static SyntaxList<UsingDirectiveSyntax> GetUsings(IEnumerable<string> namespaces)
        {
            var directives = new List<UsingDirectiveSyntax>();
           foreach(var name in namespaces)
            {
                directives.Add(SyntaxFactory.UsingDirective(GetQualifiedNameSyntax(name)));
            }
            return SyntaxFactory.List(
                new[]
                {
                    SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System")),
                    SyntaxFactory.UsingDirective(GetQualifiedNameSyntax("System.Threading.Tasks")),
                    SyntaxFactory.UsingDirective(GetQualifiedNameSyntax("System.Collections.Generic")),
                    SyntaxFactory.UsingDirective(GetQualifiedNameSyntax(typeof(ITypeConvertibleService).Namespace)),
                    SyntaxFactory.UsingDirective(GetQualifiedNameSyntax(typeof(IRemoteInvokeService).Namespace)),
                    SyntaxFactory.UsingDirective(GetQualifiedNameSyntax(typeof(CPlatformContainer).Namespace)),
                    SyntaxFactory.UsingDirective(GetQualifiedNameSyntax(typeof(ISerializer<>).Namespace)),
                    SyntaxFactory.UsingDirective(GetQualifiedNameSyntax(typeof(ServiceProxyBase).Namespace))
                }.Concat(directives));
        }

        private static ConstructorDeclarationSyntax GetConstructorDeclaration(string className)
        {
            return SyntaxFactory.ConstructorDeclaration(SyntaxFactory.Identifier(className))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("remoteInvokeService"))
                                    .WithType(
                                        SyntaxFactory.IdentifierName("IRemoteInvokeService")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("typeConvertibleService"))
                                    .WithType(
                                        SyntaxFactory.IdentifierName("ITypeConvertibleService")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("serviceKey"))
                                    .WithType(
                                        SyntaxFactory.IdentifierName("String")),
                                 SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("serviceProvider"))
                                    .WithType(
                                        SyntaxFactory.IdentifierName("CPlatformContainer"))
                            })))
                .WithInitializer(
                        SyntaxFactory.ConstructorInitializer(
                            SyntaxKind.BaseConstructorInitializer,
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                    new SyntaxNodeOrToken[]{
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.IdentifierName("remoteInvokeService")),
                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.IdentifierName("typeConvertibleService")),
                                          SyntaxFactory.Token(SyntaxKind.CommaToken),
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.IdentifierName("serviceKey")),
                                           SyntaxFactory.Token(SyntaxKind.CommaToken),
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.IdentifierName("serviceProvider"))
                                    }))))
                .WithBody(SyntaxFactory.Block());
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateMethodDeclarations(IEnumerable<MethodInfo> methods)
        {
            var array = methods.ToArray();
            return array.Select(p=>GenerateMethodDeclaration(p)).ToArray();
        }

        private static TypeSyntax GetTypeSyntax(Type type)
        {
            //没有返回值。
            if (type == null)
                return null;

            //非泛型。
            if (!type.GetTypeInfo().IsGenericType)
                return GetQualifiedNameSyntax(type.FullName);

            var list = new List<SyntaxNodeOrToken>();

            foreach (var genericTypeArgument in type.GenericTypeArguments)
            {
                list.Add(genericTypeArgument.GetTypeInfo().IsGenericType
                    ? GetTypeSyntax(genericTypeArgument)
                    : GetQualifiedNameSyntax(genericTypeArgument.FullName));
                list.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            var array = list.Take(list.Count - 1).ToArray();
            var typeArgumentListSyntax = SyntaxFactory.TypeArgumentList(SyntaxFactory.SeparatedList<TypeSyntax>(array));
            return SyntaxFactory.GenericName(type.Name.Substring(0, type.Name.IndexOf('`')))
                .WithTypeArgumentList(typeArgumentListSyntax);
        }

        private MemberDeclarationSyntax GenerateMethodDeclaration(MethodInfo method)
        {
            var serviceId = _serviceIdGenerator.GenerateServiceId(method);
            var returnDeclaration = GetTypeSyntax(method.ReturnType);

            var parameterList = new List<SyntaxNodeOrToken>();
            var parameterDeclarationList = new List<SyntaxNodeOrToken>();

            foreach (var parameter in method.GetParameters())
            {
                if (parameter.ParameterType.IsGenericType)
                {
                    parameterDeclarationList.Add(SyntaxFactory.Parameter(
                                     SyntaxFactory.Identifier(parameter.Name))
                                     .WithType(GetTypeSyntax(parameter.ParameterType)));
                }
                else
                {
                    parameterDeclarationList.Add(SyntaxFactory.Parameter(
                                        SyntaxFactory.Identifier(parameter.Name))
                                        .WithType(GetQualifiedNameSyntax(parameter.ParameterType)));

                }
                parameterDeclarationList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
               
                parameterList.Add(SyntaxFactory.InitializerExpression(
                    SyntaxKind.ComplexElementInitializerExpression,
                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                        new SyntaxNodeOrToken[]{
                            SyntaxFactory.LiteralExpression(
                                SyntaxKind.StringLiteralExpression,
                                SyntaxFactory.Literal(parameter.Name)),
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                            SyntaxFactory.IdentifierName(parameter.Name)})));
                parameterList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }
            if (parameterList.Any())
            {
                parameterList.RemoveAt(parameterList.Count - 1);
                parameterDeclarationList.RemoveAt(parameterDeclarationList.Count - 1);
            }

            var declaration = SyntaxFactory.MethodDeclaration(
                returnDeclaration,
                SyntaxFactory.Identifier(method.Name))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword)))
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(parameterDeclarationList)));

            ExpressionSyntax expressionSyntax;
            StatementSyntax statementSyntax;

            if (method.ReturnType != typeof(Task))
            {
                expressionSyntax = SyntaxFactory.GenericName(
                SyntaxFactory.Identifier("Invoke")).WithTypeArgumentList(((GenericNameSyntax)returnDeclaration).TypeArgumentList);

            }
            else
            {
                expressionSyntax = SyntaxFactory.IdentifierName("Invoke");
            }
            expressionSyntax = SyntaxFactory.AwaitExpression(
                SyntaxFactory.InvocationExpression(expressionSyntax)
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                new SyntaxNodeOrToken[]
                                {
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.ObjectCreationExpression(
                                                SyntaxFactory.GenericName(
                                                    SyntaxFactory.Identifier("Dictionary"))
                                                    .WithTypeArgumentList(
                                                        SyntaxFactory.TypeArgumentList(
                                                            SyntaxFactory.SeparatedList<TypeSyntax>(
                                                                new SyntaxNodeOrToken[]
                                                                {
                                                                    SyntaxFactory.PredefinedType(
                                                                        SyntaxFactory.Token(SyntaxKind.StringKeyword)),
                                                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                                    SyntaxFactory.PredefinedType(
                                                                        SyntaxFactory.Token(SyntaxKind.ObjectKeyword))
                                                                }))))
                                                .WithInitializer(
                                                    SyntaxFactory.InitializerExpression(
                                                        SyntaxKind.CollectionInitializerExpression,
                                                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                                            parameterList)))),
                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.LiteralExpression(
                                                SyntaxKind.StringLiteralExpression,
                                                Literal(serviceId)))
                                }))));

            if (method.ReturnType != typeof(Task))
            {
                statementSyntax = SyntaxFactory.ReturnStatement(expressionSyntax);
            }
            else
            {
                statementSyntax = SyntaxFactory.ExpressionStatement(expressionSyntax);
            }

            declaration = declaration.WithBody(
                        SyntaxFactory.Block(
                            SyntaxFactory.SingletonList(statementSyntax)));

            return declaration;
        }

        public void Dispose()
        { 
            GC.SuppressFinalize(this);
        }

        #endregion Private Method
    }
}
