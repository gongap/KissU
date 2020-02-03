namespace KissU.Core.CPlatform
{
    /// <summary>
    /// 通讯协议枚举
    /// </summary>
    public enum CommunicationProtocol
    {
        /// <summary>
        /// 无
        /// </summary>
        None,

        /// <summary>
        /// TCP
        /// </summary>
        Tcp,

        /// <summary>
        /// HTTP
        /// </summary>
        Http,

        /// <summary>
        /// WS
        /// </summary>
        WS,

        /// <summary>
        /// MQTT
        /// </summary>
        Mqtt,

        /// <summary>
        /// DNS
        /// </summary>
        Dns,

        /// <summary>
        /// UDP
        /// </summary>
        Udp,
    }
}