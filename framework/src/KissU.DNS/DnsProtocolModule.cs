using Autofac;

using KissU.Dependency;
using KissU.Modularity;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport.Codec;
using KissU.DNS.Configurations;
using KissU.DNS.Runtime;
using KissU.DNS.Runtime.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KissU.DNS
{
    /// <summary>
    /// DnsProtocolModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class DnsProtocolModule : EnginePartModule
    {
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            var section = CPlatform.AppConfig.GetSection("Dns");
            if (section.Exists())
                AppConfig.DnsOption = section.Get<DnsOption>();
            builder.Register(provider =>
            {
                return new DefaultDnsServiceEntryProvider(
                    provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultDnsServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IDnsServiceEntryProvider)).SingleInstance();
            builder.RegisterType(typeof(DnsServiceExecutor)).As(typeof(IServiceExecutor))
                .Named<IServiceExecutor>(CommunicationProtocol.Dns.ToString()).SingleInstance();
            if (CPlatform.AppConfig.ServerOptions.Protocol == CommunicationProtocol.Dns)
            {
                RegisterDefaultProtocol(builder);
            }
            else if (CPlatform.AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterDnsProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyDnsServerMessageListener(
                    provider.Resolve<ILogger<DotNettyDnsServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Dns.ToString());
                var messageListener = provider.Resolve<DotNettyDnsServerMessageListener>();
                return new DnsServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }

        private static void RegisterDnsProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyDnsServerMessageListener(
                    provider.Resolve<ILogger<DotNettyDnsServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Dns.ToString());
                var messageListener = provider.Resolve<DotNettyDnsServerMessageListener>();
                return new DnsServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }
    }
}