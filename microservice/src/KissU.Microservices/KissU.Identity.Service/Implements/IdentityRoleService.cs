using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity
{
    [ModuleName("IdentityRole")]
    public class IdentityRoleService : ProxyServiceBase, IIdentityRoleService
    {
        protected IIdentityRoleAppService RoleAppService { get; }

        public IdentityRoleService(IIdentityRoleAppService roleAppService)
        {
            RoleAppService = roleAppService;
        }

        public virtual Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
        {
            return RoleAppService.GetAllListAsync();
        }

        public virtual Task<PagedResultDto<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return RoleAppService.GetListAsync(input);
        }

        public virtual Task<IdentityRoleDto> GetAsync(Guid id)
        {
            return RoleAppService.GetAsync(id);
        }

        public virtual Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
        {
            return RoleAppService.CreateAsync(input);
        }
        public virtual Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input)
        {
            return RoleAppService.UpdateAsync(id, input);
        }

        public virtual Task DeleteAsync(Guid id)
        {
            return RoleAppService.DeleteAsync(id);
        }
    }
}
