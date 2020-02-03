namespace KissU.Core.CPlatform.Configurations
{
    /// <summary>
    /// 协议端口选项。
    /// </summary>
    public class ProtocolPortOptions
    {
        /// <summary>
        /// Gets or sets the MQTT port.
        /// </summary>
        public int MQTTPort { get; set; }

        /// <summary>
        /// Gets or sets the HTTP port.
        /// </summary>
        public int? HttpPort { get; set; }

        /// <summary>
        /// Gets or sets the ws port.
        /// </summary>
        public int WSPort { get; set; }

        /// <summary>
        /// Gets or sets the GRPC port.
        /// </summary>
        public int GrpcPort { get; set; }

        /// <summary>
        /// Gets or sets the UDP port.
        /// </summary>
        public int UdpPort { get; set; }
    }
}