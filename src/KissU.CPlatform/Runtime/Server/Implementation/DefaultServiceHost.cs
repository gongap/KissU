using System;
using System.Net;
using System.Threading.Tasks;
using KissU.CPlatform.Transport;

namespace KissU.CPlatform.Runtime.Server.Implementation
{
    /// <summary>
    /// 一个默认的服务主机。
    /// </summary>
    public class DefaultServiceHost : ServiceHostAbstract
    {
        private readonly Func<EndPoint, Task<IMessageListener>> _messageListenerFactory;
        private IMessageListener _serverMessageListener;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceHost" /> class.
        /// </summary>
        /// <param name="messageListenerFactory">The message listener factory.</param>
        /// <param name="serviceExecutor">The service executor.</param>
        public DefaultServiceHost(Func<EndPoint, Task<IMessageListener>> messageListenerFactory,
            IServiceExecutor serviceExecutor) : base(serviceExecutor)
        {
            _messageListenerFactory = messageListenerFactory;
        }

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
            {
                return;
            }

            _serverMessageListener = await _messageListenerFactory(endPoint);
            _serverMessageListener.Received += async (sender, message) =>
            {
                await  MessageListener.OnReceived(sender, message);
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
            {
                return;
            }

            _serverMessageListener = await _messageListenerFactory(new IPEndPoint(IPAddress.Parse(ip), port));
            _serverMessageListener.Received += async (sender, message) =>
            {
                await MessageListener.OnReceived(sender, message);
            };
        }
    }
}