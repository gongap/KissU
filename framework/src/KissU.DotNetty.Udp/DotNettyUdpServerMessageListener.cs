using System;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;
using KissU.Serialization;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Udp
{
    /// <summary>
    /// DotNettyUdpServerMessageListener.
    /// Implements the <see cref="KissU.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class DotNettyUdpServerMessageListener : IMessageListener, IDisposable
    {
        /// <summary>
        /// ServerHandler.
        /// Implements the
        /// <see
        ///     cref="DatagramPacket" />
        /// </summary>
        /// <seealso
        ///     cref="DatagramPacket" />
        private class ServerHandler : SimpleChannelInboundHandler<DatagramPacket>
        {
            private readonly ILogger _logger;

            private readonly Action<IChannelHandlerContext, TransportMessage> _readAction;
            private readonly ISerializer<string> _serializer;


            /// <summary>
            /// Initializes a new instance of the <see cref="ServerHandler" /> class.
            /// </summary>
            /// <param name="readAction">The read action.</param>
            /// <param name="logger">The logger.</param>
            /// <param name="serializer">The serializer.</param>
            public ServerHandler(Action<IChannelHandlerContext, TransportMessage> readAction, ILogger logger,
                ISerializer<string> serializer)
            {
                _readAction = readAction;
                _logger = logger;
                _serializer = serializer;
            }

            /// <summary>
            /// Channels the read0.
            /// </summary>
            /// <param name="ctx">The CTX.</param>
            /// <param name="msg">The MSG.</param>
            protected override void ChannelRead0(IChannelHandlerContext ctx, DatagramPacket msg)
            {
                var buff = msg.Content;
                var messageBytes = new byte[buff.ReadableBytes];
                buff.ReadBytes(messageBytes);
                _readAction(ctx, new TransportMessage(messageBytes));
            }

            /// <summary>
            /// Exceptions the caught.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="exception">The exception.</param>
            public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
            {
                context.CloseAsync();
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError(exception, $"与服务器：{context.Channel.RemoteAddress}通信时发送了错误：{exception.StackTrace}");
            }
        }

        #region Field

        private readonly ILogger<DotNettyUdpServerMessageListener> _logger;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private IChannel _channel;
        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// 接收到消息的事件。
        /// </summary>
        public event ReceivedDelegate Received;

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyUdpServerMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="codecFactory">The codec factory.</param>
        public DotNettyUdpServerMessageListener(ILogger<DotNettyUdpServerMessageListener> logger
            , ITransportMessageCodecFactory codecFactory)
        {
            _logger = logger;
            _transportMessageEncoder = codecFactory.GetEncoder();
            _transportMessageDecoder = codecFactory.GetDecoder();
        }

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        public async Task StartAsync(EndPoint endPoint)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"准备启动Udp服务主机, 监听端口: {endPoint}");

            var group = new MultithreadEventLoopGroup();
            var bootstrap = new Bootstrap();
            bootstrap
                .Group(group)
                .Channel<SocketDatagramChannel>()
                .Option(ChannelOption.SoBacklog, 1024)
                .Option(ChannelOption.SoSndbuf, 1024 * 4096 * 10)
                .Option(ChannelOption.SoRcvbuf, 1024 * 4096 * 10)
                .Handler(new ServerHandler(async (contenxt, message) =>
                    {
                        var sender = new DotNettyUdpServerMessageSender(_transportMessageEncoder, contenxt);
                        await OnReceived(sender, message);
                    }, _logger, _serializer)
                ).Option(ChannelOption.SoBroadcast, true);
            try
            {
                _channel = await bootstrap.BindAsync(endPoint);
                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation($"Udp服务主机已启动, 监听端口:{endPoint}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Udp服务主机启动失败, 监听端口: {endPoint} ");
            }
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
        /// Closes the asynchronous.
        /// </summary>
        public void CloseAsync()
        {
            Task.Run(async () =>
            {
                await _channel.EventLoop.ShutdownGracefullyAsync();
                await _channel.CloseAsync();
            }).Wait();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Task.Run(async () => { await _channel.DisconnectAsync(); }).Wait();
        }

        #endregion
    }
}