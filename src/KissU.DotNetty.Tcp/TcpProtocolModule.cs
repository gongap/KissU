using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport.Codec;
using KissU.Dependency;
using KissU.DotNetty.Tcp.Runtime;
using KissU.DotNetty.Tcp.Runtime.Implementation;
using KissU.DotNetty.Udp;
using KissU.Modularity;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Tcp
{
    /// <summary>
    /// TcpProtocolModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class TcpProtocolModule : EnginePartModule
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
                return new DefaultTcpServiceEntryProvider(
                    provider.Resolve<IServiceEntryManager>(),
                    provider.Resolve<ILogger<DefaultTcpServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(ITcpServiceEntryProvider)).SingleInstance();
            builder.RegisterType(typeof(TcpServiceExecutor)).As(typeof(IServiceExecutor)).Named<IServiceExecutor>(CommunicationProtocol.Tcp.ToString()).SingleInstance();
            if (AppConfig.ServerOptions.Protocols.Contains(nameof(CommunicationProtocol.Tcp)) || AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.None))
            {
                RegisterDefaultProtocol(builder);
            }
        }

        private void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyTcpServerMessageListener(provider.Resolve<ILogger<DotNettyTcpServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>());
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Tcp.ToString());
                var messageListener = provider.Resolve<DotNettyTcpServerMessageListener>();
                return new TcpServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }
    }
}
