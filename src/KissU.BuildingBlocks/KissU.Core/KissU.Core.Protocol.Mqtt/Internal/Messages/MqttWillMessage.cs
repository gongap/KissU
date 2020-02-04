namespace KissU.Core.Protocol.Mqtt.Internal.Messages
{
    /// <summary>
    /// MqttWillMessage.
    /// </summary>
    public class MqttWillMessage
    {
        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        public string Topic{ get; set; }

        /// <summary>
        /// Gets or sets the will message.
        /// </summary>
        public string WillMessage { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [will retain].
        /// </summary>
        public bool WillRetain { get; set; }

        /// <summary>
        /// Gets or sets the qos.
        /// </summary>
        public int Qos { get; set; }
    }
}
