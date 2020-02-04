using System;
using DotNetty.Buffers;
using DotNetty.Codecs.Mqtt.Packets;
using DotNetty.Transport.Channels;
using KissU.Core.Protocol.Mqtt.Internal.Enums;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// SacnScheduled.
    /// Implements the <see cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.ScanRunnable" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.ScanRunnable" />
    public class SacnScheduled: ScanRunnable
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SacnScheduled"/> class.
        /// </summary>
        public SacnScheduled()
        {
        }

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
                poll.Time=DateTime.Now.Ticks / 10000;
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
            PublishPacket mqttPublishMessage = new PublishPacket((QualityOfService)mqttMessage.Qos, true, mqttMessage.Retain)
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
        protected void PubRelAck( SendMqttMessage mqttMessage)
        {
            PubRelPacket mqttPubAckMessage = new PubRelPacket()
            {
                PacketId = mqttMessage.MessageId,
            };
            mqttMessage.Channel.WriteAndFlushAsync(mqttPubAckMessage);
        }

        private void PubRecAck(SendMqttMessage mqttMessage)
        {
            PubRecPacket mqttPubAckMessage = new PubRecPacket()
            {
                PacketId = mqttMessage.MessageId,
            };
            mqttMessage.Channel.WriteAndFlushAsync(mqttPubAckMessage);
        }
    }
}
