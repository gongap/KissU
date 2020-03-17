using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DotNetty.Codecs.Http;
using DotNetty.Common.Concurrency;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.CPlatform.Routing.Template;
using KissU.Surging.CPlatform.Serialization;
using KissU.Surging.CPlatform.Transport;
using KissU.Surging.CPlatform.Transport.Codec;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Protocol.Http
{
    /// <summary>
    /// DotNettyHttpServerMessageListener.
    /// Implements the <see cref="KissU.Surging.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    internal class DotNettyHttpServerMessageListener : IMessageListener, IDisposable
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNettyHttpServerMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="codecFactory">The codec factory.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        public DotNettyHttpServerMessageListener(ILogger<DotNettyHttpServerMessageListener> logger,
            ITransportMessageCodecFactory codecFactory,
            ISerializer<string> serializer,
            IServiceRouteProvider serviceRouteProvider)
        {
            _logger = logger;
            _transportMessageEncoder = codecFactory.GetEncoder();
            _transportMessageDecoder = codecFactory.GetDecoder();
            _serializer = serializer;
            _serviceRouteProvider = serviceRouteProvider;
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
            var serverCompletion = new TaskCompletionSource();
            var bossGroup = new MultithreadEventLoopGroup(1);
            var workerGroup =
                new MultithreadEventLoopGroup(); //Default eventLoopCount is Environment.ProcessorCount * 2
            var bootstrap = new ServerBootstrap();
            bootstrap
                .Group(bossGroup, workerGroup)
                .Channel<TcpServerSocketChannel>()
                .Option(ChannelOption.SoReuseport, true)
                .ChildOption(ChannelOption.SoReuseaddr, true)
                .Option(ChannelOption.SoBacklog, AppConfig.ServerOptions.SoBacklog)
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    var pipeline = channel.Pipeline;
                    pipeline.AddLast("encoder", new HttpResponseEncoder());
                    pipeline.AddLast(new HttpRequestDecoder(int.MaxValue, 8192, 8192, true));
                    pipeline.AddLast(new HttpObjectAggregator(int.MaxValue));
                    pipeline.AddLast(new ServerHandler(async (contenxt, message) =>
                    {
                        var sender =
                            new DotNettyHttpServerMessageSender(_transportMessageEncoder, contenxt, _serializer);
                        await OnReceived(sender, message);
                    }, _logger, _serializer, _serviceRouteProvider));
                    serverCompletion.TryComplete();
                }));
            try
            {
                _channel = await bootstrap.BindAsync(endPoint);
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug($"Http服务主机启动成功，监听地址：{endPoint}。");
            }
            catch
            {
                _logger.LogError($"Http服务主机启动失败，监听地址：{endPoint}。 ");
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
        /// Implements the
        /// <see cref="DotNetty.Transport.Channels.SimpleChannelInboundHandler{DotNetty.Codecs.Http.IFullHttpRequest}" />
        /// </summary>
        /// <seealso cref="DotNetty.Transport.Channels.SimpleChannelInboundHandler{DotNetty.Codecs.Http.IFullHttpRequest}" />
        private class ServerHandler : SimpleChannelInboundHandler<IFullHttpRequest>
        {
            private readonly ILogger _logger;

            private readonly Action<IChannelHandlerContext, TransportMessage> _readAction;
            private readonly ISerializer<string> _serializer;
            private readonly IServiceRouteProvider _serviceRouteProvider;
            private readonly TaskCompletionSource completion = new TaskCompletionSource();

            /// <summary>
            /// Initializes a new instance of the <see cref="ServerHandler" /> class.
            /// </summary>
            /// <param name="readAction">The read action.</param>
            /// <param name="logger">The logger.</param>
            /// <param name="serializer">The serializer.</param>
            /// <param name="serviceRouteProvider">The service route provider.</param>
            public ServerHandler(Action<IChannelHandlerContext, TransportMessage> readAction,
                ILogger logger,
                ISerializer<string> serializer,
                IServiceRouteProvider serviceRouteProvider)
            {
                _readAction = readAction;
                _logger = logger;
                _serializer = serializer;
                _serviceRouteProvider = serviceRouteProvider;
            }

            /// <summary>
            /// Waits for completion.
            /// </summary>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public bool WaitForCompletion()
            {
                completion.Task.Wait(TimeSpan.FromSeconds(5));
                return completion.Task.Status == TaskStatus.RanToCompletion;
            }

            /// <summary>
            /// Channels the read0.
            /// </summary>
            /// <param name="ctx">The CTX.</param>
            /// <param name="msg">The MSG.</param>
            protected override void ChannelRead0(IChannelHandlerContext ctx, IFullHttpRequest msg)
            {
                var data = new byte[msg.Content.ReadableBytes];
                msg.Content.ReadBytes(data);

                Task.Run(async () =>
                {
                    var parameters = GetParameters(HttpUtility.UrlDecode(msg.Uri), out var path);
                    var serviceRoute = await _serviceRouteProvider.GetRouteByPathRegex(path);
                    parameters.Remove("servicekey", out var serviceKey);
                    if (data.Length > 0)
                        parameters =
                            _serializer.Deserialize<string, IDictionary<string, object>>(
                                Encoding.ASCII.GetString(data)) ?? new Dictionary<string, object>();
                    if (string.Compare(serviceRoute.ServiceDescriptor.RoutePath, path, true) != 0)
                    {
                        var @params = RouteTemplateSegmenter.Segment(serviceRoute.ServiceDescriptor.RoutePath, path);
                        foreach (var param in @params)
                        {
                            parameters.Add(param.Key, param.Value);
                        }
                    }

                    if (msg.Method.Name == "POST")
                    {
                        _readAction(ctx, new TransportMessage(new HttpRequestMessage
                        {
                            Parameters = parameters,
                            RoutePath = serviceRoute.ServiceDescriptor.RoutePath,
                            ServiceKey = serviceKey?.ToString()
                        }));
                    }
                    else
                    {
                        _readAction(ctx, new TransportMessage(new HttpRequestMessage
                        {
                            Parameters = parameters,
                            RoutePath = serviceRoute.ServiceDescriptor.RoutePath,
                            ServiceKey = serviceKey?.ToString()
                        }));
                    }
                });
            }

            /// <summary>
            /// Gets the parameters.
            /// </summary>
            /// <param name="msg">The MSG.</param>
            /// <param name="routePath">The route path.</param>
            /// <returns>IDictionary&lt;System.String, System.Object&gt;.</returns>
            public IDictionary<string, object> GetParameters(string msg, out string routePath)
            {
                var urlSpan = msg.AsSpan();
                var len = urlSpan.IndexOf("?");
                if (len == -1)
                {
                    routePath = urlSpan.TrimStart("/").ToString().ToLower();
                    return new Dictionary<string, object>();
                }

                routePath = urlSpan.Slice(0, len).TrimStart("/").ToString().ToLower();
                var paramStr = urlSpan.Slice(len + 1).ToString();
                var parameters = paramStr.Split('&');
                return parameters.ToList().Select(p => p.Split("="))
                    .ToDictionary(p => p[0].ToLower(), p => (object) p[1]);
            }

            /// <summary>
            /// Exceptions the caught.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="exception">The exception.</param>
            public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
            {
                completion.TrySetException(exception);
            }
        }

        #endregion Help Class

        #region Field

        private readonly ILogger<DotNettyHttpServerMessageListener> _logger;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private IChannel _channel;
        private readonly ISerializer<string> _serializer;
        private readonly IServiceRouteProvider _serviceRouteProvider;

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