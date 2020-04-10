using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Surging.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.Surging.CPlatform;

namespace KissU.Surging.ApiGateWay.ServiceDiscovery
{
    /// <summary>
    /// Interface IServiceSubscribeProvider
    /// </summary>
    public interface IServiceSubscribeProvider
    {
        /// <summary>
        /// Gets the address asynchronous.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceAddressModel&gt;&gt;.</returns>
        Task<IEnumerable<ServiceAddressModel>> GetAddressAsync(string condition = null);

        /// <summary>
        /// Gets the service descriptor asynchronous.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceDescriptor&gt;&gt;.</returns>
        Task<IEnumerable<ServiceDescriptor>> GetServiceDescriptorAsync(string address, string condition = null);
    }
}