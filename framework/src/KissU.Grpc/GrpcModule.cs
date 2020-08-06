using Autofac;

using KissU.Dependency;
using KissU.Modularity;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.Grpc.Runtime;
using KissU.Grpc.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Grpc
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