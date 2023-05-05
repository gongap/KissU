using System.Linq;
using Autofac;
using KissU.Modularity;
using KissU.ApiGateWay.Aggregation;
using KissU.ApiGateWay.Configurations;
using KissU.ApiGateWay.OAuth;
using KissU.ApiGateWay.OAuth.Implementation;
using KissU.ApiGateWay.ServiceDiscovery;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Runtime.Client.HealthChecks.Implementation;
using KissU.ServiceProxy;
using KissU.CPlatform.Runtime.Server;
using KissU.Dependency;
using KissU.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.ApiGateWay
{
    /// <summary>
    /// ApiGeteWayModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class ApiGateWayModule : EnginePartModule
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<FaultTolerantProvider>().As<IFaultTolerantProvider>().SingleInstance();
            builder.RegisterType<DefaultHealthCheckService>().As<IHealthCheckService>().SingleInstance();
            builder.RegisterType<ServiceDiscoveryProvider>().As<IServiceDiscoveryProvider>().SingleInstance();
            builder.RegisterType<ServiceRegisterProvider>().As<IServiceRegisterProvider>().SingleInstance();
            builder.RegisterType<ServiceSubscribeProvider>().As<IServiceSubscribeProvider>().SingleInstance();
            builder.RegisterType<ServicePartProvider>().As<IServicePartProvider>().SingleInstance();
            builder.Register(provider =>
            {
                var serviceProxyProvider = provider.Resolve<IServiceProxyProvider>();
                var serviceRouteProvider = provider.Resolve<IServiceRouteProvider>();
                var serviceEntryLocate = provider.Resolve<IServiceEntryLocate>();
                var cacheProvider = provider.Resolve<IDistributedCache>();
                var serviceProvider = provider.Resolve<CPlatformContainer>();
                var jsonSerializer = provider.Resolve<ISerializer<string>>();
                return new AuthorizationServerProvider(serviceProxyProvider, serviceRouteProvider, serviceEntryLocate, cacheProvider,serviceProvider, jsonSerializer);
            }).As<IAuthorizationServerProvider>().SingleInstance();

            var packages = CPlatform.AppConfig.ServerOptions.Packages.FirstOrDefault(x=>x.TypeName=="EnginePartModule");
            if((packages?.Using?.Contains("ConsulModule")).GetValueOrDefault())
            {
                AppConfig.Register = new Register
                {
                    Provider = RegisterProvider.Consul,
                    Address = CPlatform.AppConfig.Configuration["Consul:ConnectionString"],
                };
            }
            else if((packages?.Using?.Contains("ZookeeperModule")).GetValueOrDefault())
            {
                AppConfig.Register = new Register
                {
                    Provider = RegisterProvider.Zookeeper,
                    Address = CPlatform.AppConfig.Configuration["Zookeeper:ConnectionString"],
                };
            }
        }

        public override void ConfigureServices(ServiceCollectionWrapper context)
        {
            context.Services.AddMemoryCache();
            context.Services.AddDistributedMemoryCache();
        }
    }
}