using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Grpc.Core;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport;
using KissU.Core.Grpc.Runtime;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Grpc
{
    /// <summary>
    /// GrpcServerMessageListener.
    /// Implements the <see cref="KissU.Core.CPlatform.Transport.IMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Transport.IMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class GrpcServerMessageListener: IMessageListener, IDisposable
    { 
        private Server _server;
        private readonly ILogger<GrpcServerMessageListener> _logger;
        private readonly IGrpcServiceEntryProvider _grpcServiceEntryProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GrpcServerMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="grpcServiceEntryProvider">The GRPC service entry provider.</param>
        public GrpcServerMessageListener(ILogger<GrpcServerMessageListener> logger,
            IGrpcServiceEntryProvider grpcServiceEntryProvider)
        {
            _logger = logger;
            _grpcServiceEntryProvider = grpcServiceEntryProvider; 
        }
        /// <summary>
        /// Starts the asynchronous.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        /// <returns>Task.</returns>
        public Task StartAsync(EndPoint endPoint)
        {
            var ipEndPoint = endPoint as IPEndPoint;
            _server = new Server() { Ports = { new ServerPort(ipEndPoint.Address.ToString(), ipEndPoint.Port, ServerCredentials.Insecure) } };
 
            try
            {
                var entries = _grpcServiceEntryProvider.GetEntries();

                var serverServiceDefinitions = new List<ServerServiceDefinition>();
                foreach (var entry in entries)
                {

                    var baseType = entry.Type.BaseType.BaseType;
                    var definitionType = baseType?.DeclaringType;

                    var methodInfo = definitionType?.GetMethod("BindService", new Type[] { baseType });
                    if (methodInfo != null)
                    {
                        var serviceDescriptor = methodInfo.Invoke(null, new object[] { entry.Behavior }) as ServerServiceDefinition;
                        if (serviceDescriptor != null)
                        {
                            _server.Services.Add(serviceDescriptor);
                            continue;
                        }
                    }
                } 
                _server.Start();
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug($"Grpc服务主机启动成功，监听地址：{endPoint}。");
            }
            catch
            {
                _logger.LogError($"Grpc服务主机启动失败，监听地址：{endPoint}。 ");
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the server.
        /// </summary>
        public Server  Server
        {
            get
            {
                return _server;
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
            _server.ShutdownAsync();
        }
    }
}
