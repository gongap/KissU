using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using KissU.AspNetCore.Internal;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Implementation;
using KissU.Dependency;
using KissU.Exceptions.Handling;
using KissU.ServiceProxy;
using KissUtil.Helpers;
using Microsoft.Extensions.Logging;

namespace KissU.AspNetCore.Kestrel
{
    /// <summary>
    /// HttpExecutor.
    /// Implements the <see cref="IServiceExecutor" />
    /// </summary>
    /// <seealso cref="IServiceExecutor" />
    public class HttpExecutor : IServiceExecutor
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpExecutor" /> class.
        /// </summary>
        /// <param name="serviceEntryLocate">The service entry locate.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="serviceProxyProvider">The service proxy provider.</param>
        public HttpExecutor(IServiceEntryLocate serviceEntryLocate, ILogger<HttpExecutor> logger, CPlatformContainer serviceProvider, IExceptionToErrorInfoConverter  errorInfoConverter, IServiceProxyProvider serviceProxyProvider)
        {
            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rest));
            _serviceEntryLocate = serviceEntryLocate;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _errorInfoConverter = errorInfoConverter;
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
            _logger.LogTrace("服务提供者接收到消息。");

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
                _logger.LogError(exception, $"将接收到的消息反序列化成 TransportMessage<httpMessage> 时发送了错误：{exception.StackTrace}");
                return;
            }

            if (httpMessage.Attachments != null)
            {
                foreach (var attachment in httpMessage.Attachments)
                {
                    RpcContext.GetContext().SetAttachment(attachment.Key, attachment.Value);
                }
            }
            
            SetCurrentCulture();
            WirteDiagnostic(message);

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
        private readonly CPlatformContainer _serviceProvider;
        private readonly IExceptionToErrorInfoConverter _errorInfoConverter;
        private readonly IServiceProxyProvider _serviceProxyProvider;

        private readonly ConcurrentDictionary<string, ValueTuple<FastInvoke.FastInvokeHandler, object, MethodInfo>> _concurrent =
            new ConcurrentDictionary<string, ValueTuple<FastInvoke.FastInvokeHandler, object, MethodInfo>>();
        private readonly DiagnosticListener _diagnosticListener;

        #endregion Field

        #region Private Method

        private async Task<HttpResultMessage<object>> RemoteExecuteAsync(HttpRequestMessage httpMessage)
        {
            var resultMessage = new HttpResultMessage<object>();
            try
            {
                resultMessage.Result = await _serviceProxyProvider.Invoke<object>(httpMessage.Parameters, httpMessage.RoutePath, httpMessage.ServiceKey);
                resultMessage.IsSucceed = resultMessage.Result != default;
                resultMessage.StatusCode = resultMessage.IsSucceed ? (int)StatusCode.Success : (int)StatusCode.RequestError;
            }
            catch (Exception exception)
            {
                resultMessage.Message = "执行发生了错误";
                resultMessage.Code = exception.HResult.ToString();
                resultMessage.StatusCode = (int)StatusCode.ServerError;
                var errorInfo = _errorInfoConverter.Convert(exception, CPlatform.AppConfig.ServerOptions.IncludeSensitiveDetails);
                if (errorInfo != null)
                {
                    resultMessage.Code = errorInfo.Code;
                    resultMessage.Message = errorInfo.Message;
                    resultMessage.Details = errorInfo.Details;
                    resultMessage.ValidationErrors = errorInfo.ValidationErrors;
                    resultMessage.StatusCode = (int)StatusCode.ServerError;
                }

                _logger.LogError($"执行远程调用逻辑时候发生了错误：RoutePath：{httpMessage.RoutePath}，Message：{exception.Message}，StackTrace：{exception.StackTrace}");
            }

            return resultMessage;
        }

        private async Task<HttpResultMessage<object>> LocalExecuteAsync(ServiceEntry entry, HttpRequestMessage httpMessage)
        {
            var resultMessage = new HttpResultMessage<object>();
            try
            {
                var result = await entry.Func(httpMessage.ServiceKey, httpMessage.Parameters);
                var task = result as Task;

                if (task == null)
                {
                    resultMessage.Result = result;
                }
                else
                {
                    task.Wait();
                    var taskType = task.GetType().GetTypeInfo();
                    if (taskType.IsGenericType)
                    {
                        resultMessage.Result = taskType.GetProperty("Result")?.GetValue(task);
                    }
                }

                resultMessage.IsSucceed = resultMessage.Result != null;
                resultMessage.StatusCode = resultMessage.IsSucceed ? (int)StatusCode.Success : (int)StatusCode.RequestError;
            }
            catch (Exception exception)
            {
                resultMessage.Message = "执行发生了错误";
                resultMessage.Code = exception.HResult.ToString();
                resultMessage.StatusCode = (int)StatusCode.ServerError;
                var errorInfo = _errorInfoConverter.Convert(exception, CPlatform.AppConfig.ServerOptions.IncludeSensitiveDetails);
                if (errorInfo != null)
                {
                    resultMessage.Code = errorInfo.Code;
                    resultMessage.Message = errorInfo.Message;
                    resultMessage.Details = errorInfo.Details;
                    resultMessage.ValidationErrors = errorInfo.ValidationErrors;
                    resultMessage.StatusCode = (int)StatusCode.ServerError;
                }
                
                _logger.LogError($"执行本地调用逻辑时候发生了错误：RoutePath：{httpMessage.RoutePath}，Message：{exception.Message}，StackTrace：{exception.StackTrace}");
            }

            return resultMessage;
        }

        private async Task SendRemoteInvokeResult(IMessageSender sender, string messageId, HttpResultMessage resultMessage)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                {
                    _logger.LogTrace("准备发送响应消息。");
                }

                await sender.SendAndFlushAsync(new TransportMessage(messageId, resultMessage));
                _logger.LogTrace("响应消息发送成功。");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"发送响应消息时候发生了异常。{exception.StackTrace}");
            }
            finally
            {
                RpcContext.RemoveContext();
            }
        }

        private static void SetCurrentCulture()
        {
            var defaultCulture = "zh-Hans";
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(defaultCulture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(defaultCulture);

            var currentCulture = CultureInfo.CurrentCulture.Name == "zh"?defaultCulture:CultureInfo.CurrentCulture.Name;
            var currentUICulture = CultureInfo.CurrentUICulture.Name == "zh"?defaultCulture:CultureInfo.CurrentUICulture.Name;
            RpcContext.GetContext().SetAttachment("CurrentCulture", CultureInfo.CurrentCulture.Name);
            RpcContext.GetContext().SetAttachment("CurrentUICulture", CultureInfo.CurrentUICulture.Name);
            CultureInfo.CurrentCulture = new CultureInfo(currentCulture);
            CultureInfo.CurrentUICulture = new CultureInfo(currentUICulture);
        }

        private void WirteDiagnostic(TransportMessage message)
        {
            if (!CPlatform.AppConfig.ServerOptions.DisableDiagnostic)
            {
                var remoteInvokeMessage = message.GetContent<HttpRequestMessage>();
                var peerAddress = RestContext.GetContext().GetAttachment("RemoteIpAddress");
                _diagnosticListener.WriteTransportStart(TransportType.Rest, new TransportEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id,
                    MessageName = remoteInvokeMessage.RoutePath
                }, TransportType.Rest.ToString(),
                    new TracingHeaders(),
                    peerAddress?.ToString()));
            }
        }

        #endregion Private Method
    }
}
