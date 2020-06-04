using KissU.Serialization;
using KissU.Surging.CPlatform.Address;
using Newtonsoft.Json;

namespace KissU.Surging.CPlatform.Mqtt
{
    /// <summary>
    /// Mqtt地址描述符。
    /// </summary>
    public class MqttEndpointDescriptor
    {
        /// <summary>
        /// 地址类型。
        /// </summary>
        [JsonIgnore]
        public string Type { get; set; }

        /// <summary>
        /// 地址值。
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 创建一个描述符。
        /// </summary>
        /// <typeparam name="T">地址模型类型。</typeparam>
        /// <param name="address">地址模型实例。</param>
        /// <param name="serializer">序列化器。</param>
        /// <returns>Mqtt地址描述符。</returns>
        public static MqttEndpointDescriptor CreateDescriptor<T>(T address, ISerializer<string> serializer)
            where T : AddressModel, new()
        {
            return new MqttEndpointDescriptor
            {
                Type = typeof(T).FullName,
                Value = serializer.Serialize(address)
            };
        }
    }
}