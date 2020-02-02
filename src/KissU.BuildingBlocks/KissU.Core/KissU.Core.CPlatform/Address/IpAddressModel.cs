using System.Net;
using Newtonsoft.Json;

namespace KissU.Core.CPlatform.Address
{
    /// <summary>
    /// ip地址模型。
    /// </summary>
    public sealed class IpAddressModel : AddressModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpAddressModel" /> class.
        /// 初始化一个新的ip地址模型实例。
        /// </summary>
        public IpAddressModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IpAddressModel" /> class.
        /// 初始化一个新的ip地址模型实例。
        /// </summary>
        /// <param name="ip">ip地址。</param>
        /// <param name="port">端口。</param>
        public IpAddressModel(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }

        /// <summary>
        /// ip地址。
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 端口。
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 外网ip地址
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string WanIp { get; set; }

        /// <summary>
        /// Gets or sets the WS port.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? WsPort { get; set; }

        /// <summary>
        /// Gets or sets the MQTT port.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MqttPort { get; set; }

        /// <summary>
        /// Gets or sets the HTTP port.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? HttpPort { get; set; }

        /// <summary>
        /// 创建终结点。
        /// </summary>
        /// <returns>终结点</returns>
        public override EndPoint CreateEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(Ip), Port);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(new string[] { Ip, ":", Port.ToString() });
        }
    }
}