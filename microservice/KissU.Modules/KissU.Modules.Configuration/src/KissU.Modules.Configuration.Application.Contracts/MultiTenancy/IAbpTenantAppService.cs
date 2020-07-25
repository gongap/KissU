using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Application.MultiTenancy
{
    public interface IAbpTenantAppService : IApplicationService
    {
        Task<FindTenantResultDto> FindTenantByNameAsync(string name);

        Task<FindTenantResultDto> FindTenantByIdAsync(Guid id);
    }
}