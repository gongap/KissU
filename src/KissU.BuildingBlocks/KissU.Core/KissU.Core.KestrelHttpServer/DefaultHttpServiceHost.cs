﻿using System;
using System.Net;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Runtime.Server.Implementation;
using KissU.Core.CPlatform.Transport;

namespace KissU.Core.KestrelHttpServer
{
    /// <summary>
    /// DefaultHttpServiceHost.
    /// Implements the <see cref="KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceHostAbstract" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceHostAbstract" />
    public class DefaultHttpServiceHost : ServiceHostAbstract
    {
        #region Field

        private readonly Func<EndPoint, Task<IMessageListener>> _messageListenerFactory;
        private IMessageListener _serverMessageListener;

        #endregion Field

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHttpServiceHost"/> class.
        /// </summary>
        /// <param name="messageListenerFactory">The message listener factory.</param>
        /// <param name="serviceExecutor">The service executor.</param>
        /// <param name="httpMessageListener">The HTTP message listener.</param>
        public DefaultHttpServiceHost(Func<EndPoint, Task<IMessageListener>> messageListenerFactory, IServiceExecutor serviceExecutor, HttpMessageListener httpMessageListener) : base(serviceExecutor)
        {
            _messageListenerFactory = messageListenerFactory;
            _serverMessageListener = httpMessageListener;
            _serverMessageListener.Received += async (sender, message) =>
            {
                await Task.Run(() =>
                {
                    MessageListener.OnReceived(sender, message);
                });
            };
        }

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
            _serverMessageListener = await _messageListenerFactory(new IPEndPoint(IPAddress.Parse(ip), port));
        }

        #endregion Overrides of ServiceHostAbstract

        private async Task MessageListener_Received(IMessageSender sender, CPlatform.Messages.TransportMessage message)
        {
            await ServiceExecutor.ExecuteAsync(sender, message);
        }
    }
} 
