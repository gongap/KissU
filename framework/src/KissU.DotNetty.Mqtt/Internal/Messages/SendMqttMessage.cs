using DotNetty.Transport.Channels;
using KissU.DotNetty.Mqtt.Internal.Enums;

namespace KissU.DotNetty.Mqtt.Internal.Messages
{
    /// <summary>
    /// SendMqttMessage.
    /// </summary>
    public class SendMqttMessage
    {
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        public IChannel Channel { get; set; }

        /// <summary>
        /// Gets or sets the confirm status.
        /// </summary>
        public ConfirmStatus ConfirmStatus { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Gets or sets the byte buf.
        /// </summary>
        public byte[] ByteBuf { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SendMqttMessage" /> is retain.
        /// </summary>
        public bool Retain { get; set; }

        /// <summary>
        /// Gets or sets the qos.
        /// </summary>
        public int Qos { get; set; }

        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        public string Topic { get; set; }
    }
}