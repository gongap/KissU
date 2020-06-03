using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Serialization;
using KissU.Surging.CPlatform.Routing;

namespace KissU.Surging.CPlatform.Runtime.Client.Implementation
{
    /// <summary>
    /// 服务订阅管理器.
    /// Implements the <see cref="IServiceSubscribeManager" />
    /// </summary>
    /// <seealso cref="IServiceSubscribeManager" />
    public abstract class ServiceSubscribeManagerBase : IServiceSubscribeManager
    {
        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSubscribeManagerBase" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected ServiceSubscribeManagerBase(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// 获取所有服务订阅者信息。
        /// </summary>
        /// <returns>服务路由集合。</returns>
        public abstract Task<IEnumerable<ServiceSubscriber>> GetSubscribersAsync();

        /// <summary>
        /// 设置服务订阅者。
        /// </summary>
        /// <param name="subscibers">The subscibers.</param>
        /// <returns>一个任务。</returns>
        /// <exception cref="ArgumentNullException">subscibers</exception>
        public virtual Task SetSubscribersAsync(IEnumerable<ServiceSubscriber> subscibers)
        {
            if (subscibers == null)
            {
                throw new ArgumentNullException(nameof(subscibers));
            }

            var descriptors = subscibers.Where(route => route != null).Select(route => new ServiceSubscriberDescriptor
            {
                AddressDescriptors = route.Address?.Select(address => new ServiceAddressDescriptor
                {
                    Type = address.GetType().FullName,
                    Value = _serializer.Serialize(address)
                }) ?? Enumerable.Empty<ServiceAddressDescriptor>(),
                ServiceDescriptor = route.ServiceDescriptor
            });

            return SetSubscribersAsync(descriptors);
        }

        /// <summary>
        /// 清空所有的服务订阅者。
        /// </summary>
        /// <returns>一个任务。</returns>
        public abstract Task ClearAsync();

        /// <summary>
        /// 设置服务订阅者。
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        /// <returns>一个任务。</returns>
        protected abstract Task SetSubscribersAsync(IEnumerable<ServiceSubscriberDescriptor> subscribers);
    }
}