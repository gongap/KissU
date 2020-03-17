using KissU.Surging.Protocol.Mqtt.Internal.Enums;

namespace KissU.Surging.Protocol.Mqtt.Internal.Messages
{
    /// <summary>
    /// ConnectMessage.
    /// Implements the <see cref="KissU.Surging.Protocol.Mqtt.Internal.Messages.MqttMessage" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Protocol.Mqtt.Internal.Messages.MqttMessage" />
    public class ConnectMessage : MqttMessage
    {
        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        public override MessageType MessageType => MessageType.CONNECT;

        /// <summary>
        /// Gets or sets the name of the protocol.
        /// </summary>
        public string ProtocolName { get; set; }

        /// <summary>
        /// Gets or sets the protocol level.
        /// </summary>
        public int ProtocolLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [clean session].
        /// </summary>
        public bool CleanSession { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has will.
        /// </summary>
        public bool HasWill { get; set; }

        /// <summary>
        /// Gets or sets the will quality of service.
        /// </summary>
        public int WillQualityOfService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [will retain].
        /// </summary>
        public bool WillRetain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has password.
        /// </summary>
        public bool HasPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has username.
        /// </summary>
        public bool HasUsername { get; set; }

        /// <summary>
        /// Gets or sets the keep alive in seconds.
        /// </summary>
        public int KeepAliveInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the will topic.
        /// </summary>
        public string WillTopic { get; set; }

        /// <summary>
        /// Gets or sets the will message.
        /// </summary>
        public byte[] WillMessage { get; set; }
    }
}