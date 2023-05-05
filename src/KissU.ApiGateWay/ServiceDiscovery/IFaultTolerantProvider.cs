using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.CPlatform.Support;

namespace KissU.ApiGateWay.ServiceDiscovery
{
    /// <summary>
    /// Interface IFaultTolerantProvider
    /// </summary>
    public interface IFaultTolerantProvider
    {
        /// <summary>
        /// Gets the command descriptor.
        /// </summary>
        /// <param name="serviceIds">The service ids.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCommandDescriptor&gt;&gt;.</returns>
        Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptor(params string[] serviceIds);

        /// <summary>
        /// Gets the command descriptor by address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCommandDescriptor&gt;&gt;.</returns>
        Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptorByAddress(string address);

        /// <summary>
        /// Sets the command descriptor by address.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task SetCommandDescriptorByAddress(ServiceCommandDescriptor model);
    }
}