using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs.Mqtt;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Libuv;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.DotNetty.Mqtt.Implementation;
using KissU.DotNetty.Mqtt.Internal.Runtime;
using KissU.DotNetty.Mqtt.Internal.Services;
using Microsoft.Extensions.Logging;
using TransportType = KissU.CPlatform.Diagnostics.TransportType;

namespace KissU.DotNetty.Mqtt
{
    /// <summary>
    /// DotNettyMqttServerMessageListener.
    /// Implements the <see cref="KissU.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class DotNettyMqttServerMessageListener : IMessageListener, IDisposable
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyMqttServerMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="channelService">The channel service.</param>
        /// <param name="mqttBehaviorProvider">The MQTT behavior provider.</param>
        public DotNettyMqttServerMessageListener(ILogger<DotNettyMqttServerMessageListener> logger,
            IChannelService channelService,
            IMqttBehaviorProvider mqttBehaviorProvider)
        {
            _logger = logger;
            _channelService = channelService;
            _mqttBehaviorProvider = mqttBehaviorProvider; 
            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Mqtt));
        }

        #endregion

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            _channel.CloseAsync();
        }

        /// <summary>
        /// 接收到消息的事件。
        /// </summary>
        public event ReceivedDelegate Received;

        /// <summary>
        /// 新的客户端连接事件
        /// </summary>
        public event NewClientAcceptHandler NewClientAccepted;

        /// <summary>
        /// 触发新的客户端连接事件。
        /// </summary>
        /// <param name="remoteAddress">远程地址</param>
        public void OnNewClientAccepted(EndPoint remoteAddress)   
        {
            if (NewClientAccepted == null)
                return;
            NewClientAccepted(remoteAddress);
        }

        /// <summary>
        /// 触发接收到消息事件。
        /// </summary>
        /// <param name="sender">消息发送者。</param>
        /// <param name="message">接收到的消息。</param>
        /// <returns>一个任务。</returns>
        public async Task OnReceived(IMessageSender sender, TransportMessage message)
        {
            if (Received == null)
                return;
            await Received(sender, message);
        }

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        public async Task StartAsync(EndPoint endPoint)
        {
            var ipEndPoint = endPoint as IPEndPoint;
            if (ipEndPoint.Port == 0)
            {
                return;
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"准备启动Mqtt服务主机, 监听端口: {endPoint}");
            }

            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup
                workerGroup =
                    new MultithreadEventLoopGroup(); //Default eventLoopCount is Environment.ProcessorCount * 2
            var bootstrap = new ServerBootstrap();
            if (AppConfig.ServerOptions.Libuv)
            {
                var dispatcher = new DispatcherEventLoopGroup();
                bossGroup = dispatcher;
                workerGroup = new WorkerEventLoopGroup(dispatcher);
                bootstrap.Channel<TcpServerChannel>();
            }
            else
            {
                bossGroup = new MultithreadEventLoopGroup(1);
                workerGroup = new MultithreadEventLoopGroup();
                bootstrap.Channel<TcpServerSocketChannel>();
            }

            bootstrap
                .Option(ChannelOption.SoBacklog, AppConfig.ServerOptions.SoBacklog)
                .ChildOption(ChannelOption.Allocator, PooledByteBufferAllocator.Default)
                .Group(bossGroup, workerGroup)
                .Option(ChannelOption.TcpNodelay, true)
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    var pipeline = channel.Pipeline;
                    pipeline.AddLast(MqttEncoder.Instance,
                        new MqttDecoder(true, 256 * 1024), new ServerHandler(async (context, packetType, message) =>
                        {
                            var mqttHandlerService =
                                new ServerMqttHandlerService(_logger, _channelService, _mqttBehaviorProvider);
                            await ChannelWrite(context, message, packetType, mqttHandlerService);
                        }, _logger, _channelService, _mqttBehaviorProvider));
                }));
            try
            {
                _channel = await bootstrap.BindAsync(endPoint);
                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation($"Mqtt主机已启动, 监听端口:{endPoint}");
            }
            catch
            {
                _logger.LogError($"Mqtt服务主机启动失败, 监听端口: {endPoint} ");
            }
        }

        /// <summary>
        /// Channels the write.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message.</param>
        /// <param name="packetType">Type of the packet.</param>
        /// <param name="mqttHandlerService">The MQTT handler service.</param>
        public async Task ChannelWrite(IChannelHandlerContext context, object message, PacketType packetType,
            ServerMqttHandlerService mqttHandlerService)
        {
            switch (packetType)
            {
                case PacketType.CONNECT:
                    await mqttHandlerService.Login(context, message as ConnectPacket);
                    break;
                case PacketType.PUBLISH:
                    await mqttHandlerService.Publish(context, message as PublishPacket);
                    break;
                case PacketType.PUBACK:
                    await mqttHandlerService.PubAck(context, message as PubAckPacket);
                    break;
                case PacketType.PUBREC:
                    await mqttHandlerService.PubRec(context, message as PubRecPacket);
                    break;
                case PacketType.PUBREL:
                    await mqttHandlerService.PubRel(context, message as PubRelPacket);
                    break;
                case PacketType.PUBCOMP:
                    await mqttHandlerService.PubComp(context, message as PubCompPacket);
                    break;
                case PacketType.SUBSCRIBE:
                    await mqttHandlerService.Subscribe(context, message as SubscribePacket);
                    break;
                case PacketType.SUBACK:
                    await mqttHandlerService.SubAck(context, message as SubAckPacket);
                    break;
                case PacketType.UNSUBSCRIBE:
                    await mqttHandlerService.Unsubscribe(context, message as UnsubscribePacket);
                    break;
                case PacketType.UNSUBACK:
                    await mqttHandlerService.UnsubAck(context, message as UnsubAckPacket);
                    break;
                case PacketType.PINGREQ:
                    await mqttHandlerService.PingReq(context, message as PingReqPacket);
                    break;
                case PacketType.PINGRESP:
                    await mqttHandlerService.PingResp(context, message as PingRespPacket);
                    break;
                case PacketType.DISCONNECT:
                    await mqttHandlerService.Disconnect(context, message as DisconnectPacket);
                    break;
            }
        }

        private void WirteDiagnosticError(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var remoteInvokeResultMessage = message.GetContent<RemoteInvokeResultMessage>();
                _diagnosticListener.WriteTransportError(TransportType.Mqtt, new TransportErrorEventData(new DiagnosticMessage
                {
                        Content = message.Content,
                        ContentType = message.ContentType,
                        Id = message.Id
                    }, new Exception(remoteInvokeResultMessage.Message)));
            }
        }

        /// <summary>
        /// ServerHandler.
        /// Implements the <see cref="ChannelHandlerAdapter" />
        /// </summary>
        /// <seealso cref="ChannelHandlerAdapter" />
        private class ServerHandler : ChannelHandlerAdapter
        {
            private readonly ILogger _logger;
            private readonly Action<IChannelHandlerContext, PacketType, object> _readAction;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServerHandler" /> class.
            /// </summary>
            /// <param name="readAction">The read action.</param>
            /// <param name="logger">The logger.</param>
            /// <param name="channelService">The channel service.</param>
            /// <param name="mqttBehaviorProvider">The MQTT behavior provider.</param>
            public ServerHandler(Action<IChannelHandlerContext, PacketType, object> readAction,
                ILogger logger,
                IChannelService channelService,
                IMqttBehaviorProvider mqttBehaviorProvider)
            {
                _readAction = readAction;
                _logger = logger;
            }

            /// <summary>
            /// Channels the read.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="message">The message.</param>
            public override void ChannelRead(IChannelHandlerContext context, object message)
            {
                var buffer = message as Packet;
                _readAction(context, buffer.PacketType, buffer);
                ReferenceCountUtil.Release(message);
            }

            /// <summary>
            /// Channels the inactive.
            /// </summary>
            /// <param name="context">The context.</param>
            public override void ChannelInactive(IChannelHandlerContext context)
            {
                SetException(new InvalidOperationException("Channel is closed."));
                base.ChannelInactive(context);
            }

            /// <summary>
            /// Exceptions the caught.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="exception">The exception.</param>
            public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
            {
                _readAction.Invoke(context, PacketType.DISCONNECT, DisconnectPacket.Instance);
                SetException(exception);
            }

            private void SetException(Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError($"message:{ex.Message},Source:{ex.Source},Trace:{ex.StackTrace}");
            }
        }

        #region Field

        private readonly ILogger<DotNettyMqttServerMessageListener> _logger;
        private IChannel _channel;
        private readonly IChannelService _channelService;
        private readonly IMqttBehaviorProvider _mqttBehaviorProvider;
        private readonly DiagnosticListener _diagnosticListener;

        #endregion Field
    }
}
