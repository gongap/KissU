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
   public class HttpServiceHost : ServiceHostAbstract
    {
        #region Field

        private readonly Func<EndPoint, Task<IMessageListener>> _messageListenerFactory;
        private IMessageListener _serverMessageListener;

        #endregion Field

        public HttpServiceHost(Func<EndPoint, Task<IMessageListener>> messageListenerFactory, IServiceExecutor serviceExecutor, HttpMessageListener httpMessageListener) : base(serviceExecutor)
        {
            _messageListenerFactory = messageListenerFactory;
            _serverMessageListener = httpMessageListener;
            _serverMessageListener.Received += async (sender, message) =>
            {
                await Task.Run(async () =>
                {
                   await MessageListener.OnReceived(sender, message);
                });
            };
        }

        #region Overrides of ServiceHostAbstract


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

        public override async Task StartAsync(string ip, int port)
        {
            await _messageListenerFactory(new IPEndPoint(IPAddress.Parse(ip), AppConfig.ServerOptions.Ports.HttpPort??0));
        }

        #endregion Overrides of ServiceHostAbstract

        private async Task MessageListener_Received(IMessageSender sender, TransportMessage message)
        {
            await ServiceExecutor.ExecuteAsync(sender, message);
        }
    }
} 
