using Autofac;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Module;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Transport.Codec;
using KissU.Surging.Protocol.Udp.Runtime;
using KissU.Surging.Protocol.Udp.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Protocol.Udp
{
    /// <summary>
    /// DnsProtocolModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class DnsProtocolModule : EnginePartModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public override void Initialize(AppModuleContext serviceProvider)
        {
            base.Initialize(serviceProvider);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.Register(provider =>
            {
                return new DefaultUdpServiceEntryProvider(
                    provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultUdpServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IUdpServiceEntryProvider)).SingleInstance();
            builder.RegisterType(typeof(UdpServiceExecutor)).As(typeof(IServiceExecutor))
                .Named<IServiceExecutor>(CommunicationProtocol.Udp.ToString()).SingleInstance();
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.Dns)
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterUdpProtocol(builder);
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

        private static void RegisterUdpProtocol(ContainerBuilderWrapper builder)
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