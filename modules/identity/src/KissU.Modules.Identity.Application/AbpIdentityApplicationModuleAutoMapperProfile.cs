using AutoMapper;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Domain;

namespace KissU.Modules.Identity.Application
{
    public class AbpIdentityApplicationModuleAutoMapperProfile : Profile
    {
        public AbpIdentityApplicationModuleAutoMapperProfile()
        {
            CreateMap<IdentityUser, IdentityUserDto>()
                .MapExtraProperties();

            CreateMap<IdentityRole, IdentityRoleDto>()
                .MapExtraProperties();
            
            CreateMap<IdentityUser, ProfileDto>()
                .MapExtraProperties();
        }
    }
}