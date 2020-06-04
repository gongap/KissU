using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Serialization;
using KissU.Surging.CPlatform.Address;
using KissU.Surging.CPlatform.Mqtt;

namespace KissU.Surging.Protocol.Mqtt.Implementation
{
    /// <summary>
    /// DefaultMqttServiceFactory.
    /// Implements the <see cref="KissU.Surging.CPlatform.Mqtt.IMqttServiceFactory" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Mqtt.IMqttServiceFactory" />
    public class DefaultMqttServiceFactory : IMqttServiceFactory
    {
        private readonly ConcurrentDictionary<string, AddressModel> _addressModel =
            new ConcurrentDictionary<string, AddressModel>();

        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMqttServiceFactory" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public DefaultMqttServiceFactory(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// Creates the MQTT service routes asynchronous.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <returns>Task&lt;IEnumerable&lt;MqttServiceRoute&gt;&gt;.</returns>
        /// <exception cref="ArgumentNullException">descriptors</exception>
        public Task<IEnumerable<MqttServiceRoute>> CreateMqttServiceRoutesAsync(
            IEnumerable<MqttServiceDescriptor> descriptors)
        {
            if (descriptors == null)
                throw new ArgumentNullException(nameof(descriptors));

            descriptors = descriptors.ToArray();
            var routes = new List<MqttServiceRoute>(descriptors.Count());

            routes.AddRange(descriptors.Select(descriptor => new MqttServiceRoute
            {
                MqttEndpoint = CreateAddress(descriptor.AddressDescriptors),
                MqttDescriptor = descriptor.MqttDescriptor
            }));

            return Task.FromResult(routes.AsEnumerable());
        }


        private IEnumerable<AddressModel> CreateAddress(IEnumerable<MqttEndpointDescriptor> descriptors)
        {
            if (descriptors == null)
                yield break;

            foreach (var descriptor in descriptors)
            {
                _addressModel.TryGetValue(descriptor.Value, out var address);
                if (address == null)
                {
                    address = (AddressModel) _serializer.Deserialize(descriptor.Value, typeof(IpAddressModel));
                    _addressModel.TryAdd(descriptor.Value, address);
                }

                yield return address;
            }
        }
    }
}