using Autofac;
using KissU.Modularity;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Runtime.Client.HealthChecks;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Runtime.Server.Implementation;
using KissU.Surging.CPlatform.Transport;
using KissU.Surging.CPlatform.Transport.Codec;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.DotNetty
{
    /// <summary>
    /// DotNettyModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class DotNettyModule : EnginePartModule
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
                IServiceExecutor serviceExecutor = null;
                if (provider.IsRegistered(typeof(IServiceExecutor)))
                    serviceExecutor = provider.Resolve<IServiceExecutor>();
                return new DotNettyTransportClientFactory(provider.Resolve<ITransportMessageCodecFactory>(),
                    provider.Resolve<IHealthCheckService>(),
                    provider.Resolve<ILogger<DotNettyTransportClientFactory>>(),
                    serviceExecutor);
            }).As(typeof(ITransportClientFactory)).SingleInstance();
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
                return new DotNettyServerMessageListener(provider.Resolve<ILogger<DotNettyServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>());
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Tcp.ToString());
                var messageListener = provider.Resolve<DotNettyServerMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }
    }
}