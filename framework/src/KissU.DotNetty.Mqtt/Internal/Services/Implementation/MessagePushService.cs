using System;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.DotNetty.Mqtt.Internal.Channel;
using KissU.DotNetty.Mqtt.Internal.Enums;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.DotNetty.Mqtt.Internal.Runtime;
using KissU.DotNetty.Mqtt.Util;

namespace KissU.DotNetty.Mqtt.Internal.Services.Implementation
{
    /// <summary>
    /// MessagePushService.
    /// Implements the <see cref="IMessagePushService" />
    /// </summary>
    /// <seealso cref="IMessagePushService" />
    public class MessagePushService : IMessagePushService
    {
        private readonly ScanRunnable _scanRunnable;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePushService" /> class.
        /// </summary>
        /// <param name="scanRunnable">The scan runnable.</param>
        public MessagePushService(ScanRunnable scanRunnable)
        {
            _scanRunnable = scanRunnable;
        }

        /// <summary>
        /// Writes the will MSG.
        /// </summary>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <param name="willMeaasge">The will meaasge.</param>
        public async Task WriteWillMsg(MqttChannel mqttChannel, MqttWillMessage willMeaasge)
        {
            switch (willMeaasge.Qos)
            {
                case 0:
                    await SendQos0Msg(mqttChannel.Channel, willMeaasge.Topic,
                        Encoding.Default.GetBytes(willMeaasge.WillMessage));
                    break;
                case 1: // qos1
                    await SendQosConfirmMsg(QualityOfService.AtLeastOnce, mqttChannel, willMeaasge.Topic,
                        Encoding.Default.GetBytes(willMeaasge.WillMessage));
                    break;
                case 2: // qos2
                    await SendQosConfirmMsg(QualityOfService.ExactlyOnce, mqttChannel, willMeaasge.Topic,
                        Encoding.Default.GetBytes(willMeaasge.WillMessage));
                    break;
            }
        }

        /// <summary>
        /// Sends the qos confirm MSG.
        /// </summary>
        /// <param name="qos">The qos.</param>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <param name="topic">The topic.</param>
        /// <param name="bytes">The bytes.</param>
        public async Task SendQosConfirmMsg(QualityOfService qos, MqttChannel mqttChannel, string topic, byte[] bytes)
        {
            if (mqttChannel.IsLogin())
            {
                var messageId = MessageIdGenerater.GenerateId();
                switch (qos)
                {
                    case QualityOfService.AtLeastOnce:
                        mqttChannel.AddMqttMessage(messageId,
                            await SendQos1Msg(mqttChannel.Channel, topic, false, bytes, messageId));
                        break;
                    case QualityOfService.ExactlyOnce:
                        mqttChannel.AddMqttMessage(messageId,
                            await SendQos2Msg(mqttChannel.Channel, topic, false, bytes, messageId));
                        break;
                }
            }
        }

        /// <summary>
        /// Sends the pub back.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        public async Task SendPubBack(IChannel channel, int messageId)
        {
            var mqttPubAckMessage = new PubAckPacket
            {
                PacketId = messageId
            };
            await channel.WriteAndFlushAsync(mqttPubAckMessage);
        }

        /// <summary>
        /// Sends the pub record.
        /// </summary>
        /// <param name="mqttChannel">The MQTT channel.</param>
        /// <param name="messageId">The message identifier.</param>
        public async Task SendPubRec(MqttChannel mqttChannel, int messageId)
        {
            var mqttPubAckMessage = new PubRecPacket
            {
                PacketId = messageId
            };
            var channel = mqttChannel.Channel;
            await channel.WriteAndFlushAsync(mqttPubAckMessage);
            var sendMqttMessage = Enqueue(channel, messageId, null, null, 1, ConfirmStatus.PUBREC);
            mqttChannel.AddMqttMessage(messageId, sendMqttMessage);
        }

        /// <summary>
        /// Sends the pub relative.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        public async Task SendPubRel(IChannel channel, int messageId)
        {
            var mqttPubAckMessage = new PubRelPacket
            {
                PacketId = messageId
            };
            await channel.WriteAndFlushAsync(mqttPubAckMessage);
        }

        /// <summary>
        /// Sends to pub comp.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="messageId">The message identifier.</param>
        public async Task SendToPubComp(IChannel channel, int messageId)
        {
            var mqttPubAckMessage = new PubCompPacket
            {
                PacketId = messageId
            };
            await channel.WriteAndFlushAsync(mqttPubAckMessage);
        }


        /// <summary>
        /// Sends the qos0 MSG.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="topic">The topic.</param>
        /// <param name="byteBuf">The byte buf.</param>
        public async Task SendQos0Msg(IChannel channel, string topic, byte[] byteBuf)
        {
            if (channel != null)
            {
                await SendQos0Msg(channel, topic, byteBuf, 0);
            }
        }

        private async Task<SendMqttMessage> SendQos1Msg(IChannel channel, string topic, bool isDup, byte[] byteBuf,
            int messageId)
        {
            var mqttPublishMessage = new PublishPacket(QualityOfService.AtMostOnce, true, true);
            mqttPublishMessage.TopicName = topic;
            mqttPublishMessage.PacketId = messageId;
            mqttPublishMessage.Payload = Unpooled.WrappedBuffer(byteBuf);
            await channel.WriteAndFlushAsync(mqttPublishMessage);
            return Enqueue(channel, messageId, topic, byteBuf, (int) QualityOfService.AtLeastOnce, ConfirmStatus.PUB);
        }

        private async Task<SendMqttMessage> SendQos2Msg(IChannel channel, string topic, bool isDup, byte[] byteBuf,
            int messageId)
        {
            var mqttPublishMessage = new PublishPacket(QualityOfService.AtMostOnce, true, true);
            mqttPublishMessage.TopicName = topic;
            mqttPublishMessage.PacketId = messageId;
            mqttPublishMessage.Payload = Unpooled.WrappedBuffer(byteBuf);
            await channel.WriteAndFlushAsync(mqttPublishMessage);
            return Enqueue(channel, messageId, topic, byteBuf, (int) QualityOfService.ExactlyOnce, ConfirmStatus.PUB);
        }

        private async Task SendQos0Msg(IChannel channel, string topic, byte[] byteBuf, int messageId)
        {
            if (channel != null)
            {
                var mqttPublishMessage = new PublishPacket(QualityOfService.AtMostOnce, true, true);
                mqttPublishMessage.TopicName = topic;
                mqttPublishMessage.Payload = Unpooled.WrappedBuffer(byteBuf);
                await channel.WriteAndFlushAsync(mqttPublishMessage);
            }
        }

        private SendMqttMessage Enqueue(IChannel channel, int messageId, string topic, byte[] datas, int mqttQoS,
            ConfirmStatus confirmStatus)
        {
            var message = new SendMqttMessage
            {
                ByteBuf = datas,
                Channel = channel,
                MessageId = messageId,
                Qos = mqttQoS,
                Time = DateTime.Now.Ticks / 10000,
                ConfirmStatus = confirmStatus,
                Topic = topic
            };
            _scanRunnable.Enqueue(message);
            return message;
        }
    }
}