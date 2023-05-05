using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.Dependency;
using KissU.GrpcTransport.Runtime;
using KissU.GrpcTransport.Runtime.Implementation;
using KissU.Modularity;
using Microsoft.Extensions.Logging;

namespace KissU.GrpcTransport
{
    /// <summary>
    /// GrpcModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class GrpcModule : EnginePartModule
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DefaultGrpcServiceEntryProvider(
                    provider.Resolve<IServiceEntryManager>(),
                    provider.Resolve<ILogger<DefaultGrpcServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IGrpcServiceEntryProvider)).SingleInstance();
            if (AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.GRPC))
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.None) || AppConfig.ServerOptions.Protocols.Contains(nameof(CommunicationProtocol.GRPC)))
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
