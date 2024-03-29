using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KissU.Convertibles;
using KissU.CPlatform;
using KissU.CPlatform.Filters;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport;
using KissU.Dependency;
using KissU.Exceptions.Handling;
using KissU.ServiceProxy;
using KissUtil.Helpers;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Http
{
    /// <summary>
    /// HttpServiceExecutor.
    /// Implements the <see cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    public class HttpServiceExecutor : IServiceExecutor
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpServiceExecutor" /> class.
        /// </summary>
        /// <param name="serviceEntryLocate">The service entry locate.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="authorizationFilter">The authorization filter.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        public HttpServiceExecutor(IServiceEntryLocate serviceEntryLocate, IServiceRouteProvider serviceRouteProvider,
            IAuthorizationFilter authorizationFilter,
            IExceptionToErrorInfoConverter  errorInfoConverter,
            ILogger<HttpServiceExecutor> logger, CPlatformContainer serviceProvider,
            ITypeConvertibleService typeConvertibleService)
        {
            _serviceEntryLocate = serviceEntryLocate;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _errorInfoConverter = errorInfoConverter;
            _typeConvertibleService = typeConvertibleService;
            _serviceRouteProvider = serviceRouteProvider;
            _authorizationFilter = authorizationFilter;
        }

        #endregion Constructor

        #region Implementation of IServiceExecutor

        /// <summary>
        /// 执行。
        /// </summary>
        /// <param name="sender">消息发送者。</param>
        /// <param name="message">调用消息。</param>
        public async Task ExecuteAsync(IMessageSender sender, TransportMessage message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace("服务提供者接收到消息。");

            if (!message.IsHttpMessage())
                return;
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

            var entry = _serviceEntryLocate.Locate(httpMessage);
            if (entry == null)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError($"根据服务routePath：{httpMessage.RoutePath}，找不到服务条目。");
                return;
            }

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace("准备执行本地逻辑。");
            var httpResultMessage = new HttpResultMessage<object>();

            if (_serviceProvider.IsRegisteredWithKey(httpMessage.ServiceKey, entry.Type))
            {
                //执行本地代码。
                httpResultMessage = await LocalExecuteAsync(entry, httpMessage);
            }
            else
            {
                httpResultMessage = await RemoteExecuteAsync(entry, httpMessage);
            }

            await SendRemoteInvokeResult(sender, httpResultMessage);
        }

        #endregion Implementation of IServiceExecutor

        #region Field

        private readonly IServiceEntryLocate _serviceEntryLocate;
        private readonly ILogger<HttpServiceExecutor> _logger;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly IAuthorizationFilter _authorizationFilter;
        private readonly CPlatformContainer _serviceProvider;
        private readonly IExceptionToErrorInfoConverter _errorInfoConverter;
        private readonly ITypeConvertibleService _typeConvertibleService;

        private readonly ConcurrentDictionary<string, ValueTuple<FastInvoke.FastInvokeHandler, object, MethodInfo>> _concurrent =
            new ConcurrentDictionary<string, ValueTuple<FastInvoke.FastInvokeHandler, object, MethodInfo>>();

        #endregion Field

        #region Private Method

        private async Task<HttpResultMessage<object>> RemoteExecuteAsync(ServiceEntry entry,
            HttpRequestMessage httpMessage)
        {
            var resultMessage = new HttpResultMessage<object>();
            var provider = _concurrent.GetValueOrDefault(httpMessage.RoutePath);
            var list = new List<object>();
            if (provider.Item1 == null)
            {
                provider.Item2 = ServiceLocator.GetService<IServiceProxyFactory>()
                    .CreateProxy(httpMessage.ServiceKey, entry.Type);
                provider.Item3 = provider.Item2.GetType().GetTypeInfo().DeclaredMethods
                    .Where(p => p.Name == entry.MethodName).FirstOrDefault();
                ;
                provider.Item1 = FastInvoke.GetMethodInvoker(provider.Item3);
                _concurrent.GetOrAdd(httpMessage.RoutePath,
                    ValueTuple.Create(provider.Item1, provider.Item2, provider.Item3));
            }

            foreach (var parameterInfo in provider.Item3.GetParameters())
            {
                var value = httpMessage.Parameters[parameterInfo.Name];
                var parameterType = parameterInfo.ParameterType;
                var parameter = _typeConvertibleService.Convert(value, parameterType);
                list.Add(parameter);
            }

            try
            {
                var methodResult = provider.Item1(provider.Item2, list.ToArray());

                var task = methodResult as Task;
                if (task == null)
                {
                    resultMessage.Result = methodResult;
                }
                else
                {
                    await task;
                    var taskType = task.GetType().GetTypeInfo();
                    if (taskType.IsGenericType)
                        resultMessage.Result = taskType.GetProperty("Result")?.GetValue(task);
                }

                resultMessage.IsSucceed = resultMessage.Result != null;
                resultMessage.StatusCode = resultMessage.IsSucceed ? (int)StatusCode.Success : (int)StatusCode.RequestError;
            }
            catch (Exception exception)
            {
                resultMessage.Message = "执行发生了错误";
                resultMessage.Code = exception.HResult.ToString();
                resultMessage.StatusCode = (int)StatusCode.ServerError;
                var errorInfo = _errorInfoConverter.Convert(exception, AppConfig.ServerOptions.IncludeSensitiveDetails);
                if (errorInfo != null)
                {
                    resultMessage.Code = errorInfo.Code;
                    resultMessage.Message = errorInfo.Message;
                    resultMessage.Details = errorInfo.Details;
                    resultMessage.ValidationErrors = errorInfo.ValidationErrors;
                    resultMessage.StatusCode = (int)StatusCode.ServerError;
                }

                if (_logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogError($"执行远程调用逻辑时候发生了错误：RoutePath：{entry.RoutePath}，Message：{exception.Message}，StackTrace：{exception.StackTrace}");
                }
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
                    resultMessage.Result = result;
                }
                else
                {
                    task.Wait();
                    var taskType = task.GetType().GetTypeInfo();
                    if (taskType.IsGenericType)
                        resultMessage.Result = taskType.GetProperty("Result").GetValue(task);
                }

                resultMessage.IsSucceed = resultMessage.Result != null;
                resultMessage.StatusCode = resultMessage.IsSucceed ? (int)StatusCode.Success : (int)StatusCode.RequestError;
            }
            catch (Exception exception)
            {
                resultMessage.Message = "执行发生了错误";
                resultMessage.Code = exception.HResult.ToString();
                resultMessage.StatusCode = (int)StatusCode.ServerError;
                var errorInfo = _errorInfoConverter.Convert(exception, AppConfig.ServerOptions.IncludeSensitiveDetails);
                if (errorInfo != null)
                {
                    resultMessage.Code = errorInfo.Code;
                    resultMessage.Message = errorInfo.Message;
                    resultMessage.Details = errorInfo.Details;
                    resultMessage.ValidationErrors = errorInfo.ValidationErrors;
                    resultMessage.StatusCode = (int)StatusCode.ServerError;
                }

                if (_logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogError($"执行本地调用逻辑时候发生了错误：RoutePath：{entry.RoutePath}，Message：{exception.Message}，StackTrace：{exception.StackTrace}");
                }
            }

            return resultMessage;
        }

        private async Task SendRemoteInvokeResult(IMessageSender sender, HttpResultMessage resultMessage)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace("准备发送响应消息。");

                await sender.SendAndFlushAsync(new TransportMessage(resultMessage));
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace("响应消息发送成功。");
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError(exception, $"发送响应消息时候发生了异常：{exception.StackTrace}");
            }
        }

        #endregion Private Method
    }
}
