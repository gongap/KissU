﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport;
using KissU.Core.Protocol.WS.Configurations;
using KissU.Core.Protocol.WS.Runtime;
using Microsoft.Extensions.Logging;
using WebSocketCore.Server;

namespace KissU.Core.Protocol.WS
{
    /// <summary>
    /// DefaultWSServerMessageListener.
    /// Implements the <see cref="KissU.Core.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class DefaultWSServerMessageListener : IMessageListener, IDisposable
    {
        private readonly List<WSServiceEntry> _entries;
        private  WebSocketServer _wssv;
        private readonly ILogger<DefaultWSServerMessageListener> _logger;
        private readonly WebSocketOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultWSServerMessageListener"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="wsServiceEntryProvider">The ws service entry provider.</param>
        /// <param name="options">The options.</param>
        public DefaultWSServerMessageListener(ILogger<DefaultWSServerMessageListener> logger,
            IWSServiceEntryProvider wsServiceEntryProvider, WebSocketOptions options)
        {
            _logger = logger;
            _entries = wsServiceEntryProvider.GetEntries().ToList();
            _options = options;
        }
        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        public async Task StartAsync(EndPoint endPoint)
        {
            var ipEndPoint = endPoint as IPEndPoint;
            _wssv = new WebSocketServer(ipEndPoint.Address, ipEndPoint.Port);
            try
            {
                foreach (var entry in _entries)
                    _wssv.AddWebSocketService(entry.Path, entry.FuncBehavior);
                _wssv.KeepClean = _options.KeepClean;
                _wssv.WaitTime = TimeSpan.FromSeconds(_options.WaitTime); 
                //允许转发请求
                _wssv.AllowForwardedRequest = true;  
                _wssv.Start();
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug($"WS服务主机启动成功，监听地址：{endPoint}。");
            }
            catch
            {
                _logger.LogError($"WS服务主机启动失败，监听地址：{endPoint}。 ");
            }
         
        }

        /// <summary>
        /// Gets the server.
        /// </summary>
        public WebSocketServer  Server
        {
            get
            {
                return _wssv;
            }
        }

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
        public Task OnReceived(IMessageSender sender, TransportMessage message)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _wssv.Stop();
        }
    }
}
