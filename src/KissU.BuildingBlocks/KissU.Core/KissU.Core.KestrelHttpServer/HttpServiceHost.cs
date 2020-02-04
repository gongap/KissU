using System;
using System.Net;
using System.Threading.Tasks;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Runtime.Server.Implementation;
using KissU.Core.CPlatform.Transport;

namespace KissU.Core.KestrelHttpServer
{
    /// <summary>
    /// HttpServiceHost.
    /// Implements the <see cref="KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceHostAbstract" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceHostAbstract" />
    public class HttpServiceHost : ServiceHostAbstract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpServiceHost" /> class.
        /// </summary>
        /// <param name="messageListenerFactory">The message listener factory.</param>
        /// <param name="serviceExecutor">The service executor.</param>
        /// <param name="httpMessageListener">The HTTP message listener.</param>
        public HttpServiceHost(Func<EndPoint, Task<IMessageListener>> messageListenerFactory,
            IServiceExecutor serviceExecutor, HttpMessageListener httpMessageListener) : base(serviceExecutor)
        {
            _messageListenerFactory = messageListenerFactory;
            _serverMessageListener = httpMessageListener;
            _serverMessageListener.Received += async (sender, message) =>
            {
                await Task.Run(async () => { await MessageListener.OnReceived(sender, message); });
            };
        }

        private async Task MessageListener_Received(IMessageSender sender, TransportMessage message)
        {
            await ServiceExecutor.ExecuteAsync(sender, message);
        }

        #region Field

        private readonly Func<EndPoint, Task<IMessageListener>> _messageListenerFactory;
        private readonly IMessageListener _serverMessageListener;

        #endregion Field

        #region Overrides of ServiceHostAbstract

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            (_serverMessageListener as IDisposable)?.Dispose();
        }

        /// <summary>
        /// 启动主机。
        /// </summary>
        /// <param name="endPoint">主机终结点。</param>
        /// <returns>一个任务。</returns>
        public override async Task StartAsync(EndPoint endPoint)
        {
            await _messageListenerFactory(endPoint);
        }

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        public override async Task StartAsync(string ip, int port)
        {
            await _messageListenerFactory(new IPEndPoint(IPAddress.Parse(ip),
                AppConfig.ServerOptions.Ports.HttpPort ?? 0));
        }

        #endregion Overrides of ServiceHostAbstract
    }
}