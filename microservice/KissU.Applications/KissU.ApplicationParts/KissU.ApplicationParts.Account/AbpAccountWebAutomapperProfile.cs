using AutoMapper;
using KissU.ApplicationParts.Account.Pages.Account;
using KissU.Modules.Identity.Application.Contracts;

namespace KissU.ApplicationParts.Account
{
    public class AbpAccountWebAutoMapperProfile : Profile
    {
        public AbpAccountWebAutoMapperProfile()
        {
            CreateMap<ProfileDto, PersonalSettingsInfoModel>();
        }
    }
}
