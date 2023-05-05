using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.Dependency;
using KissU.DotNetty.WebSocket.Runtime;
using KissU.DotNetty.WebSocket.Runtime.Implementation;
using KissU.Modularity;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.WebSocket
{
    /// <summary>
    /// DotNettyWSModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class DotNettyWSModule : EnginePartModule
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.Register(provider =>
            {
                return new DefaultWSServiceEntryProvider(
                    provider.Resolve<IServiceEntryManager>(),
                    provider.Resolve<ILogger<DefaultWSServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IWSServiceEntryProvider)).SingleInstance();
            if (AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.WS))
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.None) || AppConfig.ServerOptions.Protocols.Contains(nameof(CommunicationProtocol.WS)))
            {
                RegisterWSProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyWSMessageListener(
                    provider.Resolve<ILogger<DotNettyWSMessageListener>>(),
                    provider.Resolve<IWSServiceEntryProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<DotNettyWSMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, null);
            }).As<IServiceHost>();
        }

        private static void RegisterWSProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyWSMessageListener(provider.Resolve<ILogger<DotNettyWSMessageListener>>(),
                    provider.Resolve<IWSServiceEntryProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<DotNettyWSMessageListener>();
                return new WSServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                });
            }).As<IServiceHost>();
        }
    }
}
