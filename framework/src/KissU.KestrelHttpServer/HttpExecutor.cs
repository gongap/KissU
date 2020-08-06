using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using KissU.Convertibles;
using KissU.Dependency;
using KissU.Exceptions;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Filters;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Implementation;
using KissU.Kestrel;
using KissU.Kestrel.Internal;
using KissU.ProxyGenerator;
using Microsoft.Extensions.Logging;
using KissU.KestrelHttpServer.Internal;
using static KissU.Helpers.FastInvoke;

namespace KissU.KestrelHttpServer
{
    /// <summary>
    /// HttpExecutor.
    /// Implements the <see cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    public class HttpExecutor : IServiceExecutor
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpExecutor" /> class.
        /// </summary>
        /// <param name="serviceEntryLocate">The service entry locate.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="authorizationFilter">The authorization filter.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="serviceProxyProvider">The service proxy provider.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        public HttpExecutor(IServiceEntryLocate serviceEntryLocate, IServiceRouteProvider serviceRouteProvider,
            IAuthorizationFilter authorizationFilter,
            ILogger<HttpExecutor> logger, CPlatformContainer serviceProvider,
            IServiceProxyProvider serviceProxyProvider, ITypeConvertibleService typeConvertibleService)
        {
            _diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
            _serviceEntryLocate = serviceEntryLocate;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _typeConvertibleService = typeConvertibleService;
            _serviceRouteProvider = serviceRouteProvider;
            _authorizationFilter = authorizationFilter;
            _serviceProxyProvider = serviceProxyProvider;
        }

        #endregion Constructor

        #region Implementation of IExecutor

        /// <summary>
        /// execute as an asynchronous operation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="message">The message.</param>
        public async Task ExecuteAsync(IMessageSender sender, TransportMessage message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace("服务提供者接收到消息。");
            }

            if (!message.IsHttpMessage())
            {
                return;
            }

            HttpRequestMessage httpMessage;
            try
            {
                httpMessage = message.GetContent<HttpRequestMessage>();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "将接收到的消息反序列化成 TransportMessage<httpMessage> 时发送了错误。");
                return;
            }

            if (httpMessage.Attachments != null)
            {
                foreach (var attachment in httpMessage.Attachments)
                {
                    RpcContext.GetContext().SetAttachment(attachment.Key, attachment.Value);
                }
            }

            WirteDiagnosticBefore(message);
            var entry = _serviceEntryLocate.Locate(httpMessage);

            var httpResultMessage = new HttpResultMessage<object>();

            if (entry != null && _serviceProvider.IsRegisteredWithKey(httpMessage.ServiceKey, entry.Type))
            {
                //执行本地代码。
                httpResultMessage = await LocalExecuteAsync(entry, httpMessage);
            }
            else
            {
                httpResultMessage = await RemoteExecuteAsync(httpMessage);
            }

            await SendRemoteInvokeResult(sender, message.Id, httpResultMessage);
        }

        #endregion Implementation of IServiceExecutor

        #region Field

        private readonly IServiceEntryLocate _serviceEntryLocate;
        private readonly ILogger<HttpExecutor> _logger;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly IAuthorizationFilter _authorizationFilter;
        private readonly CPlatformContainer _serviceProvider;
        private readonly ITypeConvertibleService _typeConvertibleService;
        private readonly IServiceProxyProvider _serviceProxyProvider;

        private readonly ConcurrentDictionary<string, ValueTuple<FastInvokeHandler, object, MethodInfo>> _concurrent =
            new ConcurrentDictionary<string, ValueTuple<FastInvokeHandler, object, MethodInfo>>();
        private readonly DiagnosticListener _diagnosticListener;

        #endregion Field

        #region Private Method

        private async Task<HttpResultMessage<object>> RemoteExecuteAsync(HttpRequestMessage httpMessage)
        {
            var resultMessage = new HttpResultMessage<object>();
            try
            {
                resultMessage.Data = await _serviceProxyProvider.Invoke<object>(httpMessage.Parameters, httpMessage.RoutePath, httpMessage.ServiceKey);
                resultMessage.IsSucceed = resultMessage.Data != default;
                resultMessage.StatusCode = resultMessage.IsSucceed ? (int)StatusCode.Success : (int)StatusCode.RequestError;
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, $"执行远程调用逻辑时候发生了错误：{exception.Message}");
                }

                resultMessage = new HttpResultMessage<object> { Data = null, Message = "执行发生了错误。", StatusCode = (int)StatusCode.RequestError };
            }

            return resultMessage;
        }

        private async Task<HttpResultMessage<object>> LocalExecuteAsync(ServiceEntry entry,
            HttpRequestMessage httpMessage)
        {
            var resultMessage = new HttpResultMessage<object>();
            try
            {
                var result = await entry.Func(httpMessage.ServiceKey, httpMessage.Parameters);
                var task = result as Task;

                if (task == null)
                {
                    resultMessage.Data = result;
                }
                else
                {
                    task.Wait();
                    var taskType = task.GetType().GetTypeInfo();
                    if (taskType.IsGenericType)
                    {
                        resultMessage.Data = taskType.GetProperty("Result").GetValue(task);
                    }
                }

                resultMessage.IsSucceed = resultMessage.Data != null;
                resultMessage.StatusCode =
                    resultMessage.IsSucceed ? (int)StatusCode.Success : (int)StatusCode.RequestError;
            }
            catch (ValidateException validateException)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(validateException, $"执行本地逻辑时候发生了错误：{validateException.Message}", validateException);
                }

                resultMessage.Message = validateException.Message;
                resultMessage.StatusCode = validateException.HResult;
            }
            //catch (Exception exception) when (exception.InnerException is BusinessException businessException)
            //{
            //    if (_logger.IsEnabled(LogLevel.Error))
            //    {
            //        _logger.LogError(businessException, $"执行本地逻辑时候发生了错误：{businessException.Message}", businessException);
            //    }

            //    resultMessage.Message = businessException.Message;
            //    resultMessage.StatusCode = businessException.HResult;
            //}
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, $"执行本地逻辑时候发生了错误：{exception.Message}");
                }

                resultMessage.Message = "执行发生了错误。";
                resultMessage.StatusCode = exception.HResult;
            }

            return resultMessage;
        }

        private async Task SendRemoteInvokeResult(IMessageSender sender, string messageId, HttpResultMessage resultMessage)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug("准备发送响应消息。");
                }

                await sender.SendAndFlushAsync(new TransportMessage(messageId, resultMessage));
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug("响应消息发送成功。");
                }
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, $"发送响应消息时候发生了异常。{exception.Message}");
                }
            }
        }

        private static string GetExceptionMessage(Exception exception)
        {
            if (exception == null)
            {
                return string.Empty;
            }

            var message = exception.Message;
            if (exception.InnerException != null)
            {
                message += "|InnerException:" + GetExceptionMessage(exception.InnerException);
            }

            return message;
        }

        private void WirteDiagnosticBefore(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                RpcContext.GetContext().SetAttachment("TraceId", message.Id);
                var remoteInvokeMessage = message.GetContent<HttpRequestMessage>();
                _diagnosticListener.WriteTransportBefore(TransportType.Rest, new TransportEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id,
                    MessageName = remoteInvokeMessage.RoutePath
                }, TransportType.Rest.ToString(),
                    message.Id,
                    RestContext.GetContext().GetAttachment("RemoteIpAddress")?.ToString()));
            }
            else
            {
                var parameters = RpcContext.GetContext().GetContextParameters();
                RpcContext.GetContext().SetContextParameters(parameters);
            }
        }

        #endregion Private Method
    }
}