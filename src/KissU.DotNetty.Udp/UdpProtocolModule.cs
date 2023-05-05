using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport.Codec;
using KissU.Dependency;
using KissU.DotNetty.Udp.Runtime;
using KissU.DotNetty.Udp.Runtime.Implementation;
using KissU.Modularity;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Udp
{
    /// <summary>
    /// DnsProtocolModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class UdpProtocolModule : EnginePartModule
    {
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.Register(provider =>
            {
                return new DefaultUdpServiceEntryProvider(
                    provider.Resolve<IServiceEntryManager>(),
                    provider.Resolve<ILogger<DefaultUdpServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IUdpServiceEntryProvider)).SingleInstance();
            builder.RegisterType(typeof(UdpServiceExecutor)).As(typeof(IServiceExecutor))
                .Named<IServiceExecutor>(CommunicationProtocol.Udp.ToString()).SingleInstance();
            if (AppConfig.ServerOptions.Protocols.Contains(nameof(CommunicationProtocol.Udp))  || AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.None))
            {
                RegisterDefaultProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyUdpServerMessageListener(
                    provider.Resolve<ILogger<DotNettyUdpServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Udp.ToString());
                var messageListener = provider.Resolve<DotNettyUdpServerMessageListener>();
                return new UdpServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }
    }
}
