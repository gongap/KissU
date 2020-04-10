using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.Address;
using KissU.Core.Serialization;
using KissU.Surging.CPlatform.Routing;

namespace KissU.Surging.CPlatform.Runtime.Client.Implementation
{
    /// <summary>
    /// 默认服务订阅者工厂.
    /// Implements the <see cref="IServiceSubscriberFactory" />
    /// </summary>
    /// <seealso cref="IServiceSubscriberFactory" />
    internal class DefaultServiceSubscriberFactory : IServiceSubscriberFactory
    {
        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceSubscriberFactory" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public DefaultServiceSubscriberFactory(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// 根据服务描述创建服务订阅者.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceSubscriber&gt;&gt;.</returns>
        /// <exception cref="ArgumentNullException">descriptors</exception>
        public Task<IEnumerable<ServiceSubscriber>> CreateServiceSubscribersAsync(
            IEnumerable<ServiceSubscriberDescriptor> descriptors)
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
                ServiceDescriptor = descriptor.ServiceDescriptor
            }));
            return Task.FromResult(subscribers.AsEnumerable());
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
                yield return (AddressModel) _serializer.Deserialize(descriptor.Value, typeof(IpAddressModel));
            }
        }
    }
}