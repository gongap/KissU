namespace KissU.Protocol.Mqtt.Internal.Messages
{
    /// <summary>
    /// SessionMessage.
    /// </summary>
    public class SessionMessage
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public byte[] Message { get; set; }

        /// <summary>
        /// Gets or sets the qo s.
        /// </summary>
        public int QoS { get; set; }

        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        public string Topic { get; set; }
    }
}