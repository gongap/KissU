using Autofac;
using KissU.Core;
using KissU.Core.Dependency;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.CPlatform.Runtime.Server.Implementation;
using KissU.Surging.DotNettyWSServer.Runtime;
using KissU.Surging.DotNettyWSServer.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.DotNettyWSServer
{
    /// <summary>
    /// DotNettyWSModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class DotNettyWSModule : EnginePartModule
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
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.Register(provider =>
            {
                return new DefaultWSServiceEntryProvider(
                    provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultWSServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IWSServiceEntryProvider)).SingleInstance();
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.WS)
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
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