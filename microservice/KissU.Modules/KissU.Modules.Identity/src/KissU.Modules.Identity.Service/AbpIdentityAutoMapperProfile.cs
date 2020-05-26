using AutoMapper;
using KissU.Core.Common.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service
{
    public class AbpIdentityAutoMapperProfile : Profile
    {
        public AbpIdentityAutoMapperProfile()
        {
            CreateMap<ListResultDto<IdentityRoleDto>, ListResult<IdentityRoleDto>>();
            CreateMap<PagedResultDto<IdentityRoleDto>, PagedResult<IdentityRoleDto>>();
            CreateMap<ListResultDto<IdentityUserDto>, ListResult<IdentityUserDto>>();
            CreateMap<PagedResultDto<IdentityUserDto>, PagedResult<IdentityUserDto>>();
        }
    }
}