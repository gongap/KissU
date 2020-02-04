using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Support;
using KissU.Core.CPlatform.Utilities;

namespace KissU.Core.ApiGateWay.ServiceDiscovery.Implementation
{
    /// <summary>
    /// 容错机制提供者
    /// </summary>
    public class FaultTolerantProvider : IFaultTolerantProvider
    {
        /// <summary>
        /// Gets the command descriptor.
        /// </summary>
        /// <param name="serviceIds">The service ids.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCommandDescriptor&gt;&gt;.</returns>
        public async Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptor(params string[] serviceIds)
        {
            return await ServiceLocator.GetService<IServiceCommandManager>().GetServiceCommandsAsync(serviceIds);
        }

        /// <summary>
        /// Gets the command descriptor by address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCommandDescriptor&gt;&gt;.</returns>
        public async Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptorByAddress(string address)
        {
            var services = await ServiceLocator.GetService<IServiceDiscoveryProvider>()
                .GetServiceDescriptorAsync(address);
            return await ServiceLocator.GetService<IServiceCommandManager>()
                .GetServiceCommandsAsync(services.Select(p => p.Id).ToArray());
        }

        /// <summary>
        /// Sets the command descriptor by address.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task SetCommandDescriptorByAddress(ServiceCommandDescriptor model)
        {
            await ServiceLocator.GetService<IServiceCommandManager>().SetServiceCommandsAsync(new[] {model});
        }
    }
}