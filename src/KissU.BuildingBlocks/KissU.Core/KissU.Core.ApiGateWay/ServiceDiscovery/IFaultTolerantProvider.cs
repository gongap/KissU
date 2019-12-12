using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Support;

namespace KissU.Core.ApiGateWay.ServiceDiscovery
{
    public interface IFaultTolerantProvider
    {
        Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptor(params string [] serviceIds);

        Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptorByAddress(string address);

        Task SetCommandDescriptorByAddress(ServiceCommandDescriptor model);
    }
}
