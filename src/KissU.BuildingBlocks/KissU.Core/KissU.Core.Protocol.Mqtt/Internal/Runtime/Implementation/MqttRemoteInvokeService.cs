using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Exceptions;
using KissU.Core.CPlatform.Runtime.Client;
using KissU.Core.CPlatform.Runtime.Client.HealthChecks;
using KissU.Core.CPlatform.Transport;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime.Implementation
{
    public class MqttRemoteInvokeService:IMqttRemoteInvokeService
    { 
        private readonly ITransportClientFactory _transportClientFactory;
        private readonly ILogger<MqttRemoteInvokeService> _logger;
        private readonly IHealthCheckService _healthCheckService;
        private readonly IMqttBrokerEntryManger _mqttBrokerEntryManger;

        public MqttRemoteInvokeService( ITransportClientFactory transportClientFactory,
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

        public async Task InvokeAsync(RemoteInvokeContext context)
        {
              await InvokeAsync(context, Task.Factory.CancellationToken);
        }

        public async Task InvokeAsync(RemoteInvokeContext context, CancellationToken cancellationToken)
        {
            var mqttContext = context as MqttRemoteInvokeContext;
            if (mqttContext != null)
            {
                var invokeMessage = context.InvokeMessage;
                var host= NetUtils.GetHostAddress();
                var addresses = await _mqttBrokerEntryManger.GetMqttBrokerAddress(mqttContext.topic);
                addresses = addresses.Except(new AddressModel[] { host });
                foreach (var address in addresses)
                {
                    try
                    {
                        var endPoint = address.CreateEndPoint();
                        if (_logger.IsEnabled(LogLevel.Debug))
                            _logger.LogDebug($"使用地址：'{endPoint}'进行调用。");
                        var client =await _transportClientFactory.CreateClientAsync(endPoint);
                        await client.SendAsync(invokeMessage, cancellationToken).WithCancellation(cancellationToken);
                    }
                    catch (CommunicationException)
                    {
                        await _healthCheckService.MarkFailure(address);
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, $"发起请求中发生了错误，服务Id：{invokeMessage.ServiceId}。");
                    }
                }
            }
        }

        public async Task InvokeAsync(RemoteInvokeContext context, int requestTimeout)
        {
            var mqttContext = context as MqttRemoteInvokeContext;
            if (mqttContext != null)
            {
                var invokeMessage = context.InvokeMessage;
                var host = NetUtils.GetHostAddress();
                var addresses = await _mqttBrokerEntryManger.GetMqttBrokerAddress(mqttContext.topic);
                if (addresses != null)
                {
                    addresses = addresses.Except(new AddressModel[] { host });
                    foreach (var address in addresses)
                    {
                        try
                        {
                            var endPoint = address.CreateEndPoint();
                            if (_logger.IsEnabled(LogLevel.Debug))
                                _logger.LogDebug($"使用地址：'{endPoint}'进行调用。");
                            var client =await _transportClientFactory.CreateClientAsync(endPoint);
                            using (var cts = new CancellationTokenSource())
                            {
                                await client.SendAsync(invokeMessage,cts.Token).WithCancellation(cts,requestTimeout);
                            }
                        }
                        catch (CommunicationException)
                        {
                            await _healthCheckService.MarkFailure(address);
                        }
                        catch (Exception exception)
                        {
                            _logger.LogError(exception, $"发起mqtt请求中发生了错误，服务Id：{invokeMessage.ServiceId}。");

                        }
                    }
                }
            }
        }
        

        #endregion Implementation of IRemoteInvokeService
    }
}
