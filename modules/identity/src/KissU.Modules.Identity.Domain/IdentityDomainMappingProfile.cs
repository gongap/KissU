using AutoMapper;
using KissU.Modules.Identity.Domain.Shared;
using KissU.Modules.Users.Abstractions;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Domain
{
    public class IdentityDomainMappingProfile : Profile
    {
        public IdentityDomainMappingProfile()
        {
            CreateMap<IdentityUser, UserEto>();
            CreateMap<IdentityClaimType, IdentityClaimTypeEto>();
            CreateMap<IdentityRole, IdentityRoleEto>();
        }
    }
}