using System;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Libuv;
using KissU.CPlatform;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;
using KissU.DotNetty.Adapter;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Tcp
{
    /// <summary>
    /// DotNettyTcpServerMessageListener.
    /// Implements the <see cref="KissU.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class DotNettyTcpServerMessageListener : IMessageListener, IDisposable
    {
        /// <summary>
        /// ServerHandler.
        /// Implements the
        /// <see
        ///     cref="DatagramPacket" />
        /// </summary>
        /// <seealso
        ///     cref="DatagramPacket" />
        private class ServerHandler : ChannelHandlerAdapter
        {
            private readonly ILogger _logger;

            private readonly Action<IChannelHandlerContext, TransportMessage> _readAction;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServerHandler" /> class.
            /// </summary>
            /// <param name="readAction">The read action.</param>
            /// <param name="logger">The logger.</param>
            /// <param name="serializer">The serializer.</param>
            public ServerHandler(Action<IChannelHandlerContext, TransportMessage> readAction, ILogger logger)
            {
                _readAction = readAction;
                _logger = logger;
            }

            #region Overrides of ChannelHandlerAdapter

            /// <summary>
            /// Channels the read.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="message">The message.</param>
            public override void ChannelRead(IChannelHandlerContext context, object message)
            {
                var transportMessage = (TransportMessage)message;
                _readAction(context, transportMessage); 
            }

            /// <summary>
            /// Channels the read complete.
            /// </summary>
            /// <param name="context">The context.</param>
            public override void ChannelReadComplete(IChannelHandlerContext context)
            {
                context.Flush();
            }

            /// <summary>
            /// Exceptions the caught.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="exception">The exception.</param>
            public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
            {
                context.CloseAsync(); //客户端主动断开需要应答，否则socket变成CLOSE_WAIT状态导致socket资源耗尽
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError(exception, $"与服务器：{context.Channel.RemoteAddress}通信时发送了错误：{exception.StackTrace}");
            }

            #endregion Overrides of ChannelHandlerAdapter
        }

        #region Field

        private readonly ILogger<DotNettyTcpServerMessageListener> _logger;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private IChannel _channel;

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

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyTcpServerMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="codecFactory">The codec factory.</param>
        public DotNettyTcpServerMessageListener(ILogger<DotNettyTcpServerMessageListener> logger
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
                _logger.LogDebug($"准备启动Tcp服务主机, 监听端口: {endPoint}");

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
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    OnNewClientAccepted(channel.RemoteAddress);
                    var pipeline = channel.Pipeline;
                    pipeline.AddLast(workerGroup, "HandlerAdapter", new TransportMessageChannelHandlerAdapter(_transportMessageDecoder));
                    pipeline.AddLast(workerGroup, "ServerHandler", new ServerHandler(async (contenxt, message) =>
                    {
                        var sender = new DotNettyTcpServerMessageSender(_transportMessageEncoder, contenxt);
                        await OnReceived(sender, message);
                    }, _logger));
                }));
            try
            {
                _channel = await bootstrap.BindAsync(endPoint);
                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation($"Tcp服务主机已启动, 监听端口:{endPoint}");
            }
            catch
            {
                _logger.LogError($"Tcp服务主机启动失败, 监听端口: {endPoint} ");
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
