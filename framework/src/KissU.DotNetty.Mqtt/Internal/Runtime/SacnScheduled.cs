using System;
using DotNetty.Buffers;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.DotNetty.Mqtt.Internal.Enums;
using KissU.DotNetty.Mqtt.Internal.Messages;

namespace KissU.DotNetty.Mqtt.Internal.Runtime
{
    /// <summary>
    /// SacnScheduled.
    /// Implements the <see cref="ScanRunnable" />
    /// </summary>
    /// <seealso cref="ScanRunnable" />
    public class SacnScheduled : ScanRunnable
    {
        private bool CheckTime(long time)
        {
            return DateTime.Now.Millisecond - time >= 10 * 1000;
        }

        /// <summary>
        /// Executes the specified poll.
        /// </summary>
        /// <param name="poll">The poll.</param>
        public override void Execute(SendMqttMessage poll)
        {
            if (CheckTime(poll.Time) && poll.Channel.Active)
            {
                poll.Time = DateTime.Now.Ticks / 10000;
                switch (poll.ConfirmStatus)
                {
                    case ConfirmStatus.PUB:
                        PubMessage(poll.Channel, poll);
                        break;
                    case ConfirmStatus.PUBREL:
                        PubRelAck(poll);
                        break;
                    case ConfirmStatus.PUBREC:
                        PubRecAck(poll);
                        break;
                }
            }
        }

        private void PubMessage(IChannel channel, SendMqttMessage mqttMessage)
        {
            var mqttPublishMessage = new PublishPacket((QualityOfService) mqttMessage.Qos, true, mqttMessage.Retain)
            {
                TopicName = mqttMessage.Topic,
                PacketId = mqttMessage.MessageId,
                Payload = Unpooled.WrappedBuffer(mqttMessage.ByteBuf)
            };
            channel.WriteAndFlushAsync(mqttPublishMessage);
        }

        /// <summary>
        /// Pubs the relative ack.
        /// </summary>
        /// <param name="mqttMessage">The MQTT message.</param>
        protected void PubRelAck(SendMqttMessage mqttMessage)
        {
            var mqttPubAckMessage = new PubRelPacket
            {
                PacketId = mqttMessage.MessageId
            };
            mqttMessage.Channel.WriteAndFlushAsync(mqttPubAckMessage);
        }

        private void PubRecAck(SendMqttMessage mqttMessage)
        {
            var mqttPubAckMessage = new PubRecPacket
            {
                PacketId = mqttMessage.MessageId
            };
            mqttMessage.Channel.WriteAndFlushAsync(mqttPubAckMessage);
        }
    }
}