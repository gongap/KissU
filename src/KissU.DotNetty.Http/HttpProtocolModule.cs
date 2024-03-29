using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.CPlatform.Transport.Codec;
using KissU.Modularity;
using KissU.Serialization;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Http
{
    /// <summary>
    /// HttpProtocolModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class HttpProtocolModule : EnginePartModule
    {
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType(typeof(HttpServiceExecutor)).As(typeof(IServiceExecutor))
                .Named<IServiceExecutor>(CommunicationProtocol.Http.ToString()).SingleInstance();
            if (AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.Http))
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.None) || AppConfig.ServerOptions.Protocols.Contains(nameof(CommunicationProtocol.Http)))
            {
                RegisterHttpProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyHttpServerMessageListener(
                    provider.Resolve<ILogger<DotNettyHttpServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>(),
                    provider.Resolve<ISerializer<string>>(),
                    provider.Resolve<IServiceRouteProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Http.ToString());
                var messageListener = provider.Resolve<DotNettyHttpServerMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }

        private static void RegisterHttpProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyHttpServerMessageListener(
                    provider.Resolve<ILogger<DotNettyHttpServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>(),
                    provider.Resolve<ISerializer<string>>(),
                    provider.Resolve<IServiceRouteProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Http.ToString());
                var messageListener = provider.Resolve<DotNettyHttpServerMessageListener>();
                return new HttpServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }
    }
}
