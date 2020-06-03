using System;
using Autofac;
using KissU.Module;
using KissU.Serialization;
using KissU.Surging.Consul.Configurations;
using KissU.Surging.Consul.Internal;
using KissU.Surging.Consul.Internal.Cluster.HealthChecks;
using KissU.Surging.Consul.Internal.Cluster.HealthChecks.Implementation;
using KissU.Surging.Consul.Internal.Cluster.Implementation.Selectors;
using KissU.Surging.Consul.Internal.Cluster.Implementation.Selectors.Implementation;
using KissU.Surging.Consul.Internal.Implementation;
using KissU.Surging.Consul.WatcherProvider;
using KissU.Surging.Consul.WatcherProvider.Implementation;
using KissU.Surging.CPlatform.Cache;
using KissU.Surging.CPlatform.Mqtt;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.CPlatform.Runtime.Client;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Support;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Consul
{
    /// <summary>
    /// ConsulModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class ConsulModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var configInfo = new ConfigInfo(null);
            UseConsulAddressSelector(builder)
                .UseHealthCheck(builder)
                .UseCounlClientProvider(builder, configInfo)
                .UseConsulRouteManager(builder, configInfo)
                .UseConsulServiceSubscribeManager(builder, configInfo)
                .UseConsulCommandManager(builder, configInfo)
                .UseConsulCacheManager(builder, configInfo)
                .UseConsulWatch(builder, configInfo)
                .UseConsulMqttRouteManager(builder, configInfo);
        }

        /// <summary>
        /// Uses the consul route manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseConsulRouteManager(ContainerBuilderWrapper builder, ConfigInfo configInfo)
        {
            UseRouteManager(builder, provider =>
                new ConsulServiceRouteManager(
                    GetConfigInfo(configInfo),
                    provider.GetRequiredService<ISerializer<byte[]>>(),
                    provider.GetRequiredService<ISerializer<string>>(),
                    provider.GetRequiredService<IClientWatchManager>(),
                    provider.GetRequiredService<IServiceRouteFactory>(),
                    provider.GetRequiredService<ILogger<ConsulServiceRouteManager>>(),
                    provider.GetRequiredService<IServiceHeartbeatManager>(),
                    provider.GetRequiredService<IConsulClientProvider>()));
            return this;
        }

        /// <summary>
        /// Uses the consul cache manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseConsulCacheManager(ContainerBuilderWrapper builder, ConfigInfo configInfo)
        {
            UseCacheManager(builder, provider =>
                new ConsulServiceCacheManager(
                    GetConfigInfo(configInfo),
                    provider.GetRequiredService<ISerializer<byte[]>>(),
                    provider.GetRequiredService<ISerializer<string>>(),
                    provider.GetRequiredService<IClientWatchManager>(),
                    provider.GetRequiredService<IServiceCacheFactory>(),
                    provider.GetRequiredService<ILogger<ConsulServiceCacheManager>>(),
                    provider.GetRequiredService<IConsulClientProvider>()));
            return this;
        }

        /// <summary>
        /// 设置服务命令管理者。
        /// </summary>
        /// <param name="builder">Rpc服务构建者。</param>
        /// <param name="configInfo">ZooKeeper设置信息。</param>
        /// <returns>服务构建者。</returns>
        public ConsulModule UseConsulCommandManager(ContainerBuilderWrapper builder, ConfigInfo configInfo)
        {
            UseCommandManager(builder, provider => new ConsulServiceCommandManager(
                GetConfigInfo(configInfo),
                provider.GetRequiredService<ISerializer<byte[]>>(),
                provider.GetRequiredService<ISerializer<string>>(),
                provider.GetRequiredService<IServiceRouteManager>(),
                provider.GetRequiredService<IClientWatchManager>(),
                provider.GetRequiredService<IServiceEntryManager>(),
                provider.GetRequiredService<ILogger<ConsulServiceCommandManager>>(),
                provider.GetRequiredService<IServiceHeartbeatManager>(),
                provider.GetRequiredService<IConsulClientProvider>()));
            return this;
        }

        /// <summary>
        /// Uses the consul service subscribe manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseConsulServiceSubscribeManager(ContainerBuilderWrapper builder, ConfigInfo configInfo)
        {
            UseSubscribeManager(builder, provider => new ConsulServiceSubscribeManager(
                GetConfigInfo(configInfo),
                provider.GetRequiredService<ISerializer<byte[]>>(),
                provider.GetRequiredService<ISerializer<string>>(),
                provider.GetRequiredService<IClientWatchManager>(),
                provider.GetRequiredService<IServiceSubscriberFactory>(),
                provider.GetRequiredService<ILogger<ConsulServiceSubscribeManager>>(),
                provider.GetRequiredService<IConsulClientProvider>()));
            return this;
        }

        /// <summary>
        /// Uses the consul MQTT route manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseConsulMqttRouteManager(ContainerBuilderWrapper builder, ConfigInfo configInfo)
        {
            UseMqttRouteManager(builder, provider =>
                new ConsulMqttServiceRouteManager(
                    GetConfigInfo(configInfo),
                    provider.GetRequiredService<ISerializer<byte[]>>(),
                    provider.GetRequiredService<ISerializer<string>>(),
                    provider.GetRequiredService<IClientWatchManager>(),
                    provider.GetRequiredService<IMqttServiceFactory>(),
                    provider.GetRequiredService<ILogger<ConsulMqttServiceRouteManager>>(),
                    provider.GetRequiredService<IServiceHeartbeatManager>(),
                    provider.GetRequiredService<IConsulClientProvider>()));
            return this;
        }

        /// <summary>
        /// 设置使用基于Consul的Watch机制
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseConsulWatch(ContainerBuilderWrapper builder, ConfigInfo configInfo)
        {
            builder.Register(provider =>
            {
                return new ClientWatchManager(provider.Resolve<ILogger<ClientWatchManager>>(), configInfo);
            }).As<IClientWatchManager>().SingleInstance();
            return this;
        }

        /// <summary>
        /// Uses the consul address selector.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseConsulAddressSelector(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<ConsulRandomAddressSelector>().As<IConsulAddressSelector>().SingleInstance();
            return this;
        }

        /// <summary>
        /// Uses the health check.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseHealthCheck(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<DefaultHealthCheckService>().As<IHealthCheckService>().SingleInstance();
            return this;
        }

        /// <summary>
        /// Uses the counl client provider.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>ConsulModule.</returns>
        public ConsulModule UseCounlClientProvider(ContainerBuilderWrapper builder, ConfigInfo configInfo)
        {
            UseCounlClientProvider(builder, provider =>
                new DefaultConsulClientProvider(
                    GetConfigInfo(configInfo),
                    provider.GetRequiredService<IHealthCheckService>(),
                    provider.GetRequiredService<IConsulAddressSelector>(),
                    provider.GetRequiredService<ILogger<DefaultConsulClientProvider>>()));
            return this;
        }

        /// <summary>
        /// Uses the subscribe manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ContainerBuilderWrapper.</returns>
        public ContainerBuilderWrapper UseSubscribeManager(ContainerBuilderWrapper builder,
            Func<IServiceProvider, IServiceSubscribeManager> factory)
        {
            builder.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// Uses the command manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ContainerBuilderWrapper.</returns>
        public ContainerBuilderWrapper UseCommandManager(ContainerBuilderWrapper builder,
            Func<IServiceProvider, IServiceCommandManager> factory)
        {
            builder.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// Uses the cache manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ContainerBuilderWrapper.</returns>
        public ContainerBuilderWrapper UseCacheManager(ContainerBuilderWrapper builder,
            Func<IServiceProvider, IServiceCacheManager> factory)
        {
            builder.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// Uses the route manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ContainerBuilderWrapper.</returns>
        public ContainerBuilderWrapper UseRouteManager(ContainerBuilderWrapper builder,
            Func<IServiceProvider, IServiceRouteManager> factory)
        {
            builder.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// Uses the MQTT route manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ContainerBuilderWrapper.</returns>
        public ContainerBuilderWrapper UseMqttRouteManager(ContainerBuilderWrapper builder,
            Func<IServiceProvider, IMqttServiceRouteManager> factory)
        {
            builder.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// Uses the counl client provider.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ContainerBuilderWrapper.</returns>
        public ContainerBuilderWrapper UseCounlClientProvider(ContainerBuilderWrapper builder,
            Func<IServiceProvider, IConsulClientProvider> factory)
        {
            builder.RegisterAdapter(factory).InstancePerLifetimeScope();
            return builder;
        }

        private ConfigInfo GetConfigInfo(ConfigInfo config)
        {
            ConsulOption option = null;
            var section = CPlatform.AppConfig.GetSection("Consul");
            if (section.Exists())
                option = section.Get<ConsulOption>();
            else if (AppConfig.Configuration != null)
                option = AppConfig.Configuration.Get<ConsulOption>();
            if (option != null)
            {
                var sessionTimeout = config.SessionTimeout.TotalSeconds;
                double.TryParse(option.SessionTimeout, out sessionTimeout);
                config = new ConfigInfo(
                    option.ConnectionString,
                    TimeSpan.FromSeconds(sessionTimeout),
                    option.LockDelay ?? config.LockDelay,
                    option.RoutePath ?? config.RoutePath,
                    option.SubscriberPath ?? config.SubscriberPath,
                    option.CommandPath ?? config.CommandPath,
                    option.CachePath ?? config.CachePath,
                    option.MqttRoutePath ?? config.MqttRoutePath,
                    option.ReloadOnChange != null ? bool.Parse(option.ReloadOnChange) : config.ReloadOnChange,
                    option.EnableChildrenMonitor != null
                        ? bool.Parse(option.EnableChildrenMonitor)
                        : config.EnableChildrenMonitor
                );
            }

            return config;
        }
    }
}