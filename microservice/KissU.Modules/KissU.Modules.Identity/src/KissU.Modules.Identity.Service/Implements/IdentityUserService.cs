using System.Threading.Tasks;
using KissU.Core.Common;
using KissU.Core.Dependency;
using KissU.Core.Extensions;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Surging.ProxyGenerator;

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

        public virtual Task<IdentityUserDto> GetAsync(string id)
        {
            return _userAppService.GetAsync(id.ToGuid());
        }

        public virtual Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return _userAppService.CreateAsync(input);
        }

        public virtual Task<IdentityUserDto> UpdateAsync(string id, IdentityUserUpdateDto input)
        {
            return _userAppService.UpdateAsync(id.ToGuid(), input);
        }

        public virtual Task DeleteAsync(string id)
        {
            return _userAppService.DeleteAsync(id.ToGuid());
        }

        public virtual async Task<ListResult<IdentityRoleDto>> GetRolesAsync(string id)
        {
            var result = await _userAppService.GetRolesAsync(id.ToGuid());
            return new ListResult<IdentityRoleDto>(result.Items);
        }

        public virtual async Task<PagedResult<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            var result = await _userAppService.GetListAsync(input);
            return new PagedResult<IdentityUserDto>(result.TotalCount, result.Items);
        }

        public virtual Task UpdateRolesAsync(string id, IdentityUserUpdateRolesDto input)
        {
            return _userAppService.UpdateRolesAsync(id.ToGuid(), input);
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