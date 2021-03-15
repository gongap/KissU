using System.Net;
using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Engines;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.Dependency;
using KissU.Kestrel.Http.Diagnostics;
using KissU.Kestrel.Http.Filters.Implementation;
using KissU.Modularity;
using KissU.Serialization;
using Microsoft.Extensions.Logging;

namespace KissU.Kestrel.Http
{
    /// <summary>
    /// KestrelHttpModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class KestrelHttpServerModule : EnginePartModule
    {
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