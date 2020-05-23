using System;
using System.Threading.Tasks;
using KissU.Core.Common.Application.Dtos;
using KissU.Core.Dependency;
using KissU.Core.Extensions;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Implements
{
    [ModuleName("IdentityRole")]
    public class IdentityRoleService : ProxyServiceBase, IIdentityRoleService
    {
        public IdentityRoleService(IIdentityRoleAppService roleAppService)
        {
            RoleAppService = roleAppService;
        }

        protected IIdentityRoleAppService RoleAppService { get; }

        public virtual async Task<ListResult<IdentityRoleDto>> GetAllListAsync()
        {
            var result = await RoleAppService.GetAllListAsync();
            return result.MapTo<ListResult<IdentityRoleDto>>();
        }

        public virtual async Task<PagedResult<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await RoleAppService.GetListAsync(input);
            return result.MapTo<PagedResult<IdentityRoleDto>>();
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