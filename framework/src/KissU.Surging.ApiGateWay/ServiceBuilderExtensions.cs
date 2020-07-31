using Autofac;
using KissU.Dependency;
using KissU.Modularity;
using KissU.Surging.ApiGateWay.Aggregation;
using KissU.Surging.ApiGateWay.OAuth;
using KissU.Surging.ApiGateWay.OAuth.Implementation;
using KissU.Surging.ApiGateWay.OAuth.Implementation.Configurations;
using KissU.Surging.ApiGateWay.ServiceDiscovery;
using KissU.Surging.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.CPlatform.Runtime.Client.HealthChecks;
using KissU.Surging.CPlatform.Runtime.Client.HealthChecks.Implementation;
using KissU.Surging.ProxyGenerator;

namespace KissU.Surging.ApiGateWay
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