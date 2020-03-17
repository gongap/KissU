using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.Address;
using KissU.Surging.CPlatform.Utilities;

namespace KissU.Surging.CPlatform.Runtime.Client
{
    /// <summary>
    /// 服务路由管理者扩展方法。
    /// </summary>
    public static class ServiceRouteManagerExtensions
    {
        /// <summary>
        /// 根据服务Id获取一个服务订阅者。
        /// </summary>
        /// <param name="serviceSubscribeManager">The service subscribe manager.</param>
        /// <param name="serviceId">服务Id。</param>
        /// <returns>服务路由。</returns>
        public static async Task<ServiceSubscriber> GetAsync(this IServiceSubscribeManager serviceSubscribeManager,
            string serviceId)
        {
            return (await serviceSubscribeManager.GetSubscribersAsync()).SingleOrDefault(i =>
                i.ServiceDescriptor.Id == serviceId);
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="serviceSubscribeManager">The service subscribe manager.</param>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;AddressModel&gt;&gt;.</returns>
        public static async Task<IEnumerable<AddressModel>> GetAddressAsync(
            this IServiceSubscribeManager serviceSubscribeManager, string condition = null)
        {
            var subscribers = await serviceSubscribeManager.GetSubscribersAsync();
            if (condition != null)
            {
                if (!condition.IsIP())
                {
                    subscribers = subscribers.Where(p => p.ServiceDescriptor.Id == condition);
                }
                else
                {
                    subscribers = subscribers.Where(p => p.Address.Any(m => m.ToString() == condition));
                }
            }

            var result = new Dictionary<string, AddressModel>();
            foreach (var route in subscribers)
            {
                var addresses = route.Address;
                foreach (var address in addresses)
                {
                    if (!result.ContainsKey(address.ToString()))
                    {
                        result.Add(address.ToString(), address);
                    }
                }
            }

            return result.Values;
        }

        /// <summary>
        /// get service descriptor as an asynchronous operation.
        /// </summary>
        /// <param name="serviceSubscribeManager">The service subscribe manager.</param>
        /// <param name="address">The address.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceDescriptor&gt;&gt;.</returns>
        public static async Task<IEnumerable<ServiceDescriptor>> GetServiceDescriptorAsync(
            this IServiceSubscribeManager serviceSubscribeManager, string address, string serviceId = null)
        {
            var subscribers = await serviceSubscribeManager.GetSubscribersAsync();
            if (serviceId == null)
            {
                return subscribers.Where(p => p.Address.Any(m => m.ToString() == address))
                    .Select(p => p.ServiceDescriptor);
            }

            return subscribers.Where(p => p.ServiceDescriptor.Id == serviceId)
                .Select(p => p.ServiceDescriptor);
        }
    }
}