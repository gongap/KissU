using System.Net;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport;
using KissU.Core.CPlatform.Transport.Implementation;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation
{
    /// <summary>
    /// 服务主机基类。
    /// </summary>
    public abstract class ServiceHostAbstract : IServiceHost
    {
        private readonly IServiceExecutor _serviceExecutor;

        /// <summary>
        /// 服务执行器.
        /// </summary>
        public IServiceExecutor ServiceExecutor { get => _serviceExecutor; }

        /// <summary>
        /// 消息监听者。
        /// </summary>
        protected IMessageListener MessageListener { get; } = new MessageListener();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostAbstract"/> class.
        /// </summary>
        /// <param name="serviceExecutor">The service executor.</param>
        protected ServiceHostAbstract(IServiceExecutor serviceExecutor)
        {
            _serviceExecutor = serviceExecutor;
            MessageListener.Received += MessageListener_Received;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// 启动主机。
        /// </summary>
        /// <param name="endPoint">主机终结点。</param>
        /// <returns>一个任务。</returns>
        public abstract Task StartAsync(EndPoint endPoint);

        private async Task MessageListener_Received(IMessageSender sender, TransportMessage message)
        {
            await _serviceExecutor.ExecuteAsync(sender, message);
        }

        /// <summary>
        /// 启动主机。
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <returns>Task.</returns>
        public abstract Task StartAsync(string ip, int port);
    }
}