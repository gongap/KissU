using System.Net;
using Autofac;
using KissU.Dependency;
using KissU.Modularity;
using KissU.Serialization;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Engines;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.KestrelHttpServer.Diagnostics;
using KissU.Surging.KestrelHttpServer.Extensions;
using KissU.Surging.KestrelHttpServer.Filters.Implementation;
using KissU.Surging.KestrelHttpServer.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Surging.KestrelHttpServer
{
    /// <summary>
    /// KestrelHttpModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class KestrelHttpServerModule : KestrelHttpModule
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="context">The builder.</param>
        public override void Configure(ApplicationInitializationContext context)
        {
            RestContext.GetContext().Initialize(context.ServiceProvider);
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void ConfigureWebHost(WebHostContext context)
        {
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">The services.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            context.Services.AddFilters(typeof(HttpRequestFilterAttribute));
            context.Services.AddFilters(typeof(CustomerExceptionFilterAttribute));
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.AddFilter(typeof(ServiceExceptionFilter));
            builder.RegisterType<RestTransportDiagnosticProcessor>().As<ITracingDiagnosticProcessor>().SingleInstance();
            builder.RegisterType(typeof(HttpExecutor)).As(typeof(IServiceExecutor))
                .Named<IServiceExecutor>(CommunicationProtocol.Http.ToString()).SingleInstance();
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.Http)
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterHttpProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new KestrelHttpMessageListener(
                    provider.Resolve<ILogger<KestrelHttpMessageListener>>(),
                    provider.Resolve<ISerializer<string>>(),
                    provider.Resolve<IServiceEngineLifetime>(),
                    provider.Resolve<IModuleProvider>(),
                    provider.Resolve<IServiceRouteProvider>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var executor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Http.ToString());
                var messageListener = provider.Resolve<KestrelHttpMessageListener>();
                return new DefaultHttpServiceHost(async endPoint =>
                {
                    var address = endPoint as IPEndPoint;
                    await messageListener.StartAsync(address?.Address, address?.Port);
                    return messageListener;
                }, executor, messageListener);
            }).As<IServiceHost>();
        }

        private static void RegisterHttpProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new KestrelHttpMessageListener(
                    provider.Resolve<ILogger<KestrelHttpMessageListener>>(),
                    provider.Resolve<ISerializer<string>>(),
                    provider.Resolve<IServiceEngineLifetime>(),
                    provider.Resolve<IModuleProvider>(),
                    provider.Resolve<IServiceRouteProvider>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var executor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Http.ToString());
                var messageListener = provider.Resolve<KestrelHttpMessageListener>();
                return new HttpServiceHost(async endPoint =>
                {
                    var address = endPoint as IPEndPoint;
                    await messageListener.StartAsync(address?.Address, address?.Port);
                    return messageListener;
                }, executor, messageListener);
            }).As<IServiceHost>();
        }
    }
}