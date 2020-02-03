using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.CPlatform.Filters;
using KissU.Core.CPlatform.Filters.Implementation;
using KissU.Core.CPlatform.HashAlgorithms;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Runtime.Client;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Core.CPlatform.Transport.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Core.CPlatform.Support.Implementation
{
    /// <summary>
    /// 断开远程调用服务.
    /// Implements the <see cref="IBreakeRemoteInvokeService" />
    /// </summary>
    /// <seealso cref="IBreakeRemoteInvokeService" />
    public class BreakeRemoteInvokeService : IBreakeRemoteInvokeService
    {
        private readonly IServiceCommandProvider _commandProvider;
        private readonly IRemoteInvokeService _remoteInvokeService;
        private readonly ILogger<BreakeRemoteInvokeService> _logger;
        private readonly ConcurrentDictionary<string, ServiceInvokeListenInfo> _serviceInvokeListenInfo = new ConcurrentDictionary<string, ServiceInvokeListenInfo>();
        private readonly IHashAlgorithm _hashAlgorithm;
        private readonly IEnumerable<IExceptionFilter> exceptionFilters = new List<IExceptionFilter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakeRemoteInvokeService" /> class.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="commandProvider">The command provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="remoteInvokeService">The remote invoke service.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public BreakeRemoteInvokeService(IHashAlgorithm hashAlgorithm, IServiceCommandProvider commandProvider, ILogger<BreakeRemoteInvokeService> logger, IRemoteInvokeService remoteInvokeService, CPlatformContainer serviceProvider)
        {
            _commandProvider = commandProvider;
            _remoteInvokeService = remoteInvokeService;
            _logger = logger;
            _hashAlgorithm = hashAlgorithm;
            if (serviceProvider.Current.IsRegistered<IExceptionFilter>())
            {
                exceptionFilters = serviceProvider.GetInstances<IEnumerable<IExceptionFilter>>();
            }
        }

        /// <summary>
        /// 调用.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>Task&lt;RemoteInvokeResultMessage&gt;.</returns>
        public async Task<RemoteInvokeResultMessage> InvokeAsync(IDictionary<string, object> parameters, string serviceId, string serviceKey, bool decodeJOject)
        {
            var serviceInvokeInfos = _serviceInvokeListenInfo.GetOrAdd(serviceId,
                new ServiceInvokeListenInfo()
                {
                    FirstInvokeTime = DateTime.Now,
                    FinalRemoteInvokeTime = DateTime.Now,
                });
            var vt = _commandProvider.GetCommand(serviceId);
            var command = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            var intervalSeconds = (DateTime.Now - serviceInvokeInfos.FinalRemoteInvokeTime).TotalSeconds;
            bool reachConcurrentRequest() => serviceInvokeInfos.ConcurrentRequests > command.MaxConcurrentRequests;
            bool reachRequestVolumeThreshold() => intervalSeconds <= 10 && serviceInvokeInfos.SinceFaultRemoteServiceRequests > command.BreakerRequestVolumeThreshold;
            bool reachErrorThresholdPercentage() => (double)serviceInvokeInfos.FaultRemoteServiceRequests / (double)(serviceInvokeInfos.RemoteServiceRequests ?? 1) * 100 > command.BreakeErrorThresholdPercentage;
            var item = GetHashItem(command, parameters);
            if (command.BreakerForceClosed)
            {
                _serviceInvokeListenInfo.AddOrUpdate(serviceId, new ServiceInvokeListenInfo(), (k, v) => { v.LocalServiceRequests++; return v; });
                return await MonitorRemoteInvokeAsync(parameters, serviceId, serviceKey, decodeJOject, command.ExecutionTimeoutInMilliseconds, item);
            }
            else
            {
                if (reachConcurrentRequest() || reachRequestVolumeThreshold() || reachErrorThresholdPercentage())
                {
                    if (intervalSeconds * 1000 > command.BreakeSleepWindowInMilliseconds)
                    {
                        return await MonitorRemoteInvokeAsync(parameters, serviceId, serviceKey, decodeJOject, command.ExecutionTimeoutInMilliseconds, item);
                    }
                    else
                    {
                        _serviceInvokeListenInfo.AddOrUpdate(serviceId, new ServiceInvokeListenInfo(), (k, v) => { v.LocalServiceRequests++; return v; });
                        return null;
                    }
                }
                else
                {
                    return await MonitorRemoteInvokeAsync(parameters, serviceId, serviceKey, decodeJOject, command.ExecutionTimeoutInMilliseconds, item);
                }
            }
        }

        /// <summary>
        /// 监视远程调用.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <param name="requestTimeout">The request timeout.</param>
        /// <param name="item">The item.</param>
        /// <returns>Task&lt;RemoteInvokeResultMessage&gt;.</returns>
        private async Task<RemoteInvokeResultMessage> MonitorRemoteInvokeAsync(IDictionary<string, object> parameters, string serviceId, string serviceKey, bool decodeJOject, int requestTimeout, string item)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            var token = source.Token;
            var invokeMessage = new RemoteInvokeMessage
            {
                Parameters = parameters,
                ServiceId = serviceId,
                ServiceKey = serviceKey,
                DecodeJObject = decodeJOject,
                Attachments = RpcContext.GetContext().GetContextParameters(),
            };
            try
            {
                _serviceInvokeListenInfo.AddOrUpdate(serviceId, new ServiceInvokeListenInfo(), (k, v) =>
                {
                    v.RemoteServiceRequests = v.RemoteServiceRequests == null ? 1 : ++v.RemoteServiceRequests;
                    v.FinalRemoteInvokeTime = DateTime.Now;
                    ++v.ConcurrentRequests;
                    return v;
                });
                var message = await _remoteInvokeService.InvokeAsync(
                    new RemoteInvokeContext
                    {
                        Item = item,
                        InvokeMessage = invokeMessage,
                    }, requestTimeout);
                _serviceInvokeListenInfo.AddOrUpdate(serviceId, new ServiceInvokeListenInfo(), (k, v) =>
                {
                    v.SinceFaultRemoteServiceRequests = 0;
                    --v.ConcurrentRequests;
                    return v;
                });
                return message;
            }
            catch (Exception ex)
            {
                _serviceInvokeListenInfo.AddOrUpdate(serviceId, new ServiceInvokeListenInfo(), (k, v) =>
                {
                    ++v.FaultRemoteServiceRequests;
                    ++v.SinceFaultRemoteServiceRequests;
                    --v.ConcurrentRequests;
                    return v;
                });
                await ExecuteExceptionFilter(ex, invokeMessage, token);
                return null;
            }
        }

        /// <summary>
        /// 执行异常过滤器.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="invokeMessage">The invoke message.</param>
        /// <param name="token">The token.</param>
        private async Task ExecuteExceptionFilter(Exception ex, RemoteInvokeMessage invokeMessage, CancellationToken token)
        {
            foreach (var filter in exceptionFilters)
            {
                await filter.ExecuteExceptionFilterAsync(
                    new RpcActionExecutedContext
                    {
                        Exception = ex,
                        InvokeMessage = invokeMessage,
                    }, token);
            }
        }

        /// <summary>
        /// 获取哈希项.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.String.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetHashItem(ServiceCommand command, IDictionary<string, object> parameters)
        {
            string result = string.Empty;
            if (command.ShuntStrategy == AddressSelectorMode.HashAlgorithm)
            {
                var parameter = parameters.Values.FirstOrDefault();
                result = parameter?.ToString();
            }

            return result;
        }
    }
}