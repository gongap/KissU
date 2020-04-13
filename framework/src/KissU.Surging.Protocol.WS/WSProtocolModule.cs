using Autofac;
using KissU.Core;
using KissU.Core.Dependency;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Runtime.Server.Implementation;
using KissU.Surging.Protocol.WS.Configurations;
using KissU.Surging.Protocol.WS.Runtime;
using KissU.Surging.Protocol.WS.Runtime.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Protocol.WS
{
    /// <summary>
    /// WSProtocolModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class WSProtocolModule : EnginePartModule
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
            var options = new WebSocketOptions();
            var section = AppConfig.GetSection("WebSocket");
            if (section.Exists())
                options = section.Get<WebSocketOptions>();
            base.RegisterBuilder(builder);
            builder.Register(provider =>
            {
                return new DefaultWSServiceEntryProvider(
                    provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultWSServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>(),
                    options
                );
            }).As(typeof(IWSServiceEntryProvider)).SingleInstance();
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.WS)
            {
                RegisterDefaultProtocol(builder, options);
            }
            else if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterWSProtocol(builder, options);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder, WebSocketOptions options)
        {
            builder.Register(provider =>
            {
                return new DefaultWSServerMessageListener(
                    provider.Resolve<ILogger<DefaultWSServerMessageListener>>(),
                    provider.Resolve<IWSServiceEntryProvider>(),
                    options
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<DefaultWSServerMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, null);
            }).As<IServiceHost>();
        }

        private static void RegisterWSProtocol(ContainerBuilderWrapper builder, WebSocketOptions options)
        {
            builder.Register(provider =>
            {
                return new DefaultWSServerMessageListener(provider.Resolve<ILogger<DefaultWSServerMessageListener>>(),
                    provider.Resolve<IWSServiceEntryProvider>(),
                    options
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<DefaultWSServerMessageListener>();
                return new WSServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                });
            }).As<IServiceHost>();
        }
    }
}