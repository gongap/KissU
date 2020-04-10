using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Mqtt
{
    /// <summary>
    /// MqttServiceDescriptor.
    /// </summary>
    public class MqttServiceDescriptor
    {
        /// <summary>
        /// Mqtt地址描述符集合。
        /// </summary>
        public IEnumerable<MqttEndpointDescriptor> AddressDescriptors { get; set; }

        /// <summary>
        /// Mqtt描述符。
        /// </summary>
        public MqttDescriptor MqttDescriptor { get; set; }
    }
}