using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.CPlatform;
using KissU.CPlatform.Runtime.Client;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Transport;
using KissU.Exceptions;
using KissUtil.Extensions;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// MqttRemoteInvokeService.
    /// Implements the <see cref="IMqttRemoteInvokeService" />
    /// </summary>
    /// <seealso cref="IMqttRemoteInvokeService" />
    public class MqttRemoteInvokeService : IMqttRemoteInvokeService
    {
        private readonly IHealthCheckService _healthCheckService;
        private readonly ILogger<MqttRemoteInvokeService> _logger;
        private readonly IMqttBrokerEntryManger _mqttBrokerEntryManger;
        private readonly ITransportClientFactory _transportClientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttRemoteInvokeService" /> class.
        /// </summary>
        /// <param name="transportClientFactory">The transport client factory.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="mqttBrokerEntryManger">The MQTT broker entry manger.</param>
        public MqttRemoteInvokeService(ITransportClientFactory transportClientFactory,
            ILogger<MqttRemoteInvokeService> logger,
            IHealthCheckService healthCheckService,
            IMqttBrokerEntryManger mqttBrokerEntryManger)
        {
            _transportClientFactory = transportClientFactory;
            _logger = logger;
            _healthCheckService = healthCheckService;
            _mqttBrokerEntryManger = mqttBrokerEntryManger;
        }

        #region Implementation of IRemoteInvokeService

        /// <summary>
        /// invoke as an asynchronous operation.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task InvokeAsync(RemoteInvokeContext context)
        {
            await InvokeAsync(context, Task.Factory.CancellationToken);
        }

        /// <summary>
        /// invoke as an asynchronous operation.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task InvokeAsync(RemoteInvokeContext context, CancellationToken cancellationToken)
        {
            var mqttContext = context as MqttRemoteInvokeContext;
            if (mqttContext != null)
            {
                var invokeMessage = context.InvokeMessage;
                var host = AppConfig.GetHostAddress();
                var addresses = await _mqttBrokerEntryManger.GetMqttBrokerAddress(mqttContext.topic);
                addresses = addresses.Except(new[] {host});
                foreach (var address in addresses)
                {
                    try
                    {
                        var endPoint = address.CreateEndPoint();
                        if (_logger.IsEnabled(LogLevel.Debug))
                            _logger.LogDebug($"使用地址：'{endPoint}'进行调用。");
                        var client = await _transportClientFactory.CreateClientAsync(endPoint);
                        await client.SendAsync(invokeMessage, cancellationToken).WithCancellation(cancellationToken);
                    }
                    catch (CommunicationException)
                    {
                        await _healthCheckService.MarkFailure(address);
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, $"远程调用发生了错误，服务Id：{invokeMessage.ServiceId}。错误信息：{exception.Message}");
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// invoke as an asynchronous operation.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="requestTimeout">The request timeout.</param>
        public async Task InvokeAsync(RemoteInvokeContext context, int requestTimeout)
        {
            var mqttContext = context as MqttRemoteInvokeContext;
            if (mqttContext != null)
            {
                var invokeMessage = context.InvokeMessage;
                var host = AppConfig.GetHostAddress();
                var addresses = await _mqttBrokerEntryManger.GetMqttBrokerAddress(mqttContext.topic);
                if (addresses != null)
                {
                    addresses = addresses.Except(new[] {host});
                    foreach (var address in addresses)
                    {
                        try
                        {
                            var endPoint = address.CreateEndPoint();
                            if (_logger.IsEnabled(LogLevel.Debug))
                                _logger.LogDebug($"使用地址：'{endPoint}'进行调用。");
                            var client = await _transportClientFactory.CreateClientAsync(endPoint);
                            using (var cts = new CancellationTokenSource())
                            {
                                await client.SendAsync(invokeMessage, cts.Token).WithCancellation(cts, requestTimeout);
                            }
                        }
                        catch (CommunicationException)
                        {
                            await _healthCheckService.MarkFailure(address);
                        }
                        catch (Exception exception)
                        {
                            _logger.LogError(exception, $"服务Id：{invokeMessage.ServiceId}，发起mqtt请求中发生了错误：{exception.StackTrace}");
                        }
                    }
                }
            }
        }

        #endregion Implementation of IRemoteInvokeService
    }
}
