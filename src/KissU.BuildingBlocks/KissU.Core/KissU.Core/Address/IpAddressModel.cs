using System.Net;
using Newtonsoft.Json;

namespace KissU.Core.Address
{
    /// <summary>
    /// ip��ַģ�͡�
    /// </summary>
    public sealed class IpAddressModel : AddressModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpAddressModel" /> class.
        /// ��ʼ��һ���µ�ip��ַģ��ʵ����
        /// </summary>
        public IpAddressModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IpAddressModel" /> class.
        /// ��ʼ��һ���µ�ip��ַģ��ʵ����
        /// </summary>
        /// <param name="ip">ip��ַ��</param>
        /// <param name="port">�˿ڡ�</param>
        public IpAddressModel(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }

        /// <summary>
        /// ip��ַ��
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// �˿ڡ�
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// ����ip��ַ
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
        /// �����ս�㡣
        /// </summary>
        /// <returns>�ս��</returns>
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
            return string.Concat(new[] {Ip, ":", Port.ToString()});
        }
    }
}