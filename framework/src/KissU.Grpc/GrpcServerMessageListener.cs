using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Grpc.Core;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.GrpcTransport.Runtime;
using Microsoft.Extensions.Logging;

namespace KissU.GrpcTransport
{
    /// <summary>
    /// GrpcServerMessageListener.
    /// Implements the <see cref="IMessageListener" />
    /// Implements the <see cref="IDisposable" />
    /// </summary>
    /// <seealso cref="IMessageListener" />
    /// <seealso cref="IDisposable" />
    public class GrpcServerMessageListener : IMessageListener, IDisposable
    {
        private readonly IGrpcServiceEntryProvider _grpcServiceEntryProvider;
        private readonly ILogger<GrpcServerMessageListener> _logger;

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
        /// Gets the server.
        /// </summary>
        public Server Server { get; private set; }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Server.ShutdownAsync();
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
        /// Starts the asynchronous.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        /// <returns>Task.</returns>
        public Task StartAsync(EndPoint endPoint)
        {
            var ipEndPoint = endPoint as IPEndPoint;
            if (ipEndPoint.Port == 0)
            {
                return Task.CompletedTask;
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"准备启动Grpc服务主机, 监听端口: {endPoint}");
            }

            try
            {
                Server = new Server { Ports = { new ServerPort(ipEndPoint.Address.ToString(), ipEndPoint.Port, ServerCredentials.Insecure) } };
                var entries = _grpcServiceEntryProvider.GetEntries();

                var serverServiceDefinitions = new List<ServerServiceDefinition>();
                foreach (var entry in entries)
                {
                    var baseType = entry.Type.BaseType.BaseType;
                    var definitionType = baseType?.DeclaringType;

                    var methodInfo = definitionType?.GetMethod("BindService", new[] {baseType});
                    if (methodInfo != null)
                    {
                        var serviceDescriptor =
                            methodInfo.Invoke(null, new object[] {entry.Behavior}) as ServerServiceDefinition;
                        if (serviceDescriptor != null)
                        {
                            Server.Services.Add(serviceDescriptor);
                        }
                    }
                }

                Server.Start();
                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation($"Grpc服务主机已启动, 监听端口:{endPoint}");
            }
            catch
            {
                _logger.LogError($"Grpc服务主机启动失败, 监听端口: {endPoint} ");
            }

            return Task.CompletedTask;
        }
    }
}