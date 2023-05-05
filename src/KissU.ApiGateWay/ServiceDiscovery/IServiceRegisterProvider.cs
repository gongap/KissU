using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;

namespace KissU.ApiGateWay.ServiceDiscovery
{
    /// <summary>
    /// Interface IServiceRegisterProvider
    /// </summary>
    public interface IServiceRegisterProvider
    {
        /// <summary>
        /// Gets the address asynchronous.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceAddressModel&gt;&gt;.</returns>
        Task<IEnumerable<ServiceAddressModel>> GetAddressAsync(string condition = null);
    }
}