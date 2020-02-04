using System;
using Autofac;
using KissU.Core.Consul.Configurations;
using KissU.Core.Consul.Internal;
using KissU.Core.Consul.Internal.Cluster.HealthChecks;
using KissU.Core.Consul.Internal.Cluster.HealthChecks.Implementation;
using KissU.Core.Consul.Internal.Cluster.Implementation.Selectors;
using KissU.Core.Consul.Internal.Cluster.Implementation.Selectors.Implementation;
using KissU.Core.Consul.Internal.Implementation;
using KissU.Core.Consul.WatcherProvider;
using KissU.Core.Consul.WatcherProvider.Implementation;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Cache;
using KissU.Core.CPlatform.Mqtt;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Runtime.Client;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Consul
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// 设置服务路由管理者。
        /// </summary>
        /// <param name="builder">Rpc服务构建者。</param>
        /// <param name="configInfo">Consul设置信息。</param>
        /// <returns>服务构建者。</returns>
        public static IServiceBuilder UseConsulRouteManager(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            return builder.UseRouteManager(provider =>
             new ConsulServiceRouteManager(
                GetConfigInfo(configInfo),
                provider.GetRequiredService<ISerializer<byte[]>>(),
                provider.GetRequiredService<ISerializer<string>>(),
                provider.GetRequiredService<IClientWatchManager>(),
                provider.GetRequiredService<IServiceRouteFactory>(),
                provider.GetRequiredService<ILogger<ConsulServiceRouteManager>>(),
                provider.GetRequiredService<IServiceHeartbeatManager>(),
                provider.GetRequiredService<IConsulClientProvider>()));
        }

        /// <summary>
        /// Uses the consul cache manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseConsulCacheManager(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            return builder.UseCacheManager(provider =>
             new ConsulServiceCacheManager(
                GetConfigInfo(configInfo),
                provider.GetRequiredService<ISerializer<byte[]>>(),
                provider.GetRequiredService<ISerializer<string>>(),
                provider.GetRequiredService<IClientWatchManager>(),
                provider.GetRequiredService<IServiceCacheFactory>(),
                provider.GetRequiredService<ILogger<ConsulServiceCacheManager>>(),
                provider.GetRequiredService<IConsulClientProvider>()));
        }

        /// <summary>
        /// 设置服务命令管理者。
        /// </summary>
        /// <param name="builder">Rpc服务构建者。</param>
        /// <param name="configInfo">Consul设置信息。</param>
        /// <returns>服务构建者。</returns>
        public static IServiceBuilder UseConsulCommandManager(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            return builder.UseCommandManager(provider =>
            {
                var result = new ConsulServiceCommandManager(
                    GetConfigInfo(configInfo),
                    provider.GetRequiredService<ISerializer<byte[]>>(),
                    provider.GetRequiredService<ISerializer<string>>(),
                    provider.GetRequiredService<IServiceRouteManager>(),
                    provider.GetRequiredService<IClientWatchManager>(),
                    provider.GetRequiredService<IServiceEntryManager>(),
                    provider.GetRequiredService<ILogger<ConsulServiceCommandManager>>(),
                    provider.GetRequiredService<IServiceHeartbeatManager>(),
                    provider.GetRequiredService<IConsulClientProvider>());
                return result;
            });
        }

        /// <summary>
        /// Uses the consul MQTT route manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseConsulMqttRouteManager(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            return builder.UseMqttRouteManager(provider =>
             new ConsulMqttServiceRouteManager(
                 GetConfigInfo(configInfo),
                provider.GetRequiredService<ISerializer<byte[]>>(),
                provider.GetRequiredService<ISerializer<string>>(),
                provider.GetRequiredService<IClientWatchManager>(),
                provider.GetRequiredService<IMqttServiceFactory>(),
                provider.GetRequiredService<ILogger<ConsulMqttServiceRouteManager>>(),
                provider.GetRequiredService<IServiceHeartbeatManager>(),
                provider.GetRequiredService<IConsulClientProvider>()));
        }

        /// <summary>
        /// Uses the consul service subscribe manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseConsulServiceSubscribeManager(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            return builder.UseSubscribeManager(provider =>
            {
                var result = new ConsulServiceSubscribeManager(
                    GetConfigInfo(configInfo),
                    provider.GetRequiredService<ISerializer<byte[]>>(),
                    provider.GetRequiredService<ISerializer<string>>(),
                    provider.GetRequiredService<IClientWatchManager>(),
                    provider.GetRequiredService<IServiceSubscriberFactory>(),
                    provider.GetRequiredService<ILogger<ConsulServiceSubscribeManager>>(),
               provider.GetRequiredService<IConsulClientProvider>());
                return result;
            });
        }

        /// <summary>
        /// 设置使用基于Consul的Watch机制
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseConsulWatch(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            builder.Services.Register(provider =>
            {
                return new ClientWatchManager(provider.Resolve<ILogger<ClientWatchManager>>(), configInfo);
            }).As<IClientWatchManager>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// Uses the consul address selector.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseConsulAddressSelector(this IServiceBuilder builder)
        {
            builder.Services.RegisterType<ConsulRandomAddressSelector>().As<IConsulAddressSelector>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// Uses the health check.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseHealthCheck(this IServiceBuilder builder)
        {
            builder.Services.RegisterType<DefaultHealthCheckService>().As<IHealthCheckService>().SingleInstance();
            return builder;
        }


        /// <summary>
        /// Uses the counl client provider.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseCounlClientProvider(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            builder.Services.Register(provider =>
              new DefaultConsulClientProvider(
                GetConfigInfo(configInfo),
                provider.Resolve<IHealthCheckService>(),
                provider.Resolve<IConsulAddressSelector>(),
                provider.Resolve<ILogger<DefaultConsulClientProvider>>())).As<IConsulClientProvider>().SingleInstance();
            return builder;
        }

        /// <summary>
        /// Uses the consul manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>IServiceBuilder.</returns>
        [Obsolete]
        public static IServiceBuilder UseConsulManager(this IServiceBuilder builder, ConfigInfo configInfo)
        {
            return builder.UseConsulRouteManager(configInfo)
                .UseHealthCheck()
                .UseConsulServiceSubscribeManager(configInfo)
                .UseConsulCommandManager(configInfo)
                .UseConsulCacheManager(configInfo)
                .UseCounlClientProvider(configInfo)
                .UseConsulAddressSelector()
                .UseConsulWatch(configInfo)
                .UseConsulMqttRouteManager(configInfo);
        }

        /// <summary>
        /// Uses the consul manager.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceBuilder.</returns>
        [Obsolete]
        public static IServiceBuilder UseConsulManager(this IServiceBuilder builder)
        {
            var configInfo = new ConfigInfo(null);
            return builder.UseConsulRouteManager(configInfo)
                .UseHealthCheck()
                .UseConsulServiceSubscribeManager(configInfo)
                .UseConsulCommandManager(configInfo)
                .UseCounlClientProvider(configInfo)
                .UseConsulAddressSelector()
                .UseConsulCacheManager(configInfo).UseConsulWatch(configInfo)
                .UseConsulMqttRouteManager(configInfo);
        }


        private static ConfigInfo GetConfigInfo(ConfigInfo config)
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
                Double.TryParse(option.SessionTimeout, out sessionTimeout);
                config = new ConfigInfo(
                    option.ConnectionString,
                    TimeSpan.FromSeconds(sessionTimeout),
                    option.LockDelay ?? config.LockDelay,
                    option.RoutePath ?? config.RoutePath,
                    option.SubscriberPath ?? config.SubscriberPath,
                    option.CommandPath ?? config.CommandPath,
                    option.CachePath ?? config.CachePath,
                    option.MqttRoutePath ?? config.MqttRoutePath,
                    option.ReloadOnChange != null ? bool.Parse(option.ReloadOnChange) :
                    config.ReloadOnChange,
                    option.EnableChildrenMonitor != null ? bool.Parse(option.EnableChildrenMonitor) :
                    config.EnableChildrenMonitor
                   );
            }
            return config;
        }
    }
}
