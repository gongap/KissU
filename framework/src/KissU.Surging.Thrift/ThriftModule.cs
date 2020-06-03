using Autofac;
using KissU.Dependency;
using KissU.Module;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Runtime.Client.HealthChecks;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Runtime.Server.Implementation;
using KissU.Surging.CPlatform.Transport;
using KissU.Surging.CPlatform.Transport.Codec;
using KissU.Surging.Thrift.Runtime;
using KissU.Surging.Thrift.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Thrift
{
    class ThriftModule : EnginePartModule
    {
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
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
                       provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultThriftServiceEntryProvider>>(),
                      provider.Resolve<CPlatformContainer>()
                      );
            }).As(typeof(IThriftServiceEntryProvider)).SingleInstance();
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.Tcp ||
                AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
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
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Tcp.ToString());
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
