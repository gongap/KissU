﻿using Autofac;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Transport.Codec;
using KissU.Core.DNS.Configurations;
using KissU.Core.DNS.Runtime;
using KissU.Core.DNS.Runtime.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KissU.Core.DNS
{
    /// <summary>
    /// DnsProtocolModule.
    /// Implements the <see cref="KissU.Core.CPlatform.Module.EnginePartModule" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Module.EnginePartModule" />
    public class DnsProtocolModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
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
                return new DotNettyDnsServerMessageListener(provider.Resolve<ILogger<DotNettyDnsServerMessageListener>>(),
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
                return new DotNettyDnsServerMessageListener(provider.Resolve<ILogger<DotNettyDnsServerMessageListener>>(),
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
