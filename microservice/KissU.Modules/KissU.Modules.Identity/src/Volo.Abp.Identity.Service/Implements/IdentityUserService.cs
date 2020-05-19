using System;
using System.Threading.Tasks;
using KissU.Core.Common.Application.Dtos;
using KissU.Core.Dependency;
using KissU.Core.Extensions;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Identity.Service.Contracts;

namespace Volo.Abp.Identity.Service.Implements
{

    [ModuleName("IdentityUser")]
    public class IdentityUserService : ProxyServiceBase, IIdentityUserService
    {
        protected IIdentityUserAppService UserAppService { get; }

        public IdentityUserService(IIdentityUserAppService userAppService)
        {
            UserAppService = userAppService;
        }

        public virtual Task<IdentityUserDto> GetAsync(Guid id)
        {
            return UserAppService.GetAsync(id);
        }

        public virtual async Task<PagedResult<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            var result = await UserAppService.GetListAsync(input);
            return result.MapTo<PagedResult<IdentityUserDto>>();
        }

        public virtual Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return UserAppService.CreateAsync(input);
        }

        public virtual Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            return UserAppService.UpdateAsync(id, input);
        }

        public virtual Task DeleteAsync(Guid id)
        {
            return UserAppService.DeleteAsync(id);
        }

        public virtual async Task<ListResult<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            var result = await UserAppService.GetRolesAsync(id);
            return result.MapTo<ListResult<IdentityRoleDto>>();
        }

        public virtual Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            return UserAppService.UpdateRolesAsync(id, input);
        }

        public virtual Task<IdentityUserDto> FindByUsernameAsync(string username)
        {
            return UserAppService.FindByUsernameAsync(username);
        }

        public virtual Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return UserAppService.FindByEmailAsync(email);
        }
    }
}
