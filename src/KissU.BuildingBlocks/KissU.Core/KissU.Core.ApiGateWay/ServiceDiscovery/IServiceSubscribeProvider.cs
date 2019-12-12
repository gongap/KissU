using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.Core.CPlatform;

namespace KissU.Core.ApiGateWay.ServiceDiscovery
{
    public interface IServiceSubscribeProvider
    {
        Task<IEnumerable<ServiceAddressModel>> GetAddressAsync(string condition = null);

        Task<IEnumerable<ServiceDescriptor>> GetServiceDescriptorAsync(string address, string condition = null);
    }
}
