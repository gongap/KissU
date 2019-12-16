﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using KissU.Core.CPlatform.Runtime.Client;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.Extensions.DependencyInjection;

#if !NET

using Microsoft.Extensions.DependencyModel;

#endif

namespace KissU.Core.ProxyGenerator.Utilitys
{
    public static class CompilationUtilitys
    {
        #region Public Method

        public static MemoryStream CompileClientProxy(IEnumerable<SyntaxTree> trees, IEnumerable<MetadataReference> references, ILogger logger = null)
        {
#if !NET
            var assemblys = new[]
            {
                "System.Runtime",
                "mscorlib",
                "System.Threading.Tasks",
                 "System.Collections"
            };
            references = assemblys.Select(i => MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName(i)).Location)).Concat(references);
#endif
            references = new[]
            {
                MetadataReference.CreateFromFile(typeof(Task).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ServiceDescriptor).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IRemoteInvokeService).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IServiceProxyGenerater).GetTypeInfo().Assembly.Location)
            }.Concat(references);
            return Compile(AssemblyInfo.Create("KissU.Cores.ClientProxys"), trees, references, logger);
        }

        public static MemoryStream Compile(AssemblyInfo assemblyInfo, IEnumerable<SyntaxTree> trees, IEnumerable<MetadataReference> references, ILogger logger = null)
        {
            return Compile(assemblyInfo.Title, assemblyInfo, trees, references, logger);
        }

        public static MemoryStream Compile(string assemblyName, AssemblyInfo assemblyInfo, IEnumerable<SyntaxTree> trees, IEnumerable<MetadataReference> references, ILogger logger = null)
        {
            trees = trees.Concat(new[] { GetAssemblyInfo(assemblyInfo) });
            var compilation = CSharpCompilation.Create(assemblyName, trees, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            var stream = new MemoryStream();
            var result = compilation.Emit(stream);
            if (!result.Success && logger != null)
            {
                foreach (var message in result.Diagnostics.Select(i => i.ToString()))
                {
                    logger.LogError(message);
                }
                return null;
            }
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        #endregion Public Method

        #region Private Method

        private static SyntaxTree GetAssemblyInfo(AssemblyInfo info)
        {
            return SyntaxFactory.CompilationUnit()
                .WithUsings(
                    SyntaxFactory.List(
                        new[]
                        {
                            SyntaxFactory.UsingDirective(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.IdentifierName("System"),
                                    SyntaxFactory.IdentifierName("Reflection"))),
                            SyntaxFactory.UsingDirective(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.QualifiedName(
                                        SyntaxFactory.IdentifierName("System"),
                                        SyntaxFactory.IdentifierName("Runtime")),
                                    SyntaxFactory.IdentifierName("InteropServices"))),
                            SyntaxFactory.UsingDirective(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.QualifiedName(
                                        SyntaxFactory.IdentifierName("System"),
                                        SyntaxFactory.IdentifierName("Runtime")),
                                    SyntaxFactory.IdentifierName("Versioning")))
                        }))
                .WithAttributeLists(
                    SyntaxFactory.List(
                        new[]
                        {
                            SyntaxFactory.AttributeList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxFactory.Attribute(
                    SyntaxFactory.IdentifierName("TargetFramework"))
                .WithArgumentList(
                    SyntaxFactory.AttributeArgumentList(
                        SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxFactory.AttributeArgument(
                                    SyntaxFactory.LiteralExpression(
                                        SyntaxKind.StringLiteralExpression,
                                        SyntaxFactory.Literal(".NETFramework,Version=v4.5"))),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.AttributeArgument(
                                    SyntaxFactory.LiteralExpression(
                                        SyntaxKind.StringLiteralExpression,
                                        SyntaxFactory.Literal(".NET Framework 4.5")))
                                .WithNameEquals(
                                    SyntaxFactory.NameEquals(
                                        SyntaxFactory.IdentifierName("FrameworkDisplayName")))
                            })))))
        .WithTarget(
            SyntaxFactory.AttributeTargetSpecifier(
                SyntaxFactory.Token(SyntaxKind.AssemblyKeyword))),
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("AssemblyTitle"))
                                        .WithArgumentList(
                                            SyntaxFactory.AttributeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            Literal(info.Title))))))))
                                .WithTarget(
                                    SyntaxFactory.AttributeTargetSpecifier(
                                        SyntaxFactory.Token(SyntaxKind.AssemblyKeyword))),
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("AssemblyProduct"))
                                        .WithArgumentList(
                                            SyntaxFactory.AttributeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            Literal(info.Product))))))))
                                .WithTarget(
                                    SyntaxFactory.AttributeTargetSpecifier(
                                        SyntaxFactory.Token(SyntaxKind.AssemblyKeyword))),
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("AssemblyCopyright"))
                                        .WithArgumentList(
                                            SyntaxFactory.AttributeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            Literal(info.Copyright))))))))
                                .WithTarget(
                                    SyntaxFactory.AttributeTargetSpecifier(
                                        SyntaxFactory.Token(SyntaxKind.AssemblyKeyword))),
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("ComVisible"))
                                        .WithArgumentList(
                                            SyntaxFactory.AttributeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(info.ComVisible
                                                            ? SyntaxKind.TrueLiteralExpression
                                                            : SyntaxKind.FalseLiteralExpression)))))))
                                .WithTarget(
                                    SyntaxFactory.AttributeTargetSpecifier(
                                        SyntaxFactory.Token(SyntaxKind.AssemblyKeyword))),
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("Guid"))
                                        .WithArgumentList(
                                            SyntaxFactory.AttributeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            Literal(info.Guid))))))))
                                .WithTarget(
                                    SyntaxFactory.AttributeTargetSpecifier(
                                        SyntaxFactory.Token(SyntaxKind.AssemblyKeyword))),
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("AssemblyVersion"))
                                        .WithArgumentList(
                                            SyntaxFactory.AttributeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            Literal(info.Version))))))))
                                .WithTarget(
                                    SyntaxFactory.AttributeTargetSpecifier(
                                        SyntaxFactory.Token(SyntaxKind.AssemblyKeyword))),
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("AssemblyFileVersion"))
                                        .WithArgumentList(
                                            SyntaxFactory.AttributeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            Literal(info.FileVersion))))))))
                                .WithTarget(
                                    SyntaxFactory.AttributeTargetSpecifier(
                                        SyntaxFactory.Token(SyntaxKind.AssemblyKeyword)))
                        }))
                .NormalizeWhitespace()
                .SyntaxTree;
        }

        #endregion Private Method

        #region Help Class

        public class AssemblyInfo
        {
            public string Title { get; set; }
            public string Product { get; set; }
            public string Copyright { get; set; }
            public string Guid { get; set; }
            public string Version { get; set; }
            public string FileVersion { get; set; }
            public bool ComVisible { get; set; }

            public static AssemblyInfo Create(string name, string copyright = "Copyright ©  KissU", string version = "0.0.0.1")
            {
                return new AssemblyInfo
                {
                    Title = name,
                    Product = name,
                    Copyright = copyright,
                    Guid = System.Guid.NewGuid().ToString("D"),
                    ComVisible = false,
                    Version = version,
                    FileVersion = version
                };
            }
        }

        #endregion Help Class
    }
}
