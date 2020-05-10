using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IIdentityRoleService : IServiceKey
    {
        //[HttpGet]
        //[ServiceRoute("all")]
        //Task<ListResultDto<IdentityRoleDto>> GetAllListAsync();


        //[HttpGet]
        //Task<PagedResultDto<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input);


        [HttpGet]
        [ServiceRoute("{id}")]
        Task<IdentityRoleDto> GetAsync(Guid id);


        [HttpPost]
        Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input);


        [HttpPut]
        [ServiceRoute("{id}")]
        Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input);


        [HttpDelete]
        [ServiceRoute("{id}")]
        Task DeleteAsync(Guid id);
    }
}
