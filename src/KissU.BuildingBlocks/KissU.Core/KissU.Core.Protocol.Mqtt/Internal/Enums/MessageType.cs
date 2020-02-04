namespace KissU.Core.Protocol.Mqtt.Internal.Enums
{
    /// <summary>
    /// Enum MessageType
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The connect
        /// </summary>
        CONNECT = 1,
        /// <summary>
        /// The connack
        /// </summary>
        CONNACK = 2,
        /// <summary>
        /// The publish
        /// </summary>
        PUBLISH = 3,
        /// <summary>
        /// The puback
        /// </summary>
        PUBACK = 4,
        /// <summary>
        /// The pubrec
        /// </summary>
        PUBREC = 5,
        /// <summary>
        /// The pubrel
        /// </summary>
        PUBREL = 6,
        /// <summary>
        /// The pubcomp
        /// </summary>
        PUBCOMP = 7,
        /// <summary>
        /// The subscribe
        /// </summary>
        SUBSCRIBE = 8,
        /// <summary>
        /// The suback
        /// </summary>
        SUBACK = 9,
        /// <summary>
        /// The unsubscribe
        /// </summary>
        UNSUBSCRIBE = 10,
        /// <summary>
        /// The unsuback
        /// </summary>
        UNSUBACK = 11,
        /// <summary>
        /// The pingreq
        /// </summary>
        PINGREQ = 12,
        /// <summary>
        /// The pingresp
        /// </summary>
        PINGRESP = 13,
        /// <summary>
        /// The disconnect
        /// </summary>
        DISCONNECT = 14
    }
}
