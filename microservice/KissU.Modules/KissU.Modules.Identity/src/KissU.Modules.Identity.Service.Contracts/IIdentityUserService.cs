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
        [HttpGet]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> GetAsync(Guid id);

        [HttpGet]
        Task<PagedResult<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input);

        [HttpPost]
        Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input);

        [HttpPut]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input);

        [HttpDelete]
        [ServiceRoute("{id}")]
        Task DeleteAsync(Guid id);

        [HttpGet]
        [ServiceRoute("{id}/roles")]
        Task<ListResult<IdentityRoleDto>> GetRolesAsync(Guid id);

        [HttpPut]
        [ServiceRoute("{id}/roles")]
        Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input);

        [HttpGet]
        [ServiceRoute("by-username/{userName}")]
        Task<IdentityUserDto> FindByUsernameAsync(string username);

        [HttpGet]
        [ServiceRoute("by-email/{email}")]
        Task<IdentityUserDto> FindByEmailAsync(string email);
    }
}
