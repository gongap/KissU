using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Serialization;

namespace KissU.Core.CPlatform.Runtime.Client.Implementation
{
    class DefaultServiceSubscriberFactory : IServiceSubscriberFactory
    {
        private readonly ISerializer<string> _serializer;

        public DefaultServiceSubscriberFactory(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }
        
        public Task<IEnumerable<ServiceSubscriber>> CreateServiceSubscribersAsync(IEnumerable<ServiceSubscriberDescriptor> descriptors)
        {
            if (descriptors == null)
            {
                throw new ArgumentNullException(nameof(descriptors));
            }

            descriptors = descriptors.ToArray();
            var subscribers = new List<ServiceSubscriber>(descriptors.Count());
            subscribers.AddRange(descriptors.Select(descriptor => new ServiceSubscriber
            {
                Address = CreateAddress(descriptor.AddressDescriptors),
                ServiceDescriptor = descriptor.ServiceDescriptor,
            }));
            return Task.FromResult(subscribers.AsEnumerable());
        }

        private IEnumerable<AddressModel> CreateAddress(IEnumerable<ServiceAddressDescriptor> descriptors)
        {
            if (descriptors == null)
            {
                yield break;
            }

            foreach (var descriptor in descriptors)
            {
                yield return (AddressModel)_serializer.Deserialize(descriptor.Value, typeof(IpAddressModel));
            }
        }
    }
}
