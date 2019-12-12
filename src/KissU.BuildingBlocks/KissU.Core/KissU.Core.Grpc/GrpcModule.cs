using Autofac;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Runtime.Server.Implementation;
using KissU.Core.Grpc.Runtime;
using KissU.Core.Grpc.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Grpc
{
    public  class GrpcModule : EnginePartModule
    { 
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }
 
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DefaultGrpcServiceEntryProvider(
                       provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultGrpcServiceEntryProvider>>(),
                      provider.Resolve<CPlatformContainer>()
                      );
            }).As(typeof(IGrpcServiceEntryProvider)).SingleInstance();
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.WS)
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterGrpcProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {

            builder.Register(provider =>
            {
                return new GrpcServerMessageListener(
                    provider.Resolve<ILogger<GrpcServerMessageListener>>(),
                      provider.Resolve<IGrpcServiceEntryProvider>()
                      );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<GrpcServerMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, null);

            }).As<IServiceHost>();
        }

        private static void RegisterGrpcProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new GrpcServerMessageListener(provider.Resolve<ILogger<GrpcServerMessageListener>>(),
                      provider.Resolve<IGrpcServiceEntryProvider>()
                      );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<GrpcServerMessageListener>();
                return new GrpcServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                });

            }).As<IServiceHost>();
        }
    }
}
 