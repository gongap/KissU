using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Application.MultiTenancy;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Configuration.Service.Contracts
{
    [ServiceBundle("api/abp/multi-tenancy")]
    public interface IAbpTenantService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("tenants/by-name/{name}")]
        Task<FindTenantResultDto> FindTenantByNameAsync(string name);

        [HttpGet(true)]
        [ServiceRoute("tenants/by-id/{id}")]
        Task<FindTenantResultDto> FindTenantByIdAsync(string id);
    }
}