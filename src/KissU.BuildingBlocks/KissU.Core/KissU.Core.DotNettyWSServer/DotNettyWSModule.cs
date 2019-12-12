using Autofac;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Runtime.Server.Implementation;
using KissU.Core.DotNettyWSServer.Runtime;
using KissU.Core.DotNettyWSServer.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Core.DotNettyWSServer
{
    public class DotNettyWSModule : EnginePartModule
    {
        public override void Initialize(AppModuleContext serviceProvider)
        {
            base.Initialize(serviceProvider);
        }

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
