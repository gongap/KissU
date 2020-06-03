using System.Threading.Tasks;
using KissU.Common;
using KissU.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.TenantManagement.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface ITenantService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<TenantDto> GetAsync(string id);

        [HttpPost(true)]
        Task<PagedResult<TenantDto>> GetListAsync(GetTenantsInput input);

        [HttpPost(true)]
        Task<TenantDto> CreateAsync(TenantCreateDto input);

        [HttpPut(true)]
        [ServiceRoute("{id}")]
        Task<TenantDto> UpdateAsync(string id, TenantUpdateDto input);

        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task DeleteAsync(string id);

        [HttpGet(true)]
        [ServiceRoute("{id}/default-connection-string")]
        Task<string> GetDefaultConnectionStringAsync(string id);

        [HttpPut(true)]
        [ServiceRoute("{id}/default-connection-string")]
        Task UpdateDefaultConnectionStringAsync(string id, string defaultConnectionString);

        [HttpDelete(true)]
        [ServiceRoute("{id}/default-connection-string")]
        Task DeleteDefaultConnectionStringAsync(string id);
    }
}