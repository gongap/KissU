using System;
using System.Threading.Tasks;
using KissU.Core.Common.Application.Dtos;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IIdentityRoleService : IServiceKey
    {
        [HttpGet]
        [ServiceRoute("all")]
        Task<ListResult<IdentityRoleDto>> GetAllListAsync();


        [HttpGet]
        Task<PagedResult<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input);


        [HttpGet]
        [ServiceRoute("{id}")]
        Task<IdentityRoleDto> GetAsync(Guid id);


        [HttpPost]
        Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input);


        [HttpPut]
        [ServiceRoute("{id}")]
        Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input);


        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task DeleteAsync(Guid id);
    }
}
