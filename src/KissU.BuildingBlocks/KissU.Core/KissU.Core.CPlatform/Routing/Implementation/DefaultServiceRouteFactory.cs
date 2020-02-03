using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Serialization;

namespace KissU.Core.CPlatform.Routing.Implementation
{
    /// <summary>
    /// 一个默认的服务路由工厂实现。
    /// </summary>
    public class DefaultServiceRouteFactory : IServiceRouteFactory
    {
        private readonly ConcurrentDictionary<string, AddressModel> _addressModel =
            new ConcurrentDictionary<string, AddressModel>();

        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceRouteFactory" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public DefaultServiceRouteFactory(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// 根据服务路由描述符创建服务路由。
        /// </summary>
        /// <param name="descriptors">服务路由描述符。</param>
        /// <returns>服务路由集合。</returns>
        /// <exception cref="ArgumentNullException">descriptors</exception>
        public Task<IEnumerable<ServiceRoute>> CreateServiceRoutesAsync(IEnumerable<ServiceRouteDescriptor> descriptors)
        {
            if (descriptors == null)
            {
                throw new ArgumentNullException(nameof(descriptors));
            }

            descriptors = descriptors.ToArray();
            var routes = new List<ServiceRoute>(descriptors.Count());

            routes.AddRange(descriptors.Select(descriptor => new ServiceRoute
            {
                Address = CreateAddress(descriptor.AddressDescriptors),
                ServiceDescriptor = descriptor.ServiceDescriptor,
            }));

            return Task.FromResult(routes.AsEnumerable());
        }

        /// <summary>
        /// 创建地址.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <returns>IEnumerable&lt;AddressModel&gt;.</returns>
        private IEnumerable<AddressModel> CreateAddress(IEnumerable<ServiceAddressDescriptor> descriptors)
        {
            if (descriptors == null)
            {
                yield break;
            }

            foreach (var descriptor in descriptors)
            {
                _addressModel.TryGetValue(descriptor.Value, out var address);
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