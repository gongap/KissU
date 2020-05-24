using System;
using System.Threading.Tasks;
using KissU.Core.Common.Application.Dtos;
using KissU.Core.Dependency;
using KissU.Core.Extensions;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Implements
{
    [ModuleName("IdentityUser")]
    public class IdentityUserService : ProxyServiceBase, IIdentityUserService
    {
        private readonly IIdentityUserAppService _userAppService;

        public IdentityUserService(IIdentityUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public virtual Task<IdentityUserDto> GetAsync(Guid id)
        {
            return _userAppService.GetAsync(id);
        }

        public virtual async Task<PagedResult<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            var result = await _userAppService.GetListAsync(input);
            return result.MapTo<PagedResult<IdentityUserDto>>();
        }

        public virtual Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return _userAppService.CreateAsync(input);
        }

        public virtual Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            return _userAppService.UpdateAsync(id, input);
        }

        public virtual Task DeleteAsync(Guid id)
        {
            return _userAppService.DeleteAsync(id);
        }

        public virtual async Task<ListResult<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            var result = await _userAppService.GetRolesAsync(id);
            return result.MapTo<ListResult<IdentityRoleDto>>();
        }

        public virtual Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            return _userAppService.UpdateRolesAsync(id, input);
        }

        public virtual Task<IdentityUserDto> FindByUsernameAsync(string username)
        {
            return _userAppService.FindByUsernameAsync(username);
        }

        public virtual Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return _userAppService.FindByEmailAsync(email);
        }
    }
}