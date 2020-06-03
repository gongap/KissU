using System.Threading.Tasks;
using KissU.Common;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Surging.ProxyGenerator;
using KissU.Modules.TenantManagement.Service.Contracts;

namespace KissU.Modules.TenantManagement.Service.Implements
{
    [ModuleName(TenantManagementRemoteServiceConsts.RemoteServiceName)]
    public class TenantService : ProxyServiceBase, ITenantService
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantService(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public Task<TenantDto> GetAsync(string id)
        {
            return _tenantAppService.GetAsync(id.ToGuid());
        }

        public async Task<PagedResult<TenantDto>> GetListAsync(GetTenantsInput input)
        {
            var result = await _tenantAppService.GetListAsync(input);
            return new PagedResult<TenantDto>(result.TotalCount, result.Items);
        }

        public Task<TenantDto> CreateAsync(TenantCreateDto input)
        {
            return _tenantAppService.CreateAsync(input);
        }

        public Task<TenantDto> UpdateAsync(string id, TenantUpdateDto input)
        {
            return _tenantAppService.UpdateAsync(id.ToGuid(), input);
        }

        public Task DeleteAsync(string id)
        {
            return _tenantAppService.DeleteAsync(id.ToGuid());
        }

        public Task<string> GetDefaultConnectionStringAsync(string id)
        {
            return _tenantAppService.GetDefaultConnectionStringAsync(id.ToGuid());
        }

        public Task UpdateDefaultConnectionStringAsync(string id, string defaultConnectionString)
        {
            return _tenantAppService.UpdateDefaultConnectionStringAsync(id.ToGuid(), defaultConnectionString);
        }

        public Task DeleteDefaultConnectionStringAsync(string id)
        {
            return _tenantAppService.DeleteDefaultConnectionStringAsync(id.ToGuid());
        }
    }
}