namespace KissU.CPlatform.Messages
{
    /// <summary>
    /// MessagePackTransportMessageType.
    /// </summary>
    public class MessagePackTransportMessageType
    {
        /// <summary>
        /// The remote invoke result message type name
        /// </summary>
        public static string RemoteInvokeResultMessageTypeName = typeof(RemoteInvokeResultMessage).FullName;

        /// <summary>
        /// The remote invoke message type name
        /// </summary>
        public static string RemoteInvokeMessageTypeName = typeof(RemoteInvokeMessage).FullName;

        /// <summary>
        /// The HTTP message type name
        /// </summary>
        public static string HttpMessageTypeName = typeof(HttpRequestMessage).FullName;

        /// <summary>
        /// The HTTP result message type name
        /// </summary>
        public static string HttpResultMessageTypeName = typeof(HttpResultMessage<object>).FullName;

        public static string reactiveResultMessageTypeName = typeof(ReactiveResultMessage).FullName;
    }
}