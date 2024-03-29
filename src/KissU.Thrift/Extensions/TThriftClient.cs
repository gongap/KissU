﻿using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using KissU.Exceptions;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.Extensions;
using KissUtil.TaskSources;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Protocol;

namespace KissU.Thrift.Extensions
{
   public class TThriftClient : TBaseClient, ITransportClient, IDisposable
    {
        #region Field

        private readonly IMessageSender _messageSender; 
        private readonly ILogger _logger;
        private readonly ChannelHandler _channelHandler;
        private readonly DiagnosticListener _diagnosticListener;
        private readonly TProtocol _protocol;
        private readonly ConcurrentDictionary<string, ManualResetValueTaskSource<TransportMessage>> _resultDictionary =
           new ConcurrentDictionary<string, ManualResetValueTaskSource<TransportMessage>>();
        #endregion Field

        #region Constructor

        public TThriftClient(TProtocol protocol, IMessageSender messageSender, IMessageListener messageListener, ChannelHandler channelHandler, ILogger logger ):base(protocol, protocol)
        {

            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rpc));
            _messageSender = messageSender;
            _channelHandler = channelHandler;
            _logger = logger;
            _protocol = protocol;
            messageListener.Received += MessageListener_Received;
        }

        #endregion

        public async Task<RemoteInvokeResultMessage> SendAsync(RemoteInvokeMessage message, CancellationToken cancellationToken)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogTrace("准备发送消息。");

                var transportMessage = TransportMessage.CreateInvokeMessage(message);
                WirteDiagnosticBefore(transportMessage);
                var callbackTask = RegisterResultCallbackAsync(transportMessage.Id, cancellationToken);
                try
                {
                  
                    //发送
                    await _messageSender.SendAndFlushAsync(transportMessage);
                    await _channelHandler.ChannelRead(_protocol);
                    
                }
                catch (Exception exception)
                {
                    throw new CommunicationException("与服务端通讯时发生了异常。", exception);
                }

                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace("消息发送成功。");

                return await callbackTask;
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                {
                    _logger.LogTrace(exception, $"消息发送失败。错误信息：{exception.Message}");
                }

                throw;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<RemoteInvokeResultMessage> RegisterResultCallbackAsync(string id, CancellationToken cancellationToken)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace($"准备获取Id为：{id}的响应内容。");

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

        private  Task MessageListener_Received(IMessageSender sender, TransportMessage message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace("服务消费者接收到消息。");

            ManualResetValueTaskSource<TransportMessage> task;
            if (!_resultDictionary.TryGetValue(message.Id, out task))
                return Task.CompletedTask;

            if (message.IsInvokeResultMessage())
            {
                var content = message.GetContent<RemoteInvokeResultMessage>();
                if (!string.IsNullOrEmpty(content.Message))
                {
                    WirteDiagnosticError(message);
                    task.SetException(new CPlatformCommunicationException(content.Message, content.Code,  content.Details, content.ValidationErrors, statusCode:content.StatusCode));
                }
                else
                {
                    task.SetResult(message);
                    WirteDiagnosticAfter(message);
                }
            }
            return Task.CompletedTask;
        }


        private void WirteDiagnosticBefore(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var remoteInvokeMessage = message.GetContent<RemoteInvokeMessage>();
                remoteInvokeMessage.Attachments.TryTakeValue("RemoteAddress", out var remoteAddress);
                _diagnosticListener.WriteTransportBefore(TransportType.Rpc, new TransportEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id,
                    MessageName = remoteInvokeMessage.ServiceId
                }, remoteInvokeMessage.DecodeJObject ? RpcMethod.Json_Rpc.ToString() : RpcMethod.Proxy_Rpc.ToString(),
                    new TracingHeaders(),
                    remoteAddress?.ToString()));
            }
        }

        private void WirteDiagnosticAfter(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                _diagnosticListener.WriteTransportAfter(TransportType.Rpc, new ReceiveEventData(new DiagnosticMessage
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
                _diagnosticListener.WriteTransportError(TransportType.Rpc, new TransportErrorEventData(new DiagnosticMessage
                {
                    Content = message.Content,
                    ContentType = message.ContentType,
                    Id = message.Id
                }, new CPlatformCommunicationException(message.GetContent<RemoteInvokeResultMessage>().Message)));
            }
        }

        public new void Dispose()
        {
            (_messageSender as IDisposable)?.Dispose(); 
            foreach (var taskCompletionSource in _resultDictionary.Values)
            {
                taskCompletionSource.SetCanceled();
            }
            base.Dispose();
            _protocol.Dispose();
        }
    }
}
