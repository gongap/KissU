namespace KissU.Core.CPlatform.Messages
{
    /// <summary>
    /// MessagePackTransportMessageType.
    /// </summary>
    public class MessagePackTransportMessageType
    {
        /// <summary>
        /// The remote invoke result message type name
        /// </summary>
        public static string remoteInvokeResultMessageTypeName= typeof(RemoteInvokeResultMessage).FullName;

        /// <summary>
        /// The remote invoke message type name
        /// </summary>
        public static string remoteInvokeMessageTypeName = typeof(RemoteInvokeMessage).FullName;

        /// <summary>
        /// The HTTP message type name
        /// </summary>
        public static string httpMessageTypeName = typeof(HttpRequestMessage).FullName;

        /// <summary>
        /// The HTTP result message type name
        /// </summary>
        public static string httpResultMessageTypeName = typeof(HttpResultMessage<object>).FullName;
    }
}
