using System;
using System.Threading;
using System.Threading.Tasks;
using KissU.Address;
using KissU.Exceptions;
using KissU.Extensions;
using KissU.CPlatform.HashAlgorithms;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Runtime.Client.Address.Resolvers;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.CPlatform.Runtime.Client.Implementation
{
    /// <summary>
    /// 远程调用服务
    /// </summary>
    public class RemoteInvokeService : IRemoteInvokeService
    {
        private readonly IAddressResolver _addressResolver;
        private readonly IHealthCheckService _healthCheckService;
        private readonly ILogger<RemoteInvokeService> _logger;
        private readonly ITransportClientFactory _transportClientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteInvokeService" /> class.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="addressResolver">The address resolver.</param>
        /// <param name="transportClientFactory">The transport client factory.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="healthCheckService">The health check service.</param>
        public RemoteInvokeService(IHashAlgorithm hashAlgorithm, IAddressResolver addressResolver,
            ITransportClientFactory transportClientFactory, ILogger<RemoteInvokeService> logger,
            IHealthCheckService healthCheckService)
        {
            _addressResolver = addressResolver;
            _transportClientFactory = transportClientFactory;
            _logger = logger;
            _healthCheckService = healthCheckService;
        }

        /// <summary>
        /// 调用.
        /// </summary>
        /// <param name="context">调用上下文。</param>
        /// <returns>远程调用结果消息模型。</returns>
        public async Task<RemoteInvokeResultMessage> InvokeAsync(RemoteInvokeContext context)
        {
            return await InvokeAsync(context, Task.Factory.CancellationToken);
        }

        /// <summary>
        /// 调用.
        /// </summary>
        /// <param name="context">调用上下文。</param>
        /// <param name="cancellationToken">取消操作通知实例。</param>
        /// <returns>远程调用结果消息模型。</returns>
        public async Task<RemoteInvokeResultMessage> InvokeAsync(RemoteInvokeContext context,
            CancellationToken cancellationToken)
        {
            var invokeMessage = context.InvokeMessage;
            AddressModel address = null;
            var vt = ResolverAddress(context, context.Item);
            address = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            try
            {
                var endPoint = address.CreateEndPoint();
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"使用地址：'{endPoint}'进行调用。");
                }

                var client = await _transportClientFactory.CreateClientAsync(endPoint);
                RpcContext.GetContext().SetAttachment("RemoteAddress", address.ToString());
                return await client.SendAsync(invokeMessage, cancellationToken).WithCancellation(cancellationToken);
            }
            catch (CommunicationException)
            {
                await _healthCheckService.MarkFailure(address);
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"发起请求中发生了错误，服务Id：{invokeMessage.ServiceId}。错误信息：{exception.Message}");
                throw;
            }
        }

        /// <summary>
        /// 调用.
        /// </summary>
        /// <param name="context">调用上下文。</param>
        /// <param name="requestTimeout">超时时间。</param>
        /// <returns>远程调用结果消息模型。</returns>
        public async Task<RemoteInvokeResultMessage> InvokeAsync(RemoteInvokeContext context, int requestTimeout)
        {
            var invokeMessage = context.InvokeMessage;
            AddressModel address = null;
            var vt = ResolverAddress(context, context.Item);
            address = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            try
            {
                var endPoint = address.CreateEndPoint();
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"使用地址：'{endPoint}'进行调用。");
                }

                var task = _transportClientFactory.CreateClientAsync(endPoint);
                var client = task.IsCompletedSuccessfully ? task.Result : await task;
                RpcContext.GetContext().SetAttachment("RemoteAddress", address.ToString());
                using (var cts = new CancellationTokenSource())
                {
                    return await client.SendAsync(invokeMessage, cts.Token).WithCancellation(cts, requestTimeout);
                }
            }
            catch (CommunicationException)
            {
                await _healthCheckService.MarkFailure(address);
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"发起请求中发生了错误，服务Id：{invokeMessage.ServiceId}。错误信息：{exception.Message}");
                throw;
            }
        }

        /// <summary>
        /// 解析地址.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="item">The item.</param>
        /// <returns>ValueTask&lt;AddressModel&gt;.</returns>
        /// <exception cref="ArgumentNullException">context</exception>
        /// <exception cref="ArgumentNullException">InvokeMessage</exception>
        /// <exception cref="ArgumentException">服务Id不能为空。 - ServiceId</exception>
        /// <exception cref="CPlatformException">无法解析服务Id：{invokeMessage.ServiceId}的地址信息。</exception>
        private async ValueTask<AddressModel> ResolverAddress(RemoteInvokeContext context, string item)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.InvokeMessage == null)
            {
                throw new ArgumentNullException(nameof(context.InvokeMessage));
            }

            if (string.IsNullOrEmpty(context.InvokeMessage.ServiceId))
            {
                throw new ArgumentException("服务Id不能为空。", nameof(context.InvokeMessage.ServiceId));
            }

            // 远程调用信息
            var invokeMessage = context.InvokeMessage;

            // 解析服务地址
            var vt = _addressResolver.Resolver(invokeMessage.ServiceId, item);
            var address = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            if (address == null)
            {
                throw new CPlatformException($"无法解析服务Id：{invokeMessage.ServiceId}的地址信息。");
            }

            return address;
        }
    }
}