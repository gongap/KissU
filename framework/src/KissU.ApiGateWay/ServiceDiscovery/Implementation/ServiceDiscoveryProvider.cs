using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Address;
using KissU.Dependency;
using KissU.CPlatform;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Client.HealthChecks;

namespace KissU.ApiGateWay.ServiceDiscovery.Implementation
{
    /// <summary>
    /// 服务发现提供者
    /// </summary>
    public class ServiceDiscoveryProvider : IServiceDiscoveryProvider
    {
        /// <summary>
        /// get address as an asynchronous operation.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceAddressModel&gt;&gt;.</returns>
        public async Task<IEnumerable<ServiceAddressModel>> GetAddressAsync(string condition = null)
        {
            var result = new List<ServiceAddressModel>();
            var addresses = await ServiceLocator.GetService<IServiceRouteManager>().GetAddressAsync(condition);
            foreach (var address in addresses)
            {
                result.Add(new ServiceAddressModel
                {
                    Address = address,
                    IsHealth = await ServiceLocator.GetService<IHealthCheckService>().IsHealth(address)
                });
            }

            return result;
        }

        /// <summary>
        /// get service descriptor as an asynchronous operation.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceDescriptor&gt;&gt;.</returns>
        public async Task<IEnumerable<ServiceDescriptor>> GetServiceDescriptorAsync(string address,
            string condition = null)
        {
            return await ServiceLocator.GetService<IServiceRouteManager>()
                .GetServiceDescriptorAsync(address, condition);
        }

        /// <summary>
        /// Edits the service token.
        /// </summary>
        /// <param name="address">The address.</param>
        public async Task EditServiceToken(AddressModel address)
        {
            var routes = await ServiceLocator.GetService<IServiceRouteManager>().GetRoutesAsync(address.ToString());
            routes = routes.ToList();
            var serviceRoutes = new List<ServiceRoute>();
            routes.ToList().ForEach(route =>
            {
                var addresses = new List<AddressModel>();

                serviceRoutes.Add(new ServiceRoute
                {
                    ServiceDescriptor = route.ServiceDescriptor,
                    Address = addresses
                });
            });
            await ServiceLocator.GetService<IServiceRouteManager>().ClearAsync();
            await ServiceLocator.GetService<IServiceRouteManager>().SetRoutesAsync(serviceRoutes);
        }
    }
}