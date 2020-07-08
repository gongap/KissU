using Volo.Abp.Account.Web.Pages.Account;
using AutoMapper;
using KissU.Modules.Identity.Application.Contracts;

namespace Volo.Abp.Account.Web
{
    public class AbpAccountWebAutoMapperProfile : Profile
    {
        public AbpAccountWebAutoMapperProfile()
        {
            CreateMap<ProfileDto, PersonalSettingsInfoModel>();
        }
    }
}
