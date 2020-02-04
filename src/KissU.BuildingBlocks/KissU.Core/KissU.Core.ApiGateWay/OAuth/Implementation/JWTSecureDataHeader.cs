namespace KissU.Core.ApiGateWay.OAuth.Implementation
{
    /// <summary>
    /// JWTSecureDataHeader.
    /// </summary>
    public class JWTSecureDataHeader
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public JWTSecureDataType Type { get; set; }

        /// <summary>
        /// Gets or sets the encrypt mode.
        /// </summary>
        public EncryptMode EncryptMode { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        public string TimeStamp { get; set; }
    }
}