using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Address;
using KissUtil.Extensions;

namespace KissU.CPlatform.Routing
{
    /// <summary>
    /// 服务路由管理者扩展方法。
    /// </summary>
    public static class ServiceRouteManagerExtensions
    {
        /// <summary>
        /// 根据服务Id获取一个服务路由。
        /// </summary>
        /// <param name="serviceRouteManager">服务路由管理者。</param>
        /// <param name="serviceId">服务Id。</param>
        /// <returns>服务路由。</returns>
        public static async Task<ServiceRoute> GetAsync(this IServiceRouteManager serviceRouteManager, string serviceId)
        {
            return (await serviceRouteManager.GetRoutesAsync()).SingleOrDefault(
                i => i.ServiceDescriptor.Id == serviceId);
        }


        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;AddressModel&gt;&gt;.</returns>
        public static async Task<IEnumerable<AddressModel>> GetAddressAsync(
            this IServiceRouteManager serviceRouteManager, string condition = null)
        {
            var routes = await serviceRouteManager.GetRoutesAsync();
            if (!string.IsNullOrWhiteSpace(condition))
            {
                if (!condition.IsIP())
                {
                    routes = routes.Where(p => p.ServiceDescriptor.Id == condition);
                }
                else
                {
                    routes = routes.Where(p => p.Address.Any(m => m.ToString() == condition));
                    var addresses = routes?.FirstOrDefault()?.Address;
                    return addresses?.Where(p => p.ToString() == condition);
                }
            }

            return routes.SelectMany(x => x.Address)?.Distinct();
        }

        /// <summary>
        /// get routes as an asynchronous operation.
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="address">The address.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceRoute&gt;&gt;.</returns>
        public static async Task<IEnumerable<ServiceRoute>> GetRoutesAsync(
            this IServiceRouteManager serviceRouteManager, string address)
        {
            var routes = await serviceRouteManager.GetRoutesAsync();
            return routes.Where(p => p.Address.Any(m => m.ToString() == address));
        }

        /// <summary>
        /// get service descriptor as an asynchronous operation.
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="address">The address.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceDescriptor&gt;&gt;.</returns>
        public static async Task<IEnumerable<ServiceDescriptor>> GetServiceDescriptorAsync(
            this IServiceRouteManager serviceRouteManager, string address, string serviceId = null)
        {
            var routes = await serviceRouteManager.GetRoutesAsync();
            if (string.IsNullOrWhiteSpace(serviceId))
            {
                return routes.Where(p => p.Address.Any(m => m.ToString() == address))
                    .Select(p => p.ServiceDescriptor);
            }

            return routes.Where(p => p.ServiceDescriptor.Id == serviceId)
                .Select(p => p.ServiceDescriptor);
        }
    }
}
