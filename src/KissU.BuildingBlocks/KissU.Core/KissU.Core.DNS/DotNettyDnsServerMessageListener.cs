using System;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Codecs.DNS;
using DotNetty.Codecs.DNS.Messages;
using DotNetty.Codecs.DNS.Records;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport;
using KissU.Core.CPlatform.Transport.Codec;
using Microsoft.Extensions.Logging;

namespace KissU.Core.DNS
{
    /// <summary>
    /// DotNettyDnsServerMessageListener.
    /// Implements the <see cref="KissU.Core.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    internal class DotNettyDnsServerMessageListener : IMessageListener, IDisposable
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyDnsServerMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="codecFactory">The codec factory.</param>
        public DotNettyDnsServerMessageListener(ILogger<DotNettyDnsServerMessageListener> logger,
            ITransportMessageCodecFactory codecFactory)
        {
            _logger = logger;
            _transportMessageEncoder = codecFactory.GetEncoder();
            _transportMessageDecoder = codecFactory.GetDecoder();
        }

        #endregion Constructor

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        public async Task StartAsync(EndPoint endPoint)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"准备启动服务主机，监听地址：{endPoint}。");

            var group = new MultithreadEventLoopGroup();
            var bootstrap = new Bootstrap();
            bootstrap
                .Group(group)
                .Channel<SocketDatagramChannel>()
                .Handler(new ActionChannelInitializer<IDatagramChannel>(channel =>
                {
                    var pipeline = channel.Pipeline;
                    pipeline.AddLast(new DatagramDnsQueryDecoder());
                    pipeline.AddLast(new DatagramDnsResponseEncoder());
                    pipeline.AddLast(new ServerHandler(async (contenxt, message) =>
                    {
                        var sender = new DotNettyDnsServerMessageSender(_transportMessageEncoder, contenxt);
                        await OnReceived(sender, message);
                    }, _logger));
                })).Option(ChannelOption.SoBroadcast, true);
            try
            {
                _channel = await bootstrap.BindAsync(endPoint);
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug($"DNS服务主机启动成功，监听地址：{endPoint}。");
            }
            catch
            {
                _logger.LogError($"DNS服务主机启动失败，监听地址：{endPoint}。 ");
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

        /// <summary>
        /// ServerHandler.
        /// Implements the
        /// <see cref="DotNetty.Transport.Channels.SimpleChannelInboundHandler{DotNetty.Codecs.DNS.Messages.DatagramDnsQuery}" />
        /// </summary>
        /// <seealso
        ///     cref="DotNetty.Transport.Channels.SimpleChannelInboundHandler{DotNetty.Codecs.DNS.Messages.DatagramDnsQuery}" />
        private class ServerHandler : SimpleChannelInboundHandler<DatagramDnsQuery>
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

            /// <summary>
            /// Channels the read0.
            /// </summary>
            /// <param name="ctx">The CTX.</param>
            /// <param name="query">The query.</param>
            protected override void ChannelRead0(IChannelHandlerContext ctx, DatagramDnsQuery query)
            {
                var response = new DatagramDnsResponse(query.Recipient, query.Sender, query.Id);
                var dnsQuestion = query.GetRecord<DefaultDnsQuestion>(DnsSection.QUESTION);
                response.AddRecord(DnsSection.QUESTION, dnsQuestion);
                _readAction(ctx, new TransportMessage(new DnsTransportMessage
                {
                    DnsResponse = response,
                    DnsQuestion = dnsQuestion
                }));
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
                    _logger.LogError(exception, $"与服务器：{context.Channel.RemoteAddress}通信时发送了错误。");
            }
        }

        #region Field

        private readonly ILogger<DotNettyDnsServerMessageListener> _logger;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private IChannel _channel;

        /// <summary>
        /// 接收到消息的事件。
        /// </summary>
        public event ReceivedDelegate Received;

        #endregion Field

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Task.Run(async () => { await _channel.DisconnectAsync(); }).Wait();
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

        #endregion Implementation of IDisposable
    }
}