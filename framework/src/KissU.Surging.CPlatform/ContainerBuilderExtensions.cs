using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Autofac;
using KissU.Core;
using KissU.Core.Convertibles;
using KissU.Core.Convertibles.Implementation;
using KissU.Core.Dependency;
using KissU.Core.EventBus.Events;
using KissU.Core.Helpers.Utilities;
using KissU.Core.Module;
using KissU.Core.Serialization;
using KissU.Core.Serialization.Implementation;
using KissU.Core.Validation;
using KissU.Core.Validation.Implementation;
using KissU.Surging.CPlatform.Cache;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.CPlatform.Configurations.Watch;
using KissU.Surging.CPlatform.Engines;
using KissU.Surging.CPlatform.Engines.Implementation;
using KissU.Surging.CPlatform.Filters;
using KissU.Surging.CPlatform.Filters.Implementation;
using KissU.Surging.CPlatform.HashAlgorithms;
using KissU.Surging.CPlatform.Ids;
using KissU.Surging.CPlatform.Ids.Implementation;
using KissU.Surging.CPlatform.Mqtt;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.CPlatform.Routing.Implementation;
using KissU.Surging.CPlatform.Runtime.Client;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Surging.CPlatform.Runtime.Client.HealthChecks;
using KissU.Surging.CPlatform.Runtime.Client.HealthChecks.Implementation;
using KissU.Surging.CPlatform.Runtime.Client.Implementation;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Runtime.Server.Implementation;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Implementation;
using KissU.Surging.CPlatform.Support;
using KissU.Surging.CPlatform.Support.Implementation;
using KissU.Surging.CPlatform.Transport.Codec;
using KissU.Surging.CPlatform.Transport.Codec.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.CPlatform
{
    /// <summary>
    /// 容器构建器扩展.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        private static readonly List<Assembly> _referenceAssembly = new List<Assembly>();
        private static readonly List<AbstractModule> _modules = new List<AbstractModule>();

        /// <summary>
        /// 添加Json序列化支持
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddJsonSerialization(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType(typeof(JsonSerializer)).As(typeof(ISerializer<string>)).SingleInstance();
            services.RegisterType(typeof(StringByteArraySerializer)).As(typeof(ISerializer<byte[]>)).SingleInstance();
            services.RegisterType(typeof(StringObjectSerializer)).As(typeof(ISerializer<object>)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 设置共享文件路由管理者
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="filePath">文件路径</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseSharedFileRouteManager(this IServiceBuilder builder, string filePath)
        {
            return builder.UseRouteManager(provider =>
                new SharedFileServiceRouteManager(
                    filePath,
                    provider.GetRequiredService<ISerializer<string>>(),
                    provider.GetRequiredService<IServiceRouteFactory>(),
                    provider.GetRequiredService<ILogger<SharedFileServiceRouteManager>>()));
        }

        /// <summary>
        /// Uses the shared file route manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseSharedFileRouteManager(this IServiceBuilder builder, string ip, string port)
        {
            return builder.UseRouteManager(provider =>
                new SharedFileServiceRouteManager(
                    ip,
                    provider.GetRequiredService<ISerializer<string>>(),
                    provider.GetRequiredService<IServiceRouteFactory>(),
                    provider.GetRequiredService<ILogger<SharedFileServiceRouteManager>>()));
        }

        #region Configuration Watch

        /// <summary>
        /// Configuration Watch
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddConfigurationWatch(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType(typeof(ConfigurationWatchManager)).As(typeof(IConfigurationWatchManager))
                .SingleInstance();
            return builder;
        }

        #endregion

        /// <summary>
        /// 使用Json编解码器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseJsonCodec(this IServiceBuilder builder)
        {
            return builder.UseCodec<JsonTransportMessageCodecFactory>();
        }

        /// <summary>
        /// 添加客户端运行时服务
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddClientRuntime(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType(typeof(DefaultHealthCheckService)).As(typeof(IHealthCheckService)).SingleInstance();
            services.RegisterType(typeof(DefaultAddressResolver)).As(typeof(IAddressResolver)).SingleInstance();
            services.RegisterType(typeof(RemoteInvokeService)).As(typeof(IRemoteInvokeService)).SingleInstance();
            return builder.UseAddressSelector().AddRuntime().AddClusterSupport();
        }

        /// <summary>
        /// 添加集群支持
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddClusterSupport(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType(typeof(ServiceCommandProvider)).As(typeof(IServiceCommandProvider)).SingleInstance();
            services.RegisterType(typeof(BreakeRemoteInvokeService)).As(typeof(IBreakeRemoteInvokeService))
                .SingleInstance();
            services.RegisterType(typeof(FailoverInjectionInvoker)).AsImplementedInterfaces()
                .Named(StrategyType.Injection.ToString(), typeof(IClusterInvoker)).SingleInstance();
            services.RegisterType(typeof(FailoverHandoverInvoker)).AsImplementedInterfaces()
                .Named(StrategyType.Failover.ToString(), typeof(IClusterInvoker)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 添加过滤器.
        /// </summary>
        /// <param name="builder">服务构建器.</param>
        /// <param name="filter">过滤器.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder AddFilter(this IServiceBuilder builder, IFilter filter)
        {
            var services = builder.Services;
            services.Register(p => filter).As(typeof(IFilter)).SingleInstance();
            switch (filter)
            {
                case IExceptionFilter exceptionFilter:
                    services.Register(p => exceptionFilter).As(typeof(IExceptionFilter)).SingleInstance();
                    break;
                case IAuthorizationFilter authorizationFilter:
                    services.Register(p => authorizationFilter).As(typeof(IAuthorizationFilter)).SingleInstance();
                    break;
            }

            return builder;
        }

        /// <summary>
        /// 添加服务引擎.
        /// </summary>
        /// <param name="builder">服务构建器.</param>
        /// <param name="engine">引擎类型</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder AddServiceEngine(this IServiceBuilder builder, Type engine)
        {
            var services = builder.Services;
            services.RegisterType(engine).As(typeof(IServiceEngine)).SingleInstance();
            builder.Services.RegisterType(typeof(DefaultServiceEngineBuilder)).As(typeof(IServiceEngineBuilder))
                .SingleInstance();
            return builder;
        }

        /// <summary>
        /// 添加服务运行时服务
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddServiceRuntime(this IServiceBuilder builder)
        {
            builder.Services.RegisterType(typeof(DefaultServiceEntryLocate)).As(typeof(IServiceEntryLocate))
                .SingleInstance();
            builder.Services.RegisterType(typeof(DefaultServiceExecutor)).As(typeof(IServiceExecutor))
                .Named<IServiceExecutor>(CommunicationProtocol.Tcp.ToString()).SingleInstance();

            return builder.RegisterServices().RegisterRepositories().RegisterServiceBus().RegisterModules()
                .RegisterInstanceByConstraint().AddRuntime();
        }

        /// <summary>
        /// 添加关联服务运行时
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddRelateServiceRuntime(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType(typeof(DefaultHealthCheckService)).As(typeof(IHealthCheckService)).SingleInstance();
            services.RegisterType(typeof(DefaultAddressResolver)).As(typeof(IAddressResolver)).SingleInstance();
            services.RegisterType(typeof(RemoteInvokeService)).As(typeof(IRemoteInvokeService)).SingleInstance();
            return builder.UseAddressSelector().AddClusterSupport();
        }

        /// <summary>
        /// 添加核心服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddCoreService(this ContainerBuilder services)
        {
            Check.NotNull(services, "services");
            // 注册服务ID生成实例
            services.RegisterType<DefaultServiceIdGenerator>().As<IServiceIdGenerator>().SingleInstance();
            services.Register(p => new CPlatformContainer(p));
            // 注册默认的类型转换
            services.RegisterType(typeof(DefaultTypeConvertibleProvider)).As(typeof(ITypeConvertibleProvider))
                .SingleInstance();
            // 注册默认的类型转换服务
            services.RegisterType(typeof(DefaultTypeConvertibleService)).As(typeof(ITypeConvertibleService))
                .SingleInstance();
            // 注册权限过滤
            services.RegisterType(typeof(AuthorizationAttribute)).As(typeof(IAuthorizationFilter)).SingleInstance();
            // 注册基本过滤
            services.RegisterType(typeof(AuthorizationAttribute)).As(typeof(IFilter)).SingleInstance();
            // 注册默认校验处理器
            services.RegisterType(typeof(DefaultValidationProcessor)).As(typeof(IValidationProcessor)).SingleInstance();
            // 注册服务器路由接口
            services.RegisterType(typeof(DefaultServiceRouteProvider)).As(typeof(IServiceRouteProvider))
                .SingleInstance();
            // 注册服务路由工厂
            services.RegisterType(typeof(DefaultServiceRouteFactory)).As(typeof(IServiceRouteFactory)).SingleInstance();
            // 注册服务订阅工厂
            services.RegisterType(typeof(DefaultServiceSubscriberFactory)).As(typeof(IServiceSubscriberFactory))
                .SingleInstance();
            // 注册服务token生成接口
            services.RegisterType(typeof(ServiceTokenGenerator)).As(typeof(IServiceTokenGenerator)).SingleInstance();
            // 注册哈希一致性算法
            services.RegisterType(typeof(HashAlgorithm)).As(typeof(IHashAlgorithm)).SingleInstance();
            // 注册组件生命周期接口
            services.RegisterType(typeof(ServiceEngineLifetime)).As(typeof(IServiceEngineLifetime)).SingleInstance();
            // 注册服务心跳管理
            services.RegisterType(typeof(DefaultServiceHeartbeatManager)).As(typeof(IServiceHeartbeatManager))
                .SingleInstance();
            return new ServiceBuilder(services)
                .AddJsonSerialization()
                .UseJsonCodec();
        }

        /// <summary>
        /// 通过约束注册实例.
        /// </summary>
        /// <param name="builder">服务构建器.</param>
        /// <param name="virtualPaths">虚拟路径.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder RegisterInstanceByConstraint(this IServiceBuilder builder,
            params string[] virtualPaths)
        {
            var services = builder.Services;
            var referenceAssemblies = GetReferenceAssembly(virtualPaths);

            foreach (var assembly in referenceAssemblies)
            {
                services.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(ISingletonDependency).GetTypeInfo().IsAssignableFrom(t))
                    .AsImplementedInterfaces().AsSelf().SingleInstance();

                services.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(ITransientDependency).GetTypeInfo().IsAssignableFrom(t))
                    .AsImplementedInterfaces().AsSelf().InstancePerDependency();
            }

            return builder;
        }

        /// <summary>
        /// 添加运行时.
        /// </summary>
        /// <param name="builder">服务构建器.</param>
        /// <returns>IServiceBuilder.</returns>
        private static IServiceBuilder AddRuntime(this IServiceBuilder builder)
        {
            var services = builder.Services;

            services.RegisterType(typeof(ClrServiceEntryFactory)).As(typeof(IClrServiceEntryFactory)).SingleInstance();

            services.Register(provider =>
            {
                try
                {
                    var assemblys = GetReferenceAssembly();
                    var types = assemblys.SelectMany(i => i.ExportedTypes).ToArray();
                    return new AttributeServiceEntryProvider(types, provider.Resolve<IClrServiceEntryFactory>(),
                        provider.Resolve<ILogger<AttributeServiceEntryProvider>>(),
                        provider.Resolve<CPlatformContainer>());
                }
                finally
                {
                    builder = null;
                }
            }).As<IServiceEntryProvider>();
            builder.Services.RegisterType(typeof(DefaultServiceEntryManager)).As(typeof(IServiceEntryManager))
                .SingleInstance();
            return builder;
        }

        /// <summary>
        /// 添加微服务
        /// </summary>
        /// <param name="builder">服务构建器.</param>
        /// <param name="option">选项.</param>
        public static void AddMicroService(this ContainerBuilder builder, Action<IServiceBuilder> option)
        {
            option.Invoke(builder.AddCoreService());
        }

        /// <summary>
        /// 依赖注入业务模块程序集
        /// </summary>
        /// <param name="builder">ioc容器</param>
        /// <param name="virtualPaths">虚拟路径.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder RegisterServices(this IServiceBuilder builder, params string[] virtualPaths)
        {
            try
            {
                var services = builder.Services;
                var referenceAssemblies = GetAssemblies(virtualPaths);
                foreach (var assembly in referenceAssemblies)
                {
                    services.RegisterAssemblyTypes(assembly)
                        // 注入继承IServiceKey接口的所有接口
                        .Where(t => typeof(IServiceKey).GetTypeInfo().IsAssignableFrom(t) && t.IsInterface)
                        .AsImplementedInterfaces();
                    services.RegisterAssemblyTypes(assembly)
                        // 注入实现IServiceBehavior接口并ModuleName为空的类，作为接口实现类
                        .Where(t => !typeof(ISingleInstance).GetTypeInfo().IsAssignableFrom(t) &&
                                    typeof(IServiceBehavior).GetTypeInfo().IsAssignableFrom(t) &&
                                    t.GetTypeInfo().GetCustomAttribute<ModuleNameAttribute>() == null)
                        .AsImplementedInterfaces();

                    services.RegisterAssemblyTypes(assembly)
                        // 注入实现IServiceBehavior接口并ModuleName为空的类，作为接口实现类
                        .Where(t => typeof(ISingleInstance).GetTypeInfo().IsAssignableFrom(t) &&
                                    typeof(IServiceBehavior).GetTypeInfo().IsAssignableFrom(t) &&
                                    t.GetTypeInfo().GetCustomAttribute<ModuleNameAttribute>() == null).SingleInstance()
                        .AsImplementedInterfaces();

                    var types = assembly.GetTypes().Where(t =>
                        typeof(IServiceBehavior).GetTypeInfo().IsAssignableFrom(t) &&
                        t.GetTypeInfo().GetCustomAttribute<ModuleNameAttribute>() != null);
                    foreach (var type in types)
                    {
                        var module = type.GetTypeInfo().GetCustomAttribute<ModuleNameAttribute>();
                        // 对ModuleName不为空的对象，找到第一个继承IServiceKey的接口并注入接口及实现
                        var interfaceObj = type.GetInterfaces()
                            .FirstOrDefault(t => typeof(IServiceKey).GetTypeInfo().IsAssignableFrom(t));
                        if (interfaceObj != null)
                        {
                            services.RegisterType(type).AsImplementedInterfaces()
                                .Named(module.ModuleName, interfaceObj);
                            services.RegisterType(type).Named(module.ModuleName, type);
                        }
                    }
                }

                return builder;
            }
            catch (Exception ex)
            {
                if (!(ex is ReflectionTypeLoadException typeLoadException))
                {
                    throw;
                }

                var loaderExceptions = typeLoadException.LoaderExceptions;
                throw loaderExceptions[0];
            }
        }

        /// <summary>
        /// 依赖注入事件总线模块程序集
        /// </summary>
        /// <param name="builder">服务构建器.</param>
        /// <param name="virtualPaths">虚拟路径.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder RegisterServiceBus
            (this IServiceBuilder builder, params string[] virtualPaths)
        {
            var services = builder.Services;
            var referenceAssemblies = GetAssemblies(virtualPaths);

            foreach (var assembly in referenceAssemblies)
            {
                services.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(IIntegrationEventHandler).GetTypeInfo().IsAssignableFrom(t))
                    .AsImplementedInterfaces().SingleInstance();
                services.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(IIntegrationEventHandler).IsAssignableFrom(t)).SingleInstance();
            }

            return builder;
        }

        /// <summary>
        /// 依赖注入仓储模块程序集
        /// </summary>
        /// <param name="builder">IOC容器</param>
        /// <param name="virtualPaths">虚拟路径</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder RegisterRepositories(this IServiceBuilder builder, params string[] virtualPaths)
        {
            var services = builder.Services;
            var referenceAssemblies = GetAssemblies(virtualPaths);

            foreach (var assembly in referenceAssemblies)
            {
                services.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(BaseRepository).GetTypeInfo().IsAssignableFrom(t));
            }

            return builder;
        }

        /// <summary>
        /// 依赖注入组件模块程序集
        /// </summary>
        /// <param name="builder">服务构建器.</param>
        /// <param name="virtualPaths">虚拟路径.</param>
        /// <returns>IServiceBuilder.</returns>
        /// <exception cref="ArgumentNullException">builder</exception>
        public static IServiceBuilder RegisterModules(this IServiceBuilder builder, params string[] virtualPaths)
        {
            var services = builder.Services;
            var referenceAssemblies = GetAssemblies(virtualPaths);
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            // 从servicesettings.json取到packages
            var packages = ConvertDictionary(AppConfig.ServerOptions.Packages);
            foreach (var moduleAssembly in referenceAssemblies)
            {
                GetAbstractModules(moduleAssembly).ForEach(p =>
                {
                    services.RegisterModule(p);
                    if (packages.ContainsKey(p.TypeName))
                    {
                        var useModules = packages[p.TypeName];
                        if (useModules.AsSpan().IndexOf(p.ModuleName) >= 0)
                        {
                            p.Enable = true;
                        }
                        else
                        {
                            p.Enable = false;
                        }
                    }

                    _modules.Add(p);
                });
            }

            builder.Services.Register(provider => new ModuleProvider(
                _modules, virtualPaths, provider.Resolve<ILogger<ModuleProvider>>(),
                provider.Resolve<CPlatformContainer>()
            )).As<IModuleProvider>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// 获取接口服务.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <returns>List&lt;Type&gt;.</returns>
        public static List<Type> GetInterfaceService(this IServiceBuilder builder, params string[] virtualPaths)
        {
            var types = new List<Type>();
            var referenceAssemblies = GetReferenceAssembly(virtualPaths);
            referenceAssemblies.ForEach(p =>
            {
                types.AddRange(p.GetTypes().Where(t =>
                    typeof(IServiceKey).GetTypeInfo().IsAssignableFrom(t) && t.IsInterface));
            });
            return types;
        }

        /// <summary>
        /// 获取数据合约的名称.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> GetDataContractName(this IServiceBuilder builder,
            params string[] virtualPaths)
        {
            var namespaces = new List<string>();
            var assemblies = builder.GetInterfaceService(virtualPaths)
                .Select(p => p.Assembly)
                .Union(GetSystemModules())
                .Distinct()
                .ToList();

            assemblies.ForEach(assembly =>
            {
                namespaces.AddRange(assembly.GetTypes()
                    .Where(t => t.GetCustomAttribute<DataContractAttribute>() != null).Select(n => n.Namespace));
            });
            return namespaces;
        }

        /// <summary>
        /// 转换字典.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        private static IDictionary<string, string> ConvertDictionary(List<ModulePackage> list)
        {
            var result = new Dictionary<string, string>();
            list.ForEach(p => { result.Add(p.TypeName, p.Using); });
            return result;
        }

        /// <summary>
        /// 获取引用程序集.
        /// </summary>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <returns>List&lt;Assembly&gt;.</returns>
        private static List<Assembly> GetReferenceAssembly(params string[] virtualPaths)
        {
            var refAssemblies = new List<Assembly>();
            var rootPath = AppContext.BaseDirectory;
            var existsPath = virtualPaths.Any();
            if (existsPath && !string.IsNullOrEmpty(AppConfig.ServerOptions.RootPath))
            {
                rootPath = AppConfig.ServerOptions.RootPath;
            }

            var result = _referenceAssembly;
            if (!result.Any() || existsPath)
            {
                var paths = virtualPaths.Select(m => Path.Combine(rootPath, m)).ToList();
                if (!existsPath)
                {
                    paths.Add(rootPath);
                }

                paths.ForEach(path =>
                {
                    var assemblyFiles = GetAllAssemblyFiles(path);

                    foreach (var referencedAssemblyFile in assemblyFiles)
                    {
                        var referencedAssembly = Assembly.LoadFrom(referencedAssemblyFile);
                        if (!_referenceAssembly.Contains(referencedAssembly))
                        {
                            _referenceAssembly.Add(referencedAssembly);
                        }

                        refAssemblies.Add(referencedAssembly);
                    }

                    result = existsPath ? refAssemblies : _referenceAssembly;
                });
            }

            return result;
        }

        /// <summary>
        /// 获取系统模块.
        /// </summary>
        /// <returns>List&lt;Assembly&gt;.</returns>
        private static List<Assembly> GetSystemModules()
        {
            var assemblies = new List<Assembly>();
            var referenceAssemblies = GetReferenceAssembly();
            foreach (var referenceAssembly in referenceAssemblies)
            {
                var abstractModules = GetAbstractModules(referenceAssembly);
                if (abstractModules.Any(p => p.GetType().IsSubclassOf(typeof(SystemModule))))
                {
                    assemblies.Add(referenceAssembly);
                }
            }

            return assemblies;
        }

        /// <summary>
        /// 获取程序集.
        /// </summary>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <returns>List&lt;Assembly&gt;.</returns>
        private static List<Assembly> GetAssemblies(params string[] virtualPaths)
        {
            var referenceAssemblies = new List<Assembly>();
            if (virtualPaths.Any())
            {
                referenceAssemblies = GetReferenceAssembly(virtualPaths);
            }
            else
            {
                var assemblyNames = DependencyContext
                    .Default.GetDefaultAssemblyNames().Select(p => p.Name).ToArray();
                assemblyNames = GetFilterAssemblies(assemblyNames);
                foreach (var name in assemblyNames)
                {
                    referenceAssemblies.Add(Assembly.Load(name));
                }

                _referenceAssembly.AddRange(referenceAssemblies.Except(_referenceAssembly));
            }

            return referenceAssemblies;
        }

        /// <summary>
        /// 获取抽象模块（查找继承AbstractModule类的对象并创建实例）
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>List&lt;AbstractModule&gt;.</returns>
        private static List<AbstractModule> GetAbstractModules(Assembly assembly)
        {
            var abstractModules = new List<AbstractModule>();
            var arrayModule =
                assembly.GetTypes().Where(
                    t => t.IsSubclassOf(typeof(AbstractModule))).ToArray();
            foreach (var moduleType in arrayModule)
            {
                var abstractModule = (AbstractModule) Activator.CreateInstance(moduleType);
                abstractModules.Add(abstractModule);
            }

            return abstractModules;
        }

        /// <summary>
        /// 获取过滤器程序集.
        /// </summary>
        /// <param name="assemblyNames">The assembly names.</param>
        /// <returns>System.String[].</returns>
        private static string[] GetFilterAssemblies(string[] assemblyNames)
        {
            var notRelatedFile = AppConfig.ServerOptions.NotRelatedAssemblyFiles;
            var relatedFile = AppConfig.ServerOptions.RelatedAssemblyFiles;
            var pattern = string.Format(
                "^Microsoft.\\w*|^System.\\w*|^DotNetty.\\w*|^runtime.\\w*|^ZooKeeperNetEx\\w*|^StackExchange.Redis\\w*|^Consul\\w*|^Newtonsoft.Json.\\w*|^Autofac.\\w*{0}",
                string.IsNullOrEmpty(notRelatedFile) ? string.Empty : $"|{notRelatedFile}");
            var notRelatedRegex = new Regex(pattern,
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var relatedRegex = new Regex(relatedFile,
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!string.IsNullOrEmpty(relatedFile))
            {
                return
                    assemblyNames.Where(
                        name => !notRelatedRegex.IsMatch(name) && relatedRegex.IsMatch(name)).ToArray();
            }

            return
                assemblyNames.Where(
                    name => !notRelatedRegex.IsMatch(name)).ToArray();
        }

        /// <summary>
        /// 获取所有程序集.
        /// </summary>
        /// <param name="parentDir">The parent dir.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        private static List<string> GetAllAssemblyFiles(string parentDir)
        {
            var notRelatedFile = AppConfig.ServerOptions.NotRelatedAssemblyFiles;
            var relatedFile = AppConfig.ServerOptions.RelatedAssemblyFiles;
            var pattern =
                $"^Microsoft.\\w*|^System.\\w*|^Netty.\\w*|^Autofac.\\w*{(string.IsNullOrEmpty(notRelatedFile) ? string.Empty : $"|{notRelatedFile}")}";
            var notRelatedRegex = new Regex(pattern,
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var relatedRegex = new Regex(relatedFile,
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!string.IsNullOrEmpty(relatedFile))
            {
                return Directory.GetFiles(parentDir, "*.dll").Select(Path.GetFullPath)
                    .Where(a => !notRelatedRegex.IsMatch(a) && relatedRegex.IsMatch(a)).ToList();
            }

            return Directory.GetFiles(parentDir, "*.dll").Select(Path.GetFullPath)
                .Where(a => !notRelatedRegex.IsMatch(Path.GetFileName(a))).ToList();
        }

        #region RouteManager

        /// <summary>
        /// 设置服务路由管理者
        /// </summary>
        /// <typeparam name="T">服务路由管理者实现</typeparam>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseRouteManager<T>(this IServiceBuilder builder)
            where T : class, IServiceRouteManager
        {
            builder.Services.RegisterType(typeof(T)).As(typeof(IServiceRouteManager)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 设置服务路由管理者
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="factory">服务路由管理者实例工厂</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseRouteManager(this IServiceBuilder builder,
            Func<IServiceProvider, IServiceRouteManager> factory)
        {
            builder.Services.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// 设置服务订阅管理者
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="factory">服务订阅管理者实例工厂</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseSubscribeManager(this IServiceBuilder builder,
            Func<IServiceProvider, IServiceSubscribeManager> factory)
        {
            builder.Services.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// 设置服务命令管理者
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="factory">服务命令管理者实例工厂</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseCommandManager(this IServiceBuilder builder,
            Func<IServiceProvider, IServiceCommandManager> factory)
        {
            builder.Services.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// 设置缓存管理者
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="factory">缓存管理者实例工厂</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseCacheManager(this IServiceBuilder builder,
            Func<IServiceProvider, IServiceCacheManager> factory)
        {
            builder.Services.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// 设置服务路由管理者
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="instance">服务路由管理者实例</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseRouteManager(this IServiceBuilder builder, IServiceRouteManager instance)
        {
            builder.Services.RegisterInstance(instance);
            return builder;
        }

        /// <summary>
        /// 设置mqtt服务路由管理者
        /// </summary>
        /// <param name="builder">mqtt服务构建器</param>
        /// <param name="factory">mqtt服务路由管理者实例工厂</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseMqttRouteManager(this IServiceBuilder builder,
            Func<IServiceProvider, IMqttServiceRouteManager> factory)
        {
            builder.Services.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        #endregion RouteManager

        #region AddressSelector

        /// <summary>
        /// 使用轮询的地址选择器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UsePollingAddressSelector(this IServiceBuilder builder)
        {
            builder.Services.RegisterType(typeof(PollingAddressSelector))
                .Named(AddressSelectorMode.Polling.ToString(), typeof(IAddressSelector)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 使用压力最小优先分配轮询的地址选择器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseFairPollingAddressSelector(this IServiceBuilder builder)
        {
            builder.Services.RegisterType(typeof(FairPollingAdrSelector))
                .Named(AddressSelectorMode.FairPolling.ToString(), typeof(IAddressSelector)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 使用哈希的地址选择器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseHashAlgorithmAddressSelector(this IServiceBuilder builder)
        {
            builder.Services.RegisterType(typeof(HashAlgorithmAdrSelector))
                .Named(AddressSelectorMode.HashAlgorithm.ToString(), typeof(IAddressSelector)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 使用随机的地址选择器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseRandomAddressSelector(this IServiceBuilder builder)
        {
            builder.Services.RegisterType(typeof(RandomAddressSelector))
                .Named(AddressSelectorMode.Random.ToString(), typeof(IAddressSelector)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 设置服务地址选择器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseAddressSelector(this IServiceBuilder builder)
        {
            return builder.UseRandomAddressSelector().UsePollingAddressSelector().UseFairPollingAddressSelector()
                .UseHashAlgorithmAddressSelector();
        }

        #endregion AddressSelector

        #region Codec Factory

        /// <summary>
        /// 使用编解码器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="codecFactory">The codec factory.</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseCodec(this IServiceBuilder builder, ITransportMessageCodecFactory codecFactory)
        {
            builder.Services.RegisterInstance(codecFactory).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 使用编解码器
        /// </summary>
        /// <typeparam name="T">编解码器工厂实现类型</typeparam>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseCodec<T>(this IServiceBuilder builder)
            where T : class, ITransportMessageCodecFactory
        {
            builder.Services.RegisterType(typeof(T)).As(typeof(ITransportMessageCodecFactory)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 使用编解码器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <param name="codecFactory">编解码器工厂创建委托</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseCodec(this IServiceBuilder builder,
            Func<IServiceProvider, ITransportMessageCodecFactory> codecFactory)
        {
            builder.Services.RegisterAdapter(codecFactory).SingleInstance();
            return builder;
        }

        #endregion Codec Factory
    }
}