using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Codec;
using KissU.Thrift.Attributes;
using KissU.Thrift.Extensions;
using KissU.Thrift.Runtime;
using Microsoft.Extensions.Logging;
using Thrift.Processor;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using Thrift.Transport.Server;

namespace KissU.Thrift
{
    class ThriftServerMessageListener : IMessageListener, IDisposable
    {
        #region Field

        private readonly ILogger<ThriftServerMessageListener> _logger;
        private readonly ITransportMessageDecoder _transportMessageDecoder;
        private readonly ITransportMessageEncoder _transportMessageEncoder;
        private readonly List<ThriftServiceEntry> _entries;

        #endregion Field

        #region Constructor

        public ThriftServerMessageListener(ILogger<ThriftServerMessageListener> logger, IThriftServiceEntryProvider thriftServiceEntryProvider, ITransportMessageCodecFactory codecFactory)
        {
            _logger = logger;
            _transportMessageEncoder = codecFactory.GetEncoder();
            _transportMessageDecoder = codecFactory.GetDecoder();
            _entries = thriftServiceEntryProvider.GetEntries().ToList();

        }

        #endregion Constructor

        #region Implementation of IMessageListener

        public event ReceivedDelegate Received;

        /// <summary>
        /// 新的客户端连接事件
        /// </summary>
        public event NewClientAcceptHandler NewClientAccepted;

        /// <summary>
        /// 触发新的客户端连接事件。
        /// </summary>
        /// <param name="remoteAddress">远程地址</param>
        public void OnNewClientAccepted(EndPoint remoteAddress)   
        {
            if (NewClientAccepted == null)
                return;
            NewClientAccepted(remoteAddress);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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

        public Task StartAsync(EndPoint endPoint)
        {
            var ipEndPoint = endPoint as IPEndPoint;
            if (ipEndPoint.Port == 0)
            {
                return Task.CompletedTask;
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"准备启动Thrift服务主机, 监听端口: {endPoint}");
            }

            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                TMultiplexedServiceProcessor processor = new TMultiplexedServiceProcessor(_logger, _transportMessageDecoder, _transportMessageEncoder, new ServerHandler(async (contenxt, message) =>
                  {
                      var sender = new ThriftServerMessageSender(_transportMessageEncoder, contenxt);

                      await OnReceived(sender, message);
                  }, _logger));
                foreach (var entry in _entries)
                {
                    var attr = entry.Type.GetCustomAttribute<BindProcessorAttribute>();

                    if (attr != null)
                    {
                        var asyncProcessor = Activator.CreateInstance(attr.ProcessorType, new object[] { entry.Behavior }) as ITAsyncProcessor;
                        processor.RegisterProcessor(entry.Type.Name, asyncProcessor);
                    }
                }
                var factory1 = new TBinaryProtocol.Factory();
                var factory2 = new TBinaryProtocol.Factory();
                var serverTransport = new TServerSocketTransport(new TcpListener(ipEndPoint));
                var config = new TThreadPoolAsyncServer.Configuration();
                config.MaxWorkerThreads = 200;
                config.MinWorkerThreads = 10;
                var server = new TThreadPoolAsyncServer(new TSingletonProcessorFactory(processor), serverTransport, new TFramedTransport.Factory(), new TFramedTransport.Factory(), factory1, factory2, config, _logger);
                server.ServeAsync(cancellationToken);

                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation($"Thrift服务主机已启动, 监听端口:{endPoint}");
            }
            catch
            {
                _logger.LogError($"Thrift服务主机启动失败, 监听端口: {endPoint} ");
            }
            return Task.CompletedTask;
        }
        #endregion Implementation of IMessageListener


    }
}
