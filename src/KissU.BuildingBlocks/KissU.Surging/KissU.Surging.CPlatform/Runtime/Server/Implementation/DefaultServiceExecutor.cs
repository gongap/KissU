using System;
using System.Reflection;
using System.Threading.Tasks;
using KissU.Core.Utilities;
using KissU.Surging.CPlatform.Filters;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.CPlatform.Transport;
using KissU.Surging.CPlatform.Transport.Implementation;
using KissU.Surging.CPlatform.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KissU.Surging.CPlatform.Runtime.Server.Implementation
{
    /// <summary>
    /// 默认服务执行器.
    /// Implements the <see cref="IServiceExecutor" />
    /// </summary>
    /// <seealso cref="IServiceExecutor" />
    public class DefaultServiceExecutor : IServiceExecutor
    {
        private readonly IAuthorizationFilter _authorizationFilter;
        private readonly ILogger<DefaultServiceExecutor> _logger;
        private readonly IServiceEntryLocate _serviceEntryLocate;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceExecutor" /> class.
        /// </summary>
        /// <param name="serviceEntryLocate">The service entry locate.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="authorizationFilter">The authorization filter.</param>
        /// <param name="logger">The logger.</param>
        public DefaultServiceExecutor(IServiceEntryLocate serviceEntryLocate,
            IServiceRouteProvider serviceRouteProvider, IAuthorizationFilter authorizationFilter,
            ILogger<DefaultServiceExecutor> logger)
        {
            _serviceEntryLocate = serviceEntryLocate;
            _logger = logger;
            _serviceRouteProvider = serviceRouteProvider;
            _authorizationFilter = authorizationFilter;
        }

        /// <summary>
        /// 执行。
        /// </summary>
        /// <param name="sender">消息发送者。</param>
        /// <param name="message">调用消息。</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public async Task ExecuteAsync(IMessageSender sender, TransportMessage message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace("服务提供者接收到消息。");
            }

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
                _logger.LogError(exception, "将接收到的消息反序列化成 TransportMessage<RemoteInvokeMessage> 时发送了错误。");
                return;
            }

            var entry = _serviceEntryLocate.Locate(remoteInvokeMessage);
            if (entry == null)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError($"根据服务Id：{remoteInvokeMessage.ServiceId}，找不到服务条目。");
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
                _logger.LogDebug("准备执行本地逻辑。");
            }

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
                await Task.Factory.StartNew(
                    async () =>
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
                    !(resultMessage.Result is IConvertible && UtilityType.ConvertibleType.GetTypeInfo()
                          .IsAssignableFrom(resultMessage.Result.GetType())))
                {
                    resultMessage.Result = JsonConvert.SerializeObject(resultMessage.Result);
                }
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, "执行本地逻辑时候发生了错误。");
                }

                resultMessage.ExceptionMessage = GetExceptionMessage(exception);
                resultMessage.StatusCode = exception.HResult;
            }
        }

        private async Task SendRemoteInvokeResult(IMessageSender sender, string messageId,
            RemoteInvokeResultMessage resultMessage)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug("准备发送响应消息。");
                }

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
                    _logger.LogError(exception, "发送响应消息时候发生了异常。");
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
    }
}