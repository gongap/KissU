using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Address;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.CPlatform;

namespace KissU.ApiGateWay.ServiceDiscovery
{
    /// <summary>
    /// Interface IServiceDiscoveryProvider
    /// </summary>
    public interface IServiceDiscoveryProvider
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

        /// <summary>
        /// Edits the service token.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Task.</returns>
        Task EditServiceToken(AddressModel address);
    }
}