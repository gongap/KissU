﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;
using KissU.Tools.Cli.Commands;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Thrift;
using Thrift.Protocol;

namespace KissU.Tools.Cli.Internal.Thrift
{
    public class TThriftClient : TBaseClient, ITransportClient
    {

        private readonly IMessageSender _messageSender;
        private readonly IMessageListener _messageListener;
        private readonly ChannelHandler _channelHandler;
        private readonly TProtocol _protocol;

        private readonly ConcurrentDictionary<string, TaskCompletionSource<TransportMessage>> _resultDictionary =
            new ConcurrentDictionary<string, TaskCompletionSource<TransportMessage>>();

        private readonly CommandLineApplication<CurlCommand> _app;

        public TThriftClient(TProtocol protocol, IMessageSender messageSender, IMessageListener messageListener, ChannelHandler channelHandler, CommandLineApplication app) : base(protocol, protocol)
        {
            _app = app as CommandLineApplication<CurlCommand>;
            _messageSender = messageSender;
            _messageListener = messageListener;
            _channelHandler = channelHandler;
            _protocol = protocol;
            messageListener.Received += MessageListener_Received;
        }

        public async Task<RemoteInvokeResultMessage> SendAsync(CancellationToken cancellationToken)
        {
            try
            {
                var def = new Dictionary<string, object>();
                var command = _app.Model;
                var transportMessage = TransportMessage.CreateInvokeMessage(new RemoteInvokeMessage
                {
                    DecodeJObject = true,
                    Parameters = string.IsNullOrEmpty(command.Data) ? def : JsonConvert.DeserializeObject<IDictionary<string, object>>(command.Data),
                    ServiceId = command.ServiceId,
                    ServiceKey = command.ServiceKey,
                    Attachments = string.IsNullOrEmpty(command.Attachments)? def : JsonConvert.DeserializeObject<IDictionary<string, object>>(command.Attachments)
                });
                var callbackTask = RegisterResultCallbackAsync(transportMessage.Id, cancellationToken);
                try
                {

                    //发送
                    await _messageSender.SendAndFlushAsync(transportMessage);
                    await _channelHandler.ChannelRead(_protocol);

                }
                catch (Exception exception)
                {
                    throw ;
                }
                 

                return await callbackTask;
            }
            catch
            {
                throw;
            }
        }


        private async Task<RemoteInvokeResultMessage> RegisterResultCallbackAsync(string id, CancellationToken cancellationToken)
        {
            var task = new TaskCompletionSource<TransportMessage>(cancellationToken);
            _resultDictionary.TryAdd(id, task);
            try
            {
                var result = await task.Task;
                return result.GetContent<RemoteInvokeResultMessage>();
            }
            finally
            {
                //删除回调任务
                TaskCompletionSource<TransportMessage> value;
                _resultDictionary.TryRemove(id, out value);
               //value.SetCanceled();

            }
        }

        private  Task MessageListener_Received(IMessageSender sender, TransportMessage message)
        {
            TaskCompletionSource<TransportMessage> task;
            if (!_resultDictionary.TryGetValue(message.Id, out task))
                return Task.CompletedTask;

            if (message.IsInvokeResultMessage())
            {
                var content = message.GetContent<RemoteInvokeResultMessage>();
                if (!string.IsNullOrEmpty(content.Message))
                { 
                    task.SetException(new Exception(content.Message));
                }
                else
                {
                    task.SetResult(message); 
                }
            }
            return Task.CompletedTask;
        }
    }
}
