using AutoMapper;
using KissU.Modules.Account.Web.Pages.Account;
using KissU.Modules.Identity.Application.Contracts;

namespace KissU.Modules.Account.Web
{
    public class AbpAccountWebAutoMapperProfile : Profile
    {
        public AbpAccountWebAutoMapperProfile()
        {
            CreateMap<ProfileDto, PersonalSettingsInfoModel>();
        }
    }
}
