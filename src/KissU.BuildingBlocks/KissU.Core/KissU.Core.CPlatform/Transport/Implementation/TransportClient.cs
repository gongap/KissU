﻿using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Diagnostics;
using KissU.Core.CPlatform.Exceptions;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Logging;

namespace KissU.Core.CPlatform.Transport.Implementation
{
    /// <summary>
    /// 一个默认的传输客户端实现。
    /// </summary>
    public class TransportClient : ITransportClient, IDisposable
    {
        #region Field

        private readonly IMessageSender _messageSender;
        private readonly IMessageListener _messageListener;
        private readonly ILogger _logger;
        private readonly IServiceExecutor _serviceExecutor;

        private readonly ConcurrentDictionary<string, ManualResetValueTaskSource<TransportMessage>> _resultDictionary =
            new ConcurrentDictionary<string, ManualResetValueTaskSource<TransportMessage>>();

        #endregion Field

        #region Constructor

        public TransportClient(IMessageSender messageSender, IMessageListener messageListener, ILogger logger,
            IServiceExecutor serviceExecutor)
        {
            _messageSender = messageSender;
            _messageListener = messageListener;
            _logger = logger;
            _serviceExecutor = serviceExecutor;
            messageListener.Received += MessageListener_Received;
        }

        #endregion Constructor

        #region Implementation of ITransportClient

        /// <summary>
        /// 发送消息。
        /// </summary>
        /// <param name="message">远程调用消息模型。</param>
        /// <returns>远程调用消息的传输消息。</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task<RemoteInvokeResultMessage> SendAsync(RemoteInvokeMessage message, CancellationToken cancellationToken)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug("准备发送消息。");

                var transportMessage = TransportMessage.CreateInvokeMessage(message);
                WirteDiagnosticBefore(transportMessage);
                //注册结果回调
                var callbackTask = RegisterResultCallbackAsync(transportMessage.Id,cancellationToken);

                try
                {
                    //发送
                    await _messageSender.SendAndFlushAsync(transportMessage);
                }
                catch (Exception exception)
                {
                    throw new CommunicationException("与服务端通讯时发生了异常。", exception);
                }

                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug("消息发送成功。");

                return await callbackTask;
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError(exception, "消息发送失败。");
                throw;
            }
        }

        #endregion Implementation of ITransportClient

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            (_messageSender as IDisposable)?.Dispose();
            (_messageListener as IDisposable)?.Dispose();
            foreach (var taskCompletionSource in _resultDictionary.Values)
            {
                taskCompletionSource.SetCanceled();
            }
        }

        #endregion Implementation of IDisposable

        #region Private Method

        /// <summary>
        /// 注册指定消息的回调任务。
        /// </summary>
        /// <param name="id">消息Id。</param>
        /// <returns>远程调用结果消息模型。</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<RemoteInvokeResultMessage> RegisterResultCallbackAsync(string id, CancellationToken cancellationToken)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"准备获取Id为：{id}的响应内容。");

            var task = new ManualResetValueTaskSource<TransportMessage>();
            _resultDictionary.TryAdd(id, task);
            try
            {
                var result = await task.AwaitValue(cancellationToken);
                return result.GetContent<RemoteInvokeResultMessage>();
            }
            finally
            {
                //删除回调任务
                ManualResetValueTaskSource<TransportMessage> value;
                _resultDictionary.TryRemove(id, out value);
                value.SetCanceled();
            }
        }

        private async Task MessageListener_Received(IMessageSender sender, TransportMessage message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace("服务消费者接收到消息。");

            ManualResetValueTaskSource<TransportMessage> task;
            if (!_resultDictionary.TryGetValue(message.Id, out task))
                return;

            if (message.IsInvokeResultMessage())
            {
                var content = message.GetContent<RemoteInvokeResultMessage>();
                if (!string.IsNullOrEmpty(content.ExceptionMessage))
                {
                    task.SetException(new CPlatformCommunicationException(content.ExceptionMessage,content.StatusCode));
                    WirteDiagnosticError(message);
                }
                else
                {
                    task.SetResult(message);
                    WirteDiagnosticAfter(message);
                }
            }
            if (_serviceExecutor != null && message.IsInvokeMessage())
                await _serviceExecutor.ExecuteAsync(sender, message);
        }


        private void WirteDiagnosticBefore(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
                var remoteInvokeMessage = message.GetContent<RemoteInvokeMessage>();
                remoteInvokeMessage.Attachments.TryGetValue("TraceId", out object traceId);
                diagnosticListener.WriteTransportBefore(TransportType.Rpc, new TransportEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id,
                    MessageName = remoteInvokeMessage.ServiceId
                }, remoteInvokeMessage.DecodeJOject ? RpcMethod.Json_Rpc.ToString() : RpcMethod.Proxy_Rpc.ToString(),
                 traceId?.ToString(),
                RpcContext.GetContext().GetAttachment("RemoteAddress")?.ToString()));
            }
            var parameters = RpcContext.GetContext().GetContextParameters();
            parameters.TryRemove("RemoteAddress", out object value);
            RpcContext.GetContext().SetContextParameters(parameters);
        }

        private void WirteDiagnosticAfter(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
                var remoteInvokeResultMessage = message.GetContent<RemoteInvokeResultMessage>();
                diagnosticListener.WriteTransportAfter(TransportType.Rpc, new ReceiveEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id
                }));
            }
        }

        private void WirteDiagnosticError(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
                var remoteInvokeResultMessage = message.GetContent<RemoteInvokeResultMessage>();
                diagnosticListener.WriteTransportError(TransportType.Rpc, new TransportErrorEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id
                }, new CPlatformCommunicationException(remoteInvokeResultMessage.ExceptionMessage)));
            }
        }

        #endregion Private Method
    }
}