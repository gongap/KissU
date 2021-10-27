using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Libuv;
using KissU.Address;
using KissU.CPlatform;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;
using KissU.CPlatform.Transport.Implementation;
using KissU.DotNetty.Adapter;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty
{
    /// <summary>
    /// 基于DotNetty的传输客户端工厂。
    /// </summary>
    public class DotNettyTransportClientFactory : ITransportClientFactory, IDisposable
    {
        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var client in _clients.Values)
            {
                (client as IDisposable)?.Dispose();
            }
        }

        #endregion Implementation of IDisposable

        #region Implementation of ITransportClientFactory

        /// <summary>
        /// 创建客户端。
        /// </summary>
        /// <param name="endPoint">终结点。</param>
        /// <returns>传输客户端实例。</returns>
        public async Task<ITransportClient> CreateClientAsync(EndPoint endPoint)
        {
            var key = endPoint;
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace($"准备为服务端地址：{key}创建客户端。");
            try
            {
                return await _clients.GetOrAdd(key
                    , k => new Lazy<Task<ITransportClient>>(async () =>
                        {
                            //客户端对象
                            var bootstrap = _bootstrap;
                            //异步连接返回channel
                            var channel = await bootstrap.ConnectAsync(k);
                            var messageListener = new MessageListener();
                            //设置监听
                            channel.GetAttribute(messageListenerKey).Set(messageListener);
                            //实例化发送者
                            var messageSender = new DotNettyMessageClientSender(_transportMessageEncoder, channel);
                            //设置channel属性
                            channel.GetAttribute(messageSenderKey).Set(messageSender);
                            channel.GetAttribute(origEndPointKey).Set(k);
                            //创建客户端
                            var client = new TransportClient(messageSender, messageListener, _logger, _serviceExecutor);
                            return client;
                        }
                    )).Value; //返回实例
            }
            catch
            {
                //移除
                _clients.TryRemove(key, out var value);
                var ipEndPoint = endPoint as IPEndPoint;
                //标记这个地址是失败的请求
                if (ipEndPoint != null)
                    await _healthCheckService.MarkFailure(new IpAddressModel(ipEndPoint.Address.ToString(),
                        ipEndPoint.Port));
                throw;
            }
        }

        #endregion Implementation of ITransportClientFactory

        private static Bootstrap GetBootstrap()
        {
            IEventLoopGroup group;

            var bootstrap = new Bootstrap();
            if (AppConfig.ServerOptions.Libuv)
            {
                group = new EventLoopGroup();
                bootstrap.Channel<TcpServerChannel>();
            }
            else
            {
                group = new MultithreadEventLoopGroup();
                bootstrap.Channel<TcpServerSocketChannel>();
            }

            bootstrap
                .Channel<TcpSocketChannel>()
                .Option(ChannelOption.TcpNodelay, true)
                .Option(ChannelOption.Allocator, PooledByteBufferAllocator.Default)
                .Group(group);

            return bootstrap;
        }

        /// <summary>
        /// DefaultChannelHandler.
        /// Implements the <see cref="ChannelHandlerAdapter" />
        /// </summary>
        /// <seealso cref="ChannelHandlerAdapter" />
        protected class DefaultChannelHandler : ChannelHandlerAdapter
        {
            private readonly DotNettyTransportClientFactory _factory;

            /// <summary>
            /// Initializes a new instance of the <see cref="DefaultChannelHandler" /> class.
            /// </summary>
            /// <param name="factory">The factory.</param>
            public DefaultChannelHandler(DotNettyTransportClientFactory factory)
            {
                _factory = factory;
            }

            #region Overrides of ChannelHandlerAdapter

            /// <summary>
            /// Channels the inactive.
            /// </summary>
            /// <param name="context">The context.</param>
            public override void ChannelInactive(IChannelHandlerContext context)
            {
                _factory._clients.TryRemove(context.Channel.GetAttribute(origEndPointKey).Get(), out var value);
            }

            /// <summary>
            /// Channels the read.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="message">The message.</param>
            public override void ChannelRead(IChannelHandlerContext context, object message)
            {
                var transportMessage = message as TransportMessage;

                var messageListener = context.Channel.GetAttribute(messageListenerKey).Get();
                var messageSender = context.Channel.GetAttribute(messageSenderKey).Get();
                messageListener.OnReceived(messageSender, transportMessage);
            }

            #endregion Overrides of ChannelHandlerAdapter
        }

        #region Field

        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly ILogger<DotNettyTransportClientFactory> _logger;
        private readonly IServiceExecutor _serviceExecutor;
        private readonly IHealthCheckService _healthCheckService;

        private readonly ConcurrentDictionary<EndPoint, Lazy<Task<ITransportClient>>> _clients =
            new ConcurrentDictionary<EndPoint, Lazy<Task<ITransportClient>>>();

        private readonly Bootstrap _bootstrap;

        private static readonly AttributeKey<IMessageSender> messageSenderKey =
            AttributeKey<IMessageSender>.ValueOf(typeof(DotNettyTransportClientFactory), nameof(IMessageSender));

        private static readonly AttributeKey<IMessageListener> messageListenerKey =
            AttributeKey<IMessageListener>.ValueOf(typeof(DotNettyTransportClientFactory), nameof(IMessageListener));

        private static readonly AttributeKey<EndPoint> origEndPointKey =
            AttributeKey<EndPoint>.ValueOf(typeof(DotNettyTransportClientFactory), nameof(EndPoint));

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyTransportClientFactory" /> class.
        /// </summary>
        /// <param name="codecFactory">The codec factory.</param>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="logger">The logger.</param>
        public DotNettyTransportClientFactory(ITransportMessageCodecFactory codecFactory,
            IHealthCheckService healthCheckService, ILogger<DotNettyTransportClientFactory> logger)
            : this(codecFactory, healthCheckService, logger, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyTransportClientFactory" /> class.
        /// </summary>
        /// <param name="codecFactory">The codec factory.</param>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceExecutor">The service executor.</param>
        public DotNettyTransportClientFactory(ITransportMessageCodecFactory codecFactory,
            IHealthCheckService healthCheckService, ILogger<DotNettyTransportClientFactory> logger,
            IServiceExecutor serviceExecutor)
        {
            _transportMessageEncoder = codecFactory.GetEncoder();
            _transportMessageDecoder = codecFactory.GetDecoder();
            _logger = logger;
            _healthCheckService = healthCheckService;
            _serviceExecutor = serviceExecutor;
            _bootstrap = GetBootstrap();
            _bootstrap.Handler(new ActionChannelInitializer<ISocketChannel>(c =>
            {
                var pipeline = c.Pipeline;
                pipeline.AddLast(new LengthFieldPrepender(4));
                pipeline.AddLast(new LengthFieldBasedFrameDecoder(int.MaxValue, 0, 4, 0, 4));
                pipeline.AddLast(new TransportMessageChannelHandlerAdapter(_transportMessageDecoder));
                pipeline.AddLast(new DefaultChannelHandler(this));
            }));
        }

        #endregion Constructor
    }
}