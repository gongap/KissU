using System;
using System.Net;
using System.Threading.Tasks;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.CPlatform.Transport;

namespace KissU.DotNetty.Udp
{
    /// <summary>
    /// UdpServiceHost.
    /// Implements the <see cref="KissU.CPlatform.Runtime.Server.Implementation.ServiceHostAbstract" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Runtime.Server.Implementation.ServiceHostAbstract" />
    internal class UdpServiceHost : ServiceHostAbstract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UdpServiceHost" /> class.
        /// </summary>
        /// <param name="messageListenerFactory">The message listener factory.</param>
        /// <param name="serviceExecutor">The service executor.</param>
        public UdpServiceHost(Func<EndPoint, Task<IMessageListener>> messageListenerFactory,
            IServiceExecutor serviceExecutor) : base(serviceExecutor)
        {
            _messageListenerFactory = messageListenerFactory;
        }

        #region Field

        private readonly Func<EndPoint, Task<IMessageListener>> _messageListenerFactory;
        private IMessageListener _serverMessageListener;

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
            if (_serverMessageListener != null)
                return;
            _serverMessageListener = await _messageListenerFactory(endPoint);
            _serverMessageListener.Received += async (sender, message) =>
            {
                await Task.Run(() => { MessageListener.OnReceived(sender, message); });
            };
        }

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        public override async Task StartAsync(string ip, int port)
        {
            if (_serverMessageListener != null)
                return;
            _serverMessageListener =
                await _messageListenerFactory(
                    new IPEndPoint(IPAddress.Parse(ip), AppConfig.ServerOptions.Ports.UdpPort));
            _serverMessageListener.Received += async (sender, message) =>
            {
                await Task.Run(() => { MessageListener.OnReceived(sender, message); });
            };
        }

        #endregion Overrides of ServiceHostAbstract
    }
}