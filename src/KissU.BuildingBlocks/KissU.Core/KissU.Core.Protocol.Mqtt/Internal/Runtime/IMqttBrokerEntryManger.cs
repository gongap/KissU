using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// Interface IMqttBrokerEntryManger
    /// </summary>
    public interface IMqttBrokerEntryManger
    {
        /// <summary>
        /// Gets the MQTT broker address.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <returns>ValueTask&lt;IEnumerable&lt;AddressModel&gt;&gt;.</returns>
        ValueTask<IEnumerable<AddressModel>> GetMqttBrokerAddress(string topic);

        /// <summary>
        /// Cancellations the reg.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="addressModel">The address model.</param>
        /// <returns>Task.</returns>
        Task CancellationReg(string topic,AddressModel addressModel);

        /// <summary>
        /// Registers the specified topic.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="addressModel">The address model.</param>
        /// <returns>Task.</returns>
        Task Register(string topic, AddressModel addressModel);
    }
}
