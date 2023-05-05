using Autofac;
using KissU.Dependency;
using KissU.Modularity;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;
using KissU.Thrift.Runtime;
using KissU.Thrift.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Thrift
{
    class ThriftModule : EnginePartModule
    {
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.Register(provider =>
            {
                IServiceExecutor serviceExecutor = null;
                if (provider.IsRegistered(typeof(IServiceExecutor)))
                    serviceExecutor = provider.Resolve<IServiceExecutor>();
                return new ThriftTransportClientFactory(provider.Resolve<ITransportMessageCodecFactory>(),
                      provider.Resolve<IHealthCheckService>(),
                    provider.Resolve<ILogger<ThriftTransportClientFactory>>(),
                    serviceExecutor);
            }).As(typeof(ITransportClientFactory)).SingleInstance();
            builder.Register(provider =>
            {
                return new DefaultThriftServiceEntryProvider(
                       provider.Resolve<IServiceEntryManager>(),
                    provider.Resolve<ILogger<DefaultThriftServiceEntryProvider>>(),
                      provider.Resolve<CPlatformContainer>()
                      );
            }).As(typeof(IThriftServiceEntryProvider)).SingleInstance();
            if (AppConfig.ServerOptions.Protocols.Contains(nameof(CommunicationProtocol.Rpc))  || AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.None))
            {
                RegisterDefaultProtocol(builder);
            }
        }

        private void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new ThriftServerMessageListener(provider.Resolve<ILogger<ThriftServerMessageListener>>(),
                    provider.Resolve<IThriftServiceEntryProvider>(),
                      provider.Resolve<ITransportMessageCodecFactory>());
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Rpc.ToString());
                var messageListener = provider.Resolve<ThriftServerMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }
    }
}
