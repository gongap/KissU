using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Runtime.Client;

namespace KissU.Surging.ApiGateWay.ServiceDiscovery.Implementation
{
    /// <summary>
    /// 服务订阅提供者
    /// </summary>
    public class ServiceSubscribeProvider : IServiceSubscribeProvider
    {
        /// <summary>
        /// get address as an asynchronous operation.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceAddressModel&gt;&gt;.</returns>
        public async Task<IEnumerable<ServiceAddressModel>> GetAddressAsync(string condition = null)
        {
            var result = new List<ServiceAddressModel>();
            var addresses = await ServiceLocator.GetService<IServiceSubscribeManager>().GetAddressAsync(condition);
            foreach (var address in addresses)
            {
                result.Add(new ServiceAddressModel
                {
                    Address = address
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
            return await ServiceLocator.GetService<IServiceSubscribeManager>()
                .GetServiceDescriptorAsync(address, condition);
        }
    }
}