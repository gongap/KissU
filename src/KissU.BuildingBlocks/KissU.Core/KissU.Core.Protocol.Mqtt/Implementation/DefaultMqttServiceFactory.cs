using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Mqtt;
using KissU.Core.CPlatform.Serialization;

namespace KissU.Core.Protocol.Mqtt.Implementation
{
    public class DefaultMqttServiceFactory : IMqttServiceFactory
    {

        private readonly ISerializer<string> _serializer;
        private readonly ConcurrentDictionary<string, AddressModel> _addressModel =
               new ConcurrentDictionary<string, AddressModel>();

        public DefaultMqttServiceFactory(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        public Task<IEnumerable<MqttServiceRoute>> CreateMqttServiceRoutesAsync(IEnumerable<MqttServiceDescriptor> descriptors)
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
                _addressModel.TryGetValue(descriptor.Value, out AddressModel address);
                if (address == null)
                {
                    address = (AddressModel)_serializer.Deserialize(descriptor.Value, typeof(IpAddressModel));
                    _addressModel.TryAdd(descriptor.Value, address);
                }
                yield return address;
            }
        }

    }
}
