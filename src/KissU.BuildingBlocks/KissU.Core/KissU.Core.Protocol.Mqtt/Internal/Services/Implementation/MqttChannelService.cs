using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.Core.CPlatform.Ids;
using KissU.Core.Protocol.Mqtt.Internal.Channel;
using KissU.Core.Protocol.Mqtt.Internal.Enums;
using KissU.Core.Protocol.Mqtt.Internal.Messages;
using KissU.Core.Protocol.Mqtt.Internal.Runtime;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Protocol.Mqtt.Internal.Services.Implementation
{
    /// <summary>
    /// MqttChannelService.
    /// Implements the <see cref="KissU.Core.Protocol.Mqtt.Internal.Services.AbstractChannelService" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.Mqtt.Internal.Services.AbstractChannelService" />
    public class MqttChannelService : AbstractChannelService
    {
        private readonly IClientSessionService _clientSessionService;
        private readonly ILogger<MqttChannelService> _logger;
        private readonly IMessagePushService _messagePushService;
        private readonly IWillService _willService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttChannelService" /> class.
        /// </summary>
        /// <param name="messagePushService">The message push service.</param>
        /// <param name="clientSessionService">The client session service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="willService">The will service.</param>
        /// <param name="mqttBrokerEntryManger">The MQTT broker entry manger.</param>
        /// <param name="mqttRemoteInvokeService">The MQTT remote invoke service.</param>
        /// <param name="serviceIdGenerator">The service identifier generator.</param>
        public MqttChannelService(IMessagePushService messagePushService, IClientSessionService clientSessionService,
            ILogger<MqttChannelService> logger, IWillService willService,
            IMqttBrokerEntryManger mqttBrokerEntryManger,
            IMqttRemoteInvokeService mqttRemoteInvokeService,
            IServiceIdGenerator serviceIdGenerator) :
            base(messagePushService,
                mqttBrokerEntryManger,
                mqttRemoteInvokeService,
                serviceIdGenerator)
        {
            _messagePushService = messagePushService;
            _clientSessionService = clientSessionService;
            _logger = logger;
            _willService = willService;
        }

        /// <summary>
        /// Closes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="isDisconnect">if set to <c>true</c> [is disconnect].</param>
        public override async Task Close(string deviceId, bool isDisconnect)
        {
            if (!string.IsNullOrEmpty(deviceId))
            {
                MqttChannels.TryGetValue(deviceId, out var mqttChannel);
                if (mqttChannel != null)
                {
                    mqttChannel.SessionStatus = SessionStatus.CLOSE;
                    await mqttChannel.Close();
                    mqttChannel.Channel = null;
                }

                if (!mqttChannel.CleanSession)
                {
                    var messages = mqttChannel.Messages;
                    if (messages != null)
                    {
                        foreach (var sendMqttMessage in messages.Values)
                        {
                            if (sendMqttMessage.ConfirmStatus == ConfirmStatus.PUB)
                            {
                                _clientSessionService.SaveMessage(mqttChannel.ClientId, new SessionMessage
                                {
                                    Message = sendMqttMessage.ByteBuf,
                                    QoS = sendMqttMessage.Qos,
                                    Topic = sendMqttMessage.Topic
                                });
                            }
                        }
                    }
                }
                else
                {
                    MqttChannels.TryRemove(deviceId, out var channel);
                    if (mqttChannel.SubscribeStatus == SubscribeStatus.Yes)
                    {
                        RemoveSubTopic(mqttChannel);
                    }

                    mqttChannel.Topics.ForEach(async topic => { await BrokerCancellationReg(topic); });
                }

                if (mqttChannel.IsWill)
                {
                    if (!isDisconnect)
                    {
                        await _willService.SendWillMessage(deviceId);
                    }
                }
            }
        }

        /// <summary>
        /// Connects the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="channel">The channel.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public override async Task<bool> Connect(string deviceId, MqttChannel channel)
        {
            var mqttChannel = GetMqttChannel(deviceId);
            if (mqttChannel != null)
            {
                if (await mqttChannel.IsOnine()) return false;
                if (mqttChannel.SubscribeStatus == SubscribeStatus.Yes)
                {
                    var topics = RemoveSubTopic(mqttChannel);
                    foreach (var topic in topics)
                    {
                        Topics.TryGetValue(topic, out var comparisonValue);
                        var newValue = comparisonValue.Concat(new[] {channel});
                        Topics.AddOrUpdate(topic, newValue, (key, value) => newValue);
                    }
                }
            }

            MqttChannels.AddOrUpdate(deviceId, channel, (k, v) => channel);
            return true;
        }

        /// <summary>
        /// Logins the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="mqttConnectMessage">The MQTT connect message.</param>
        public override async Task Login(IChannel channel, string deviceId, ConnectMessage mqttConnectMessage)
        {
            channel.GetAttribute(LoginAttrKey).Set("login");
            channel.GetAttribute(DeviceIdAttrKey).Set(deviceId);
            await Init(channel, mqttConnectMessage);
        }

        /// <summary>
        /// Publishes the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="mqttPublishMessage">The MQTT publish message.</param>
        public override async Task Publish(IChannel channel, PublishPacket mqttPublishMessage)
        {
            var mqttChannel = GetMqttChannel(await GetDeviceId(channel));
            var buffer = mqttPublishMessage.Payload;
            var bytes = new byte[buffer.ReadableBytes];
            buffer.ReadBytes(bytes);
            var messageId = mqttPublishMessage.PacketId;
            if (channel.HasAttribute(LoginAttrKey) && mqttChannel != null)
            {
                var isRetain = mqttPublishMessage.RetainRequested;
                switch (mqttPublishMessage.QualityOfService)
                {
                    case QualityOfService.AtLeastOnce:
                        await _messagePushService.SendPubBack(channel, messageId);
                        break;
                    case QualityOfService.ExactlyOnce:
                        await Pubrec(mqttChannel, messageId);
                        break;
                }

                if (isRetain)
                {
                    SaveRetain(mqttPublishMessage.TopicName,
                        new RetainMessage
                        {
                            ByteBuf = bytes,
                            QoS = (int) mqttPublishMessage.QualityOfService
                        }, mqttPublishMessage.QualityOfService == QualityOfService.AtMostOnce ? true : false);
                }

                await PushMessage(mqttPublishMessage.TopicName, (int) mqttPublishMessage.QualityOfService, bytes,
                    isRetain);
                await RemotePublishMessage("", new MqttWillMessage
                {
                    Qos = (int) mqttPublishMessage.QualityOfService,
                    Topic = mqttPublishMessage.TopicName,
                    WillMessage = Encoding.Default.GetString(bytes),
                    WillRetain = mqttPublishMessage.RetainRequested
                });
            }
        }

        /// <summary>
        /// Publishes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="willMessage">The will message.</param>
        public override async Task Publish(string deviceId, MqttWillMessage willMessage)
        {
            if (!string.IsNullOrEmpty(deviceId))
            {
                var mqttChannel = GetMqttChannel(deviceId);
                if (mqttChannel != null && await mqttChannel.IsOnine())
                {
                    await _messagePushService.WriteWillMsg(mqttChannel, willMessage);
                }
            }
            else
            {
                await SendWillMsg(willMessage);
            }

            if (willMessage.WillRetain)
                SaveRetain(willMessage.Topic, new RetainMessage
                    {
                        ByteBuf = Encoding.UTF8.GetBytes(willMessage.WillMessage),
                        QoS = willMessage.Qos
                    }, willMessage.Qos == 0 ? true : false);
        }

        private async Task PushMessage(string topic, int qos, byte[] bytes, bool isRetain)
        {
            Topics.TryGetValue(topic, out var mqttChannels);
            if (mqttChannels != null && mqttChannels.Any())
            {
                foreach (var mqttChannel in mqttChannels)
                {
                    if (await mqttChannel.IsOnine())
                    {
                        if (mqttChannel.IsActive())
                        {
                            await SendMessage(mqttChannel, qos,
                                topic, bytes);
                        }
                        else
                        {
                            if (!mqttChannel.CleanSession && !isRetain)
                            {
                                _clientSessionService.SaveMessage(mqttChannel.ClientId,
                                    new SessionMessage
                                    {
                                        Message = bytes,
                                        QoS = qos,
                                        Topic = topic
                                    });
                                break;
                            }
                        }
                    }
                    else
                    {
                        _clientSessionService.SaveMessage(mqttChannel.ClientId,
                            new SessionMessage
                            {
                                Message = bytes,
                                QoS = qos,
                                Topic = topic
                            });
                    }
                }
            }
        }

        /// <summary>
        /// Pubrecs the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        public override async Task Pubrec(MqttChannel channel, int messageId)
        {
            await _messagePushService.SendPubRec(channel, messageId);
        }

        /// <summary>
        /// Pubrels the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        public override async Task Pubrel(IChannel channel, int messageId)
        {
            if (MqttChannels.TryGetValue(await GetDeviceId(channel), out var mqttChannel))
            {
                if (mqttChannel.IsLogin())
                {
                    mqttChannel.RemoveMqttMessage(messageId);
                    await _messagePushService.SendToPubComp(channel, messageId);
                }
            }
        }

        /// <summary>
        /// Pings the req.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>ValueTask.</returns>
        public override async ValueTask PingReq(IChannel channel)
        {
            if (MqttChannels.TryGetValue(await GetDeviceId(channel), out var mqttChannel))
            {
                if (mqttChannel.IsLogin())
                {
                    mqttChannel.PingReqTime = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Sends the will MSG.
        /// </summary>
        /// <param name="willMeaasge">The will meaasge.</param>
        public override async Task SendWillMsg(MqttWillMessage willMeaasge)
        {
            Topics.TryGetValue(willMeaasge.Topic, out var mqttChannels);
            if (mqttChannels != null && mqttChannels.Any())
            {
                foreach (var mqttChannel in mqttChannels)
                {
                    if (!await mqttChannel.IsOnine())
                    {
                        _clientSessionService.SaveMessage(mqttChannel.ClientId, new SessionMessage
                        {
                            Message = Encoding.UTF8.GetBytes(willMeaasge.WillMessage),
                            QoS = willMeaasge.Qos,
                            Topic = willMeaasge.Topic
                        });
                    }
                    else
                    {
                        await _messagePushService.WriteWillMsg(mqttChannel, willMeaasge);
                    }
                }
            }
        }

        /// <summary>
        /// Suscribes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="topics">The topics.</param>
        public override async Task Suscribe(string deviceId, params string[] topics)
        {
            if (!string.IsNullOrEmpty(deviceId))
            {
                MqttChannels.TryGetValue(deviceId, out var mqttChannel);
                mqttChannel.SubscribeStatus = SubscribeStatus.Yes;
                mqttChannel.AddTopic(topics);
                if (mqttChannel.IsLogin())
                {
                    foreach (var topic in topics)
                    {
                        AddChannel(topic, mqttChannel);
                        await RegisterMqttBroker(topic);
                        await SendRetain(topic, mqttChannel);
                    }
                }
            }
        }

        /// <summary>
        /// Uns the subscribe.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="topics">The topics.</param>
        public override async Task UnSubscribe(string deviceId, params string[] topics)
        {
            if (MqttChannels.TryGetValue(deviceId, out var mqttChannel))
            {
                foreach (var topic in topics)
                {
                    RemoveChannel(topic, mqttChannel);
                    await BrokerCancellationReg(topic);
                }
            }
        }

        /// <summary>
        /// Sends the retain.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="mqttChannel">The MQTT channel.</param>
        public async Task SendRetain(string topic, MqttChannel mqttChannel)
        {
            Retain.TryGetValue(topic, out var retainMessages);
            if (retainMessages != null && !retainMessages.IsEmpty)
            {
                var messages = retainMessages.GetEnumerator();
                while (messages.MoveNext())
                {
                    var retainMessage = messages.Current;
                    await SendMessage(mqttChannel, retainMessage.QoS, topic, retainMessage.ByteBuf);
                }

                ;
            }
        }

        private void SaveRetain(string topic, RetainMessage retainMessage, bool isClean)
        {
            Retain.TryGetValue(topic, out var retainMessages);
            if (retainMessages == null) retainMessages = new ConcurrentQueue<RetainMessage>();
            if (!retainMessages.IsEmpty && isClean)
            {
                retainMessages.Clear();
            }

            retainMessages.Enqueue(retainMessage);
            Retain.AddOrUpdate(topic, retainMessages, (key, value) => retainMessages);
        }

        /// <summary>
        /// Removes the sub topic.
        /// </summary>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <returns>IEnumerable&lt;String&gt;.</returns>
        public IEnumerable<string> RemoveSubTopic(MqttChannel mqttChannel)
        {
            IEnumerable<string> topics = mqttChannel.Topics;
            foreach (var topic in topics)
            {
                Topics.TryGetValue(topic, out var comparisonValue);
                var newValue = comparisonValue.Where(p => p != mqttChannel);
                Topics.TryUpdate(topic, newValue, comparisonValue);
            }

            return topics;
        }

        private async Task SendMessage(MqttChannel mqttChannel, int qos, string topic, byte[] byteBuf)
        {
            switch (qos)
            {
                case 0:
                    await _messagePushService.SendQos0Msg(mqttChannel.Channel, topic, byteBuf);
                    break;
                case 1:
                    await _messagePushService.SendQosConfirmMsg(QualityOfService.AtLeastOnce, mqttChannel, topic,
                        byteBuf);
                    break;
                case 2:
                    await _messagePushService.SendQosConfirmMsg(QualityOfService.ExactlyOnce, mqttChannel, topic,
                        byteBuf);
                    break;
            }
        }

        private async Task Init(IChannel channel, ConnectMessage mqttConnectMessage)
        {
            var deviceId = await GetDeviceId(channel);
            var mqttChannel = new MqttChannel
            {
                Channel = channel,
                KeepAliveInSeconds = mqttConnectMessage.KeepAliveInSeconds,
                CleanSession = mqttConnectMessage.CleanSession,
                ClientId = mqttConnectMessage.ClientId,
                SessionStatus = SessionStatus.OPEN,
                IsWill = mqttConnectMessage.HasWill,
                SubscribeStatus = SubscribeStatus.No,
                Messages = new ConcurrentDictionary<int, SendMqttMessage>(),
                Topics = new List<string>()
            };
            if (await Connect(deviceId, mqttChannel))
            {
                if (mqttConnectMessage.HasWill)
                {
                    if (mqttConnectMessage.WillMessage == null || string.IsNullOrEmpty(mqttConnectMessage.WillTopic))
                    {
                        if (_logger.IsEnabled(LogLevel.Error))
                            _logger.LogError("WillMessage 和 WillTopic不能为空");
                        return;
                    }

                    var willMessage = new MqttWillMessage
                    {
                        Qos = mqttConnectMessage.Qos,
                        WillRetain = mqttConnectMessage.WillRetain,
                        Topic = mqttConnectMessage.WillTopic,
                        WillMessage = Encoding.UTF8.GetString(mqttConnectMessage.WillMessage)
                    };
                    _willService.Add(mqttConnectMessage.ClientId, willMessage);
                }
                else
                {
                    _willService.Remove(mqttConnectMessage.ClientId);
                    if (!mqttConnectMessage.WillRetain && mqttConnectMessage.WillQualityOfService != 0)
                    {
                        if (_logger.IsEnabled(LogLevel.Error))
                            _logger.LogError("WillRetain 设置为false,WillQos必须设置为AtMostOnce");
                        return;
                    }
                }

                await channel.WriteAndFlushAsync(new ConnAckPacket
                {
                    ReturnCode = ConnectReturnCode.Accepted,
                    SessionPresent = !mqttConnectMessage.CleanSession
                });
                var sessionMessages = _clientSessionService.GetMessages(mqttConnectMessage.ClientId);
                if (sessionMessages != null && !sessionMessages.IsEmpty)
                {
                    for (; sessionMessages.TryDequeue(out var sessionMessage) && sessionMessage != null;)
                    {
                        switch (sessionMessage.QoS)
                        {
                            case 0:
                                await _messagePushService.SendQos0Msg(channel, sessionMessage.Topic,
                                    sessionMessage.Message);
                                break;
                            case 1:
                                await _messagePushService.SendQosConfirmMsg(QualityOfService.AtLeastOnce,
                                    GetMqttChannel(deviceId), sessionMessage.Topic, sessionMessage.Message);
                                break;
                            case 2:
                                await _messagePushService.SendQosConfirmMsg(QualityOfService.ExactlyOnce,
                                    GetMqttChannel(deviceId), sessionMessage.Topic, sessionMessage.Message);
                                break;
                        }
                    }
                }
            }
        }
    }
}