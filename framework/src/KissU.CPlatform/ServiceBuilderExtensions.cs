using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Autofac;
using KissU.Convertibles;
using KissU.Convertibles.Implementation;
using KissU.Dependency;
using KissU.EventBus.Events;
using KissU.Helpers;
using KissU.Modularity;
using KissU.Serialization;
using KissU.Serialization.Implementation;
using KissU.CPlatform.Cache;
using KissU.CPlatform.Configurations;
using KissU.CPlatform.Configurations.Watch;
using KissU.CPlatform.Engines;
using KissU.CPlatform.Engines.Implementation;
using KissU.CPlatform.Filters;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.HashAlgorithms;
using KissU.CPlatform.Ids;
using KissU.CPlatform.Ids.Implementation;
using KissU.CPlatform.Mqtt;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Routing.Implementation;
using KissU.CPlatform.Runtime.Client;
using KissU.CPlatform.Runtime.Client.Address.Resolvers;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Runtime.Client.HealthChecks.Implementation;
using KissU.CPlatform.Runtime.Client.Implementation;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Implementation;
using KissU.CPlatform.Support;
using KissU.CPlatform.Support.Implementation;
using KissU.CPlatform.Transport.Codec;
using KissU.CPlatform.Transport.Codec.Implementation;
using KissU.Validation;
using KissU.Validation.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.CPlatform
{
    /// <summary>
    /// 容器构建器扩展.
    /// </summary>
    public static class ServiceBuilderExtensions
    {
        private static readonly List<AbstractModule> _modules = new List<AbstractModule>();

        /// <summary>
        /// 添加Json序列化支持
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddJsonSerialization(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType(typeof(JsonSerializer)).As(typeof(ISerializer<string>)).SingleInstance();
            containerBuilder.RegisterType(typeof(StringByteArraySerializer)).As(typeof(ISerializer<byte[]>)).SingleInstance();
            containerBuilder.RegisterType(typeof(StringObjectSerializer)).As(typeof(ISerializer<object>)).SingleInstance();
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
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType(typeof(ConfigurationWatchManager)).As(typeof(IConfigurationWatchManager))
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
            var services = builder.ContainerBuilder;
            services.RegisterType(typeof(DefaultServiceEntryLocate)).As(typeof(IServiceEntryLocate)).SingleInstance();
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
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType(typeof(ServiceCommandProvider)).As(typeof(IServiceCommandProvider)).SingleInstance();
            containerBuilder.RegisterType(typeof(BreakeRemoteInvokeService)).As(typeof(IBreakeRemoteInvokeService))
                .SingleInstance();
            containerBuilder.RegisterType(typeof(FailoverInjectionInvoker)).AsImplementedInterfaces()
                .Named(StrategyType.Injection.ToString(), typeof(IClusterInvoker)).SingleInstance();
            containerBuilder.RegisterType(typeof(FailoverHandoverInvoker)).AsImplementedInterfaces()
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
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.Register(p => filter).As(typeof(IFilter)).SingleInstance();
            switch (filter)
            {
                case IExceptionFilter exceptionFilter:
                    containerBuilder.Register(p => exceptionFilter).As(typeof(IExceptionFilter)).SingleInstance();
                    break;
                case IAuthorizationFilter authorizationFilter:
                    containerBuilder.Register(p => authorizationFilter).As(typeof(IAuthorizationFilter)).SingleInstance();
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
        public static IServiceBuilder AddServiceEngine(this IServiceBuilder builder, Type engine = null)
        {
            var containerBuilder = builder.ContainerBuilder;
            engine ??= typeof(DefaultVirtualPathProviderServiceEngine);
            containerBuilder.RegisterType(engine).As(typeof(IServiceEngine)).SingleInstance();
            builder.ContainerBuilder.RegisterType(typeof(DefaultServiceEngineBuilder)).As(typeof(IServiceEngineBuilder)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 添加服务运行时服务
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddServiceRuntime(this IServiceBuilder builder)
        {
            builder.ContainerBuilder.RegisterType(typeof(DefaultServiceEntryLocate)).As(typeof(IServiceEntryLocate)).SingleInstance();
            builder.ContainerBuilder.RegisterType(typeof(DefaultServiceExecutor)).As(typeof(IServiceExecutor)).Named<IServiceExecutor>(CommunicationProtocol.Tcp.ToString()).SingleInstance();

            return builder
                .RegisterServices()
                .RegisterServiceBus()
                .RegisterModules()
                .RegisterInstanceByConstraint()
                .AddRuntime();
        }

        /// <summary>
        /// 添加关联服务运行时
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder AddRelateServiceRuntime(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType(typeof(DefaultHealthCheckService)).As(typeof(IHealthCheckService)).SingleInstance();
            containerBuilder.RegisterType(typeof(DefaultAddressResolver)).As(typeof(IAddressResolver)).SingleInstance();
            containerBuilder.RegisterType(typeof(RemoteInvokeService)).As(typeof(IRemoteInvokeService)).SingleInstance();
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
            var containerBuilder = builder.ContainerBuilder;
            var referenceAssemblies = ModuleHelper.GetReferenceAssembly(virtualPaths);

            foreach (var assembly in referenceAssemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(ISingletonDependency).GetTypeInfo().IsAssignableFrom(t))
                    .AsImplementedInterfaces().AsSelf().SingleInstance();

                containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(IScopedDependency).GetTypeInfo().IsAssignableFrom(t))
                    .AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();

                containerBuilder.RegisterAssemblyTypes(assembly)
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
            var containerBuilder = builder.ContainerBuilder;

            containerBuilder.RegisterType(typeof(ClrServiceEntryFactory)).As(typeof(IClrServiceEntryFactory)).SingleInstance();

            containerBuilder.Register(provider =>
            {
                try
                {
                    var assemblys = ModuleHelper.GetReferenceAssembly();
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
            builder.ContainerBuilder.RegisterType(typeof(DefaultServiceEntryManager)).As(typeof(IServiceEntryManager))
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
            builder.RegisterBuildCallback(ServiceLocator.Register);
            builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
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
                var containerBuilder = builder.ContainerBuilder;
                var referenceAssemblies = ModuleHelper.GetAssemblies(virtualPaths);
                foreach (var assembly in referenceAssemblies)
                {
                    containerBuilder.RegisterAssemblyTypes(assembly)
                        // 注入继承IServiceKey接口的所有接口
                        .Where(t => typeof(IServiceKey).GetTypeInfo().IsAssignableFrom(t) && t.IsInterface)
                        .AsImplementedInterfaces();
                    containerBuilder.RegisterAssemblyTypes(assembly)
                        // 注入实现IServiceBehavior接口并ModuleName为空的类，作为接口实现类
                        .Where(t => !typeof(ISingletonDependency).GetTypeInfo().IsAssignableFrom(t) &&
                                    typeof(IServiceBehavior).GetTypeInfo().IsAssignableFrom(t) &&
                                    t.GetTypeInfo().GetCustomAttribute<ModuleNameAttribute>() == null)
                        .AsImplementedInterfaces();

                    containerBuilder.RegisterAssemblyTypes(assembly)
                        // 注入实现IServiceBehavior接口并ModuleName为空的类，作为接口实现类
                        .Where(t => typeof(ISingletonDependency).GetTypeInfo().IsAssignableFrom(t) &&
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
                            containerBuilder.RegisterType(type).AsImplementedInterfaces()
                                .Named(module.ModuleName, interfaceObj);
                            containerBuilder.RegisterType(type).Named(module.ModuleName, type);
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
            var containerBuilder = builder.ContainerBuilder;
            var referenceAssemblies = ModuleHelper.GetAssemblies(virtualPaths);

            foreach (var assembly in referenceAssemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(IIntegrationEventHandler).GetTypeInfo().IsAssignableFrom(t))
                    .AsImplementedInterfaces().SingleInstance();
                containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(IIntegrationEventHandler).IsAssignableFrom(t)).SingleInstance();
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
            var containerBuilder = builder.ContainerBuilder;
            var referenceAssemblies = ModuleHelper.GetAssemblies(virtualPaths);
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            // 从servicesettings.json取到packages
            var packages = ConvertDictionary(AppConfig.ServerOptions.Packages);
            foreach (var moduleAssembly in referenceAssemblies)
            {
                ModuleHelper.GetAbstractModules(moduleAssembly).ForEach(p =>
                {
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

                    if (p.Enable)
                    {
                        containerBuilder.RegisterModule(p);
                    }

                    _modules.Add(p);
                });
            }

            builder.ContainerBuilder.Register(provider => new ModuleProvider(
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
            var referenceAssemblies = ModuleHelper.GetReferenceAssembly(virtualPaths);
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
                .Union(ModuleHelper.GetSystemModules())
                .Distinct()
                .ToList();

            assemblies.ForEach(assembly =>
            {
                namespaces.AddRange(assembly.GetTypes().Where(t => t.GetCustomAttribute<DataContractAttribute>() != null).Select(n => n.Namespace));
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
            builder.ContainerBuilder.RegisterType(typeof(T)).As(typeof(IServiceRouteManager)).SingleInstance();
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
            builder.ContainerBuilder.RegisterAdapter(factory).InstancePerLifetimeScope();
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
            builder.ContainerBuilder.RegisterAdapter(factory).InstancePerLifetimeScope();
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
            builder.ContainerBuilder.RegisterAdapter(factory).InstancePerLifetimeScope();
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
            builder.ContainerBuilder.RegisterAdapter(factory).InstancePerLifetimeScope();
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
            builder.ContainerBuilder.RegisterInstance(instance);
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
            builder.ContainerBuilder.RegisterAdapter(factory).InstancePerLifetimeScope();
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
            builder.ContainerBuilder.RegisterType(typeof(PollingAddressSelector))
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
            builder.ContainerBuilder.RegisterType(typeof(FairPollingAdrSelector))
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
            builder.ContainerBuilder.RegisterType(typeof(HashAlgorithmAdrSelector))
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
            builder.ContainerBuilder.RegisterType(typeof(RandomAddressSelector))
                .Named(AddressSelectorMode.Random.ToString(), typeof(IAddressSelector)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 使用权重轮询选择器。
        /// </summary>
        /// <param name="builder">服务构建者。</param>
        /// <returns>服务构建者。</returns>
        public static IServiceBuilder UseRoundRobinAddressSelector(this IServiceBuilder builder)
        {
            builder.ContainerBuilder.RegisterType(typeof(RoundRobinAddressSelector))
                .Named(AddressSelectorMode.RoundRobin.ToString(), typeof(IAddressSelector)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// 设置服务地址选择器
        /// </summary>
        /// <param name="builder">服务构建器</param>
        /// <returns>服务构建器</returns>
        public static IServiceBuilder UseAddressSelector(this IServiceBuilder builder)
        {
            return builder.UseRandomAddressSelector().UsePollingAddressSelector().UseFairPollingAddressSelector().UseHashAlgorithmAddressSelector().UseRoundRobinAddressSelector();
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
            builder.ContainerBuilder.RegisterInstance(codecFactory).SingleInstance();
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
            builder.ContainerBuilder.RegisterType(typeof(T)).As(typeof(ITransportMessageCodecFactory)).SingleInstance();
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
            builder.ContainerBuilder.RegisterAdapter(codecFactory).SingleInstance();
            return builder;
        }

        #endregion Codec Factory
    }
}