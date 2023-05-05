using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using KissU.CPlatform.Filters;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Transport;
using KissU.CPlatform.Transport.Implementation;
using KissU.Exceptions.Handling;
using Microsoft.Extensions.Logging;
using System.Globalization;
using KissU.CPlatform.Diagnostics;
using KissU.Serialization;
using KissUtil.Extensions;
using KissUtil.Helpers;

namespace KissU.CPlatform.Runtime.Server.Implementation
{
    /// <summary>
    /// 默认服务执行器.
    /// Implements the <see cref="IServiceExecutor" />
    /// </summary>
    /// <seealso cref="IServiceExecutor" />
    public class DefaultServiceExecutor : IServiceExecutor
    {
        private readonly IAuthorizationFilter _authorizationFilter;
        private readonly IExceptionToErrorInfoConverter _errorInfoConverter;
        private readonly ILogger<DefaultServiceExecutor> _logger;
        private readonly IServiceEntryLocate _serviceEntryLocate;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly DiagnosticListener _diagnosticListener;
        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceExecutor" /> class.
        /// </summary>
        /// <param name="serviceEntryLocate">The service entry locate.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="authorizationFilter">The authorization filter.</param>
        /// <param name="errorInfoConverter"></param>
        /// <param name="logger">The logger.</param>
        public DefaultServiceExecutor(IServiceEntryLocate serviceEntryLocate,ISerializer<string> serializer,
            IServiceRouteProvider serviceRouteProvider, IAuthorizationFilter authorizationFilter, IExceptionToErrorInfoConverter errorInfoConverter,
            ILogger<DefaultServiceExecutor> logger)
        {
            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rpc));
            _serviceEntryLocate = serviceEntryLocate;
            _serializer = serializer;
            _logger = logger;
            _serviceRouteProvider = serviceRouteProvider;
            _authorizationFilter = authorizationFilter;
            _errorInfoConverter = errorInfoConverter;
        }

        /// <summary>
        /// 执行。
        /// </summary>
        /// <param name="sender">消息发送者。</param>
        /// <param name="message">调用消息。</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public async Task ExecuteAsync(IMessageSender sender, TransportMessage message)
        {
            if (!message.IsInvokeMessage())
            {
                return;
            }

            RemoteInvokeMessage remoteInvokeMessage;
            try
            {
                remoteInvokeMessage = message.GetContent<RemoteInvokeMessage>();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"将接收到的消息反序列化成 TransportMessage<RemoteInvokeMessage> 时发送了错误：{exception.StackTrace}");
                return;
            }

            var entry = _serviceEntryLocate.Locate(remoteInvokeMessage);
            if (entry == null)
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogWarning($"根据服务Id：{remoteInvokeMessage.ServiceId}，找不到服务条目。");
                }

                return;
            }

            if (remoteInvokeMessage.Attachments != null)
            {
                foreach (var attachment in remoteInvokeMessage.Attachments)
                {
                    RpcContext.GetContext().SetAttachment(attachment.Key, attachment.Value);
                }
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"准备执行本地逻：{entry.RoutePath}");
            }

            SetCurrentCulture();
            WirteDiagnostic(message);

            var resultMessage = new RemoteInvokeResultMessage();

            // 是否需要等待执行。
            if (entry.Descriptor.WaitExecution())
            {
                // 执行本地代码。
                await LocalExecuteAsync(entry, remoteInvokeMessage, resultMessage);

                // 向客户端发送调用结果。
                await SendRemoteInvokeResult(sender, message.Id, resultMessage);
            }
            else
            {
                // 通知客户端已接收到消息。
                await SendRemoteInvokeResult(sender, message.Id, resultMessage);

                // 确保新起一个线程执行，不堵塞当前线程。
                await Task.Factory.StartNew(async () =>
                    {
                        // 执行本地代码。
                        await LocalExecuteAsync(entry, remoteInvokeMessage, resultMessage);
                    }, TaskCreationOptions.LongRunning);
            }
        }

        private async Task LocalExecuteAsync(ServiceEntry entry, RemoteInvokeMessage remoteInvokeMessage,
            RemoteInvokeResultMessage resultMessage)
        {
            try
            {
                var result = await entry.Func(remoteInvokeMessage.ServiceKey, remoteInvokeMessage.Parameters);
                var task = result as Task;

                if (task == null)
                {
                    resultMessage.Result = result;
                }
                else
                {
                    if (!task.IsCompletedSuccessfully)
                    {
                        await task;
                    }

                    var taskType = task.GetType().GetTypeInfo();
                    if (taskType.IsGenericType)
                    {
                        resultMessage.Result = taskType.GetProperty("Result").GetValue(task);
                    }
                }

                if (remoteInvokeMessage.DecodeJObject &&
                    !(resultMessage.Result is IConvertible && TypeHelper.ConvertibleType.GetTypeInfo()
                          .IsAssignableFrom(resultMessage.Result.GetType())))
                {
                    resultMessage.Result = _serializer.Serialize(resultMessage.Result);
                }
            }
            catch (Exception exception)
            {
                resultMessage.StatusCode = exception.HResult;
                var errorInfo = _errorInfoConverter.Convert(exception, AppConfig.ServerOptions.IncludeSensitiveDetails);
                if (errorInfo != null)
                {
                    resultMessage.Code = errorInfo.Code;
                    resultMessage.Message = errorInfo.Message;
                    resultMessage.Details = errorInfo.Details;
                    resultMessage.ValidationErrors = errorInfo.ValidationErrors;
                }
                else
                {
                    resultMessage.Message = exception.Message;
                }

                _logger.LogError($"执行本地调用逻辑时候发生了错误：RoutePath：{entry.RoutePath}，Message：{exception.Message}，StackTrace：{exception.StackTrace}");
            }
            finally
            {
                RpcContext.RemoveContext();
            }
        }

        private async Task SendRemoteInvokeResult(IMessageSender sender, string messageId,
            RemoteInvokeResultMessage resultMessage)
        {
            try
            {
                await sender.SendAndFlushAsync(TransportMessage.CreateInvokeResultMessage(messageId, resultMessage));
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug("响应消息发送成功。");
                }
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, $"响应消息发送异常：{exception.StackTrace}");
                }
            }
        }

        private void SetCurrentCulture()
        {
            var defaultCulture = "zh-Hans";
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(defaultCulture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(defaultCulture);

            var currentCulture = RpcContext.GetContext().GetAttachment("CurrentCulture").SafeString() ?? defaultCulture;
            var currentUICulture = RpcContext.GetContext().GetAttachment("CurrentUICulture").SafeString() ?? currentCulture;
            if (!string.IsNullOrEmpty(currentCulture))
            {
                currentCulture = currentCulture == "zh"?defaultCulture:currentCulture;
                CultureInfo.CurrentCulture = new CultureInfo(currentCulture);
            }

            if (!string.IsNullOrEmpty(currentUICulture))
            {
                currentUICulture = currentUICulture == "zh"?defaultCulture:currentUICulture;
                CultureInfo.CurrentUICulture = new CultureInfo(currentUICulture);
            }
        }
        
        private void WirteDiagnostic(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var remoteInvokeMessage = message.GetContent<RemoteInvokeMessage>();
                remoteInvokeMessage.Attachments.TryGetValue("TracingHeaders", out var tracingHeaders);
                var peerAddress = RpcContext.GetContext().GetAttachment("PeerAddress");
                _diagnosticListener.WriteTransportStart(TransportType.Rpc, new TransportEventData(new DiagnosticMessage
                    {
                        Content = message.Content,
                        ContentType = message.ContentType,
                        Id = message.Id,
                        MessageName = remoteInvokeMessage.ServiceId
                    },
                    remoteInvokeMessage.DecodeJObject ? RpcMethod.Json_Rpc.ToString() : RpcMethod.Proxy_Rpc.ToString(),
                    tracingHeaders as TracingHeaders,
                    peerAddress?.ToString()));
            }
        }
    }
}