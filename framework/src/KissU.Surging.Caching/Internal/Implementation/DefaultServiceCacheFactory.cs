using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.Serialization;
using KissU.Surging.CPlatform.Cache;

namespace KissU.Surging.Caching.Internal.Implementation
{
    /// <summary>
    /// 默认的服务缓存工程
    /// </summary>
    public class DefaultServiceCacheFactory : IServiceCacheFactory
    {
        private readonly ConcurrentDictionary<string, CacheEndpoint> _addressModel =
            new ConcurrentDictionary<string, CacheEndpoint>();

        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceCacheFactory" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public DefaultServiceCacheFactory(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// Creates the service caches asynchronous.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCache&gt;&gt;.</returns>
        /// <exception cref="ArgumentNullException">descriptors</exception>
        public Task<IEnumerable<ServiceCache>> CreateServiceCachesAsync(IEnumerable<ServiceCacheDescriptor> descriptors)
        {
            if (descriptors == null)
                throw new ArgumentNullException(nameof(descriptors));

            descriptors = descriptors.ToArray();
            var routes = new List<ServiceCache>(descriptors.Count());

            routes.AddRange(descriptors.Select(descriptor => new ServiceCache
            {
                CacheEndpoint = CreateAddress(descriptor.AddressDescriptors),
                CacheDescriptor = descriptor.CacheDescriptor
            }));

            return Task.FromResult(routes.AsEnumerable());
        }


        private IEnumerable<CacheEndpoint> CreateAddress(IEnumerable<CacheEndpointDescriptor> descriptors)
        {
            if (descriptors == null)
                yield break;

            foreach (var descriptor in descriptors)
            {
                _addressModel.TryGetValue(descriptor.Value, out var address);
                if (address == null)
                {
                    var addressType = Type.GetType(descriptor.Type);
                    address = (CacheEndpoint) _serializer.Deserialize(descriptor.Value, addressType);
                    _addressModel.TryAdd(descriptor.Value, address);
                }

                yield return address;
            }
        }
    }
}