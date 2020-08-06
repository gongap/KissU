using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Ids;
using KissU.CPlatform.Mqtt;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.Dependency;
using KissU.DotNetty.Mqtt.Diagnostics;
using KissU.DotNetty.Mqtt.Implementation;
using KissU.DotNetty.Mqtt.Internal.Runtime;
using KissU.DotNetty.Mqtt.Internal.Runtime.Implementation;
using KissU.DotNetty.Mqtt.Internal.Services;
using KissU.DotNetty.Mqtt.Internal.Services.Implementation;
using KissU.Modularity;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Mqtt
{
    /// <summary>
    /// MqttProtocolModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class MqttProtocolModule : EnginePartModule
    {
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<MqttTransportDiagnosticProcessor>().As<ITracingDiagnosticProcessor>().SingleInstance();
            builder.RegisterType(typeof(DefaultMqttServiceFactory)).As(typeof(IMqttServiceFactory)).SingleInstance();
            builder.RegisterType(typeof(DefaultMqttBrokerEntryManager)).As(typeof(IMqttBrokerEntryManger))
                .SingleInstance();
            builder.RegisterType(typeof(MqttRemoteInvokeService)).As(typeof(IMqttRemoteInvokeService)).SingleInstance();
            builder.Register(provider =>
            {
                return new WillService(
                    provider.Resolve<ILogger<WillService>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As<IWillService>().SingleInstance();
            builder.Register(provider => { return new MessagePushService(new SacnScheduled()); })
                .As<IMessagePushService>().SingleInstance();
            builder.RegisterType(typeof(ClientSessionService)).As(typeof(IClientSessionService)).SingleInstance();
            builder.Register(provider =>
            {
                return new MqttChannelService(
                    provider.Resolve<IMessagePushService>(),
                    provider.Resolve<IClientSessionService>(),
                    provider.Resolve<ILogger<MqttChannelService>>(),
                    provider.Resolve<IWillService>(),
                    provider.Resolve<IMqttBrokerEntryManger>(),
                    provider.Resolve<IMqttRemoteInvokeService>(),
                    provider.Resolve<IServiceIdGenerator>()
                );
            }).As(typeof(IChannelService)).SingleInstance();
            builder.RegisterType(typeof(DefaultMqttBehaviorProvider)).As(typeof(IMqttBehaviorProvider))
                .SingleInstance();

            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.Mqtt)
            {
                RegisterDefaultProtocol(builder);
            }
            else if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterMqttProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyMqttServerMessageListener(
                    provider.Resolve<ILogger<DotNettyMqttServerMessageListener>>(),
                    provider.Resolve<IChannelService>(),
                    provider.Resolve<IMqttBehaviorProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<DotNettyMqttServerMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, null);
            }).As<IServiceHost>();
        }

        private static void RegisterMqttProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyMqttServerMessageListener(
                    provider.Resolve<ILogger<DotNettyMqttServerMessageListener>>(),
                    provider.Resolve<IChannelService>(),
                    provider.Resolve<IMqttBehaviorProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var messageListener = provider.Resolve<DotNettyMqttServerMessageListener>();
                return new MqttServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                });
            }).As<IServiceHost>();
        }
    }
}