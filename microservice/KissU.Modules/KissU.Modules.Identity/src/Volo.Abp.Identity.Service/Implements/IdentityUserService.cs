using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Application.Dtos;
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

        public virtual Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            return UserAppService.GetListAsync(input);
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

        public virtual Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return UserAppService.GetRolesAsync(id);
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
