using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Codecs.Http;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Handlers.Streams;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Groups;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Libuv;
using KissU.CPlatform;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.DotNetty.WebSocket.Runtime;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.WebSocket
{
    /// <summary>
    /// DotNettyWSMessageListener.
    /// Implements the <see cref="KissU.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class DotNettyWSMessageListener : IMessageListener, IDisposable
    {
        /// <summary>
        /// WebSocketFrameDecoder.
        /// Implements the <see cref="WebSocketFrame" />
        /// </summary>
        /// <seealso cref="WebSocketFrame" />
        public class WebSocketFrameDecoder : MessageToMessageDecoder<WebSocketFrame>
        {
            /// <summary>
            /// Decodes the specified CTX.
            /// </summary>
            /// <param name="ctx">The CTX.</param>
            /// <param name="msg">The MSG.</param>
            /// <param name="output">The output.</param>
            protected override void Decode(IChannelHandlerContext ctx, WebSocketFrame msg, List<object> output)
            {
                var buff = msg.Content;
                var messageBytes = new byte[buff.ReadableBytes];
                buff.ReadBytes(messageBytes);
                var bytebuf = PooledByteBufferAllocator.Default.Buffer();
                bytebuf.WriteBytes(messageBytes);
                output.Add(bytebuf.Retain());
            }
        }

        /// <summary>
        /// WebSocketFramePrepender.
        /// Implements the <see cref="IByteBuffer" />
        /// </summary>
        /// <seealso cref="IByteBuffer" />
        public class WebSocketFramePrepender : MessageToMessageDecoder<IByteBuffer>
        {
            /// <summary>
            /// Decodes the specified CTX.
            /// </summary>
            /// <param name="ctx">The CTX.</param>
            /// <param name="msg">The MSG.</param>
            /// <param name="output">The output.</param>
            protected override void Decode(IChannelHandlerContext ctx, IByteBuffer msg, List<object> output)
            {
                WebSocketFrame webSocketFrame = new BinaryWebSocketFrame(msg);
                output.Add(webSocketFrame);
            }
        }


        /// <summary>
        /// ServerHandler.
        /// Implements the
        /// <see
        ///     cref="TextWebSocketFrame" />
        /// </summary>
        /// <seealso
        ///     cref="TextWebSocketFrame" />
        private class ServerHandler : SimpleChannelInboundHandler<TextWebSocketFrame>
        {
            private readonly ILogger _logger;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServerHandler" /> class.
            /// </summary>
            /// <param name="logger">The logger.</param>
            public ServerHandler(ILogger logger)
            {
                _logger = logger;
            }

            /// <summary>
            /// Channels the active.
            /// </summary>
            /// <param name="ctx">The CTX.</param>
            public override void ChannelActive(IChannelHandlerContext ctx)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("ws 连接 ctx:" + ctx);
                }

                if (PlayerGroup.ChannelGroup == null)
                {
                    PlayerGroup.ChannelGroup = new DefaultChannelGroup(ctx.Executor);
                }

                PlayerGroup.AddChannel(ctx.Channel);
            }

            /// <summary>
            /// Exceptions the caught.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="exception">The exception.</param>
            public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
            {
                context.CloseAsync();
                PlayerGroup.RemoveChannel(context.Channel);
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, $"与服务器：{context.Channel.RemoteAddress}通信时发送了错误。");
                }
            }

            /// <summary>
            /// Channels the read0.
            /// </summary>
            /// <param name="ctx">The CTX.</param>
            /// <param name="msg">The MSG.</param>
            protected override void ChannelRead0(IChannelHandlerContext ctx, TextWebSocketFrame msg)
            {
            }
        }

        #region Field

        private readonly ILogger<DotNettyWSMessageListener> _logger;
        private IChannel _channel;
        private readonly List<WSServiceEntry> _wSServiceEntries;

        /// <summary>
        /// 接收到消息的事件。
        /// </summary>
        public event ReceivedDelegate Received;

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyWSMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="wsServiceEntryProvider">The ws service entry provider.</param>
        public DotNettyWSMessageListener(ILogger<DotNettyWSMessageListener> logger
            , IWSServiceEntryProvider wsServiceEntryProvider)
        {
            _logger = logger;
            _wSServiceEntries = wsServiceEntryProvider.GetEntries().ToList();
        }

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        public async Task StartAsync(EndPoint endPoint)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"Prepare to start WS service host, listening on: {endPoint}");
            }

            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup(); //Default eventLoopCount is Environment.ProcessorCount * 2
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
                .ChildOption(ChannelOption.WriteBufferHighWaterMark, 1024 * 1024 * 8)
                .Group(bossGroup, workerGroup)
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    var pipeline = channel.Pipeline;
                    pipeline.AddLast("readTimeout", new ReadTimeoutHandler(45));
                    pipeline.AddLast("HttpServerCodec", new HttpServerCodec());
                    pipeline.AddLast("ChunkedWriter", new ChunkedWriteHandler<byte[]>());
                    pipeline.AddLast("HttpAggregator", new HttpObjectAggregator(65535));
                    _wSServiceEntries.ForEach(p =>
                    {
                        pipeline.AddLast("WsProtocolHandler",
                            new WebSocketServerProtocolHandler(p.Path, p.Behavior.Protocol, true));
                    });

                    pipeline.AddLast("WSBinaryDecoder", new WebSocketFrameDecoder());
                    pipeline.AddLast("WSEncoder", new WebSocketFramePrepender());
                    pipeline.AddLast(new ServerHandler(_logger));
                })).Option(ChannelOption.SoBroadcast, true);
            try
            {
                _channel = await bootstrap.BindAsync(endPoint);
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation($"WS service host started, listening on:{endPoint}");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"WS service host failed to start, listening on: {endPoint} ");
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
            {
                return;
            }

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