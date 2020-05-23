using System;
using System.Threading.Tasks;
using KissU.Core.Common.Application.Dtos;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IIdentityUserService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> GetAsync(Guid id);

        [HttpPost(true)]
        Task<PagedResult<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input);

        [HttpPost(true)]
        Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input);

        [HttpPut(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input);

        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task DeleteAsync(Guid id);

        [HttpGet(true)]
        [ServiceRoute("{id}/roles")]
        Task<ListResult<IdentityRoleDto>> GetRolesAsync(Guid id);

        [HttpPut(true)]
        [ServiceRoute("{id}/roles")]
        Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input);

        [HttpGet(true)]
        [ServiceRoute("by-username/{userName}")]
        Task<IdentityUserDto> FindByUsernameAsync(string username);

        [HttpGet(true)]
        [ServiceRoute("by-email/{email}")]
        Task<IdentityUserDto> FindByEmailAsync(string email);
    }
}