using System;
using System.Threading.Tasks;
using KissU.Common;
using KissU.Dependency;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Identity.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IIdentityUserService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> GetAsync(string id);

        [HttpPost(true)]
        Task<PagedResult<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input);

        [HttpPost(true)]
        Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input);

        [HttpPut(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> UpdateAsync(string id, IdentityUserUpdateDto input);

        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task DeleteAsync(string id);

        [HttpGet(true)]
        [ServiceRoute("{id}/roles")]
        Task<ListResult<IdentityRoleDto>> GetRolesAsync(string id);

        [HttpPut(true)]
        [ServiceRoute("{id}/roles")]
        Task UpdateRolesAsync(string id, IdentityUserUpdateRolesDto input);

        [HttpGet(true)]
        [ServiceRoute("by-username/{userName}")]
        Task<IdentityUserDto> FindByUsernameAsync(string username);

        [HttpGet(true)]
        [ServiceRoute("by-email/{email}")]
        Task<IdentityUserDto> FindByEmailAsync(string email);
    }
}