using Autofac;
using KissU.Dependency;
using KissU.Modularity;
using KissU.ApiGateWay.Aggregation;
using KissU.ApiGateWay.OAuth;
using KissU.ApiGateWay.OAuth.Implementation;
using KissU.ApiGateWay.OAuth.Implementation.Configurations;
using KissU.ApiGateWay.ServiceDiscovery;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Runtime.Client.HealthChecks.Implementation;
using KissU.ServiceProxy;

namespace KissU.ApiGateWay
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ServiceBuilderExtensions
    {
        /// <summary>
        /// 添加网关中间件
        /// </summary>
        /// <param name="builder">服务构建者</param>
        /// <param name="config">The configuration.</param>
        /// <returns>服务构建者</returns>
        public static IServiceBuilder AddApiGateWay(this IServiceBuilder builder, ConfigInfo config = null)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<FaultTolerantProvider>().As<IFaultTolerantProvider>().SingleInstance();
            containerBuilder.RegisterType<DefaultHealthCheckService>().As<IHealthCheckService>().SingleInstance();
            containerBuilder.RegisterType<ServiceDiscoveryProvider>().As<IServiceDiscoveryProvider>().SingleInstance();
            containerBuilder.RegisterType<ServiceRegisterProvider>().As<IServiceRegisterProvider>().SingleInstance();
            containerBuilder.RegisterType<ServiceSubscribeProvider>().As<IServiceSubscribeProvider>().SingleInstance();
            containerBuilder.RegisterType<ServiceCacheProvider>().As<IServiceCacheProvider>().SingleInstance();
            containerBuilder.RegisterType<ServicePartProvider>().As<IServicePartProvider>().SingleInstance();
            if (config != null)
            {
                AppConfig.AccessTokenExpireTimeSpan = config.AccessTokenExpireTimeSpan;
                AppConfig.AuthorizationRoutePath = config.AuthorizationRoutePath;
                AppConfig.AuthorizationServiceKey = config.AuthorizationServiceKey;
            }

            builder.ContainerBuilder.Register(provider =>
            {
                var serviceProxyProvider = provider.Resolve<IServiceProxyProvider>();
                var serviceRouteProvider = provider.Resolve<IServiceRouteProvider>();
                var serviceProvider = provider.Resolve<CPlatformContainer>();
                return new AuthorizationServerProvider(serviceProxyProvider, serviceRouteProvider, serviceProvider);
            }).As<IAuthorizationServerProvider>().SingleInstance();
            return builder;
        }
    }
}