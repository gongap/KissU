using System;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs;
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

namespace KissU.DotNetty
{
    /// <summary>
    /// DotNettyServerMessageListener.
    /// Implements the <see cref="KissU.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class DotNettyServerMessageListener : IMessageListener, IDisposable
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyServerMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="codecFactory">The codec factory.</param>
        public DotNettyServerMessageListener(ILogger<DotNettyServerMessageListener> logger,
            ITransportMessageCodecFactory codecFactory)
        {
            _logger = logger;
            _transportMessageEncoder = codecFactory.GetEncoder();
            _transportMessageDecoder = codecFactory.GetDecoder();
        }

        #endregion Constructor

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Task.Run(async () => { await _channel.DisconnectAsync(); }).Wait();
        }

        #endregion Implementation of IDisposable

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        public async Task StartAsync(EndPoint endPoint)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"准备启动服务主机，监听地址：{endPoint}。");

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
                    var pipeline = channel.Pipeline;
                    pipeline.AddLast(new LengthFieldPrepender(4));
                    pipeline.AddLast(new LengthFieldBasedFrameDecoder(int.MaxValue, 0, 4, 0, 4));
                    pipeline.AddLast(new TransportMessageChannelHandlerAdapter(_transportMessageDecoder));
                    pipeline.AddLast(new ServerHandler(async (contenxt, message) =>
                    {
                        var sender = new DotNettyServerMessageSender(_transportMessageEncoder, contenxt);
                        await OnReceived(sender, message);
                    }, _logger));
                }));
            try
            {
                _channel = await bootstrap.BindAsync(endPoint);
                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation($"服务主机启动成功，监听地址：{endPoint}。");
            }
            catch
            {
                _logger.LogError($"服务主机启动失败，监听地址：{endPoint}。 ");
            }
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

        #region Help Class

        /// <summary>
        /// ServerHandler.
        /// Implements the <see cref="ChannelHandlerAdapter" />
        /// </summary>
        /// <seealso cref="ChannelHandlerAdapter" />
        private class ServerHandler : ChannelHandlerAdapter
        {
            private readonly ILogger _logger;
            private readonly Action<IChannelHandlerContext, TransportMessage> _readAction;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServerHandler" /> class.
            /// </summary>
            /// <param name="readAction">The read action.</param>
            /// <param name="logger">The logger.</param>
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
                Task.Run(() =>
                {
                    var transportMessage = (TransportMessage) message;
                    _readAction(context, transportMessage);
                });
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
                    _logger.LogError(exception, $"与服务器：{context.Channel.RemoteAddress}通信时发送了错误。");
            }

            #endregion Overrides of ChannelHandlerAdapter
        }

        #endregion Help Class

        #region Field

        private readonly ILogger<DotNettyServerMessageListener> _logger;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private IChannel _channel;

        #endregion Field

        #region Implementation of IMessageListener

        /// <summary>
        /// 接收到消息的事件。
        /// </summary>
        public event ReceivedDelegate Received;

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

        #endregion Implementation of IMessageListener
    }
}