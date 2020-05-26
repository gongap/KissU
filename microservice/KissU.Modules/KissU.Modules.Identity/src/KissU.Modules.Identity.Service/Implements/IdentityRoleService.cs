using System;
using System.Threading.Tasks;
using KissU.Core.Common.Application.Dtos;
using KissU.Core.Dependency;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

namespace KissU.Modules.Identity.Service.Implements
{
    [ModuleName("IdentityRole")]
    public class IdentityRoleService : ProxyServiceBase, IIdentityRoleService
    {
        private readonly IIdentityRoleAppService _appService;
        private readonly IObjectMapper _objectMapper;

        public IdentityRoleService(IIdentityRoleAppService appService, IObjectMapper objectMapper)
        {
            _appService = appService;
            _objectMapper = objectMapper;
        }

        public virtual async Task<ListResult<IdentityRoleDto>> GetAllListAsync()
        {
            var result = await _appService.GetAllListAsync();
            return _objectMapper.Map<ListResultDto<IdentityRoleDto>, ListResult<IdentityRoleDto>>(result);
        }

        public virtual async Task<PagedResult<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await _appService.GetListAsync(input);
            return _objectMapper.Map<PagedResultDto<IdentityRoleDto>, PagedResult<IdentityRoleDto>>(result);
        }

        public virtual Task<IdentityRoleDto> GetAsync(Guid id)
        {
            return _appService.GetAsync(id);
        }

        public virtual Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
        {
            return _appService.CreateAsync(input);
        }

        public virtual Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input)
        {
            return _appService.UpdateAsync(id, input);
        }

        public virtual Task DeleteAsync(Guid id)
        {
            return _appService.DeleteAsync(id);
        }
    }
}