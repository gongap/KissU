using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.ApiGateWay.ServiceDiscovery.Implementation;

namespace KissU.Core.ApiGateWay.ServiceDiscovery
{
    public interface IServiceRegisterProvider
    {

        Task<IEnumerable<ServiceAddressModel>> GetAddressAsync(string condition = null);
    }
}
