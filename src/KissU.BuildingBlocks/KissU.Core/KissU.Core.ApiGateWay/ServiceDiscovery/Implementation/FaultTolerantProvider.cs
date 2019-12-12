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
        public async Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptor(params string[] serviceIds)
        {
             return await ServiceLocator.GetService<IServiceCommandManager>().GetServiceCommandsAsync(serviceIds);
        }

        public async Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptorByAddress(string address)
        {
            var services = await ServiceLocator.GetService<IServiceDiscoveryProvider>().GetServiceDescriptorAsync(address);
            return await ServiceLocator.GetService<IServiceCommandManager>().GetServiceCommandsAsync(services.Select(p=>p.Id).ToArray());
        }

        public async Task SetCommandDescriptorByAddress(ServiceCommandDescriptor model)
        {
            await ServiceLocator.GetService<IServiceCommandManager>().SetServiceCommandsAsync(new ServiceCommandDescriptor[] { model });
        }
    }
}
