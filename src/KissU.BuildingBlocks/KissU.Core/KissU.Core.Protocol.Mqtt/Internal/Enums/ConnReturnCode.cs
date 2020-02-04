namespace KissU.Core.Protocol.Mqtt.Internal.Enums
{
    /// <summary>
    /// Enum ConnReturnCode
    /// </summary>
    public enum ConnReturnCode
    {
        /// <summary>
        /// The accepted
        /// </summary>
        Accepted = 0x00,
        /// <summary>
        /// The refused unacceptable protocol version
        /// </summary>
        RefusedUnacceptableProtocolVersion = 0X01,
        /// <summary>
        /// The refused identifier rejected
        /// </summary>
        RefusedIdentifierRejected = 0x02,
        /// <summary>
        /// The refused server unavailable
        /// </summary>
        RefusedServerUnavailable = 0x03,
        /// <summary>
        /// The refused bad username or password
        /// </summary>
        RefusedBadUsernameOrPassword = 0x04,
        /// <summary>
        /// The refused not authorized
        /// </summary>
        RefusedNotAuthorized = 0x05
    }
}
