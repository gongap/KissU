using AutoMapper;
using KissU.AuthServer.Host.Pages.Account;
using KissU.Modules.Identity.Application.Contracts;

namespace KissU.AuthServer.Host.Modules.Account
{
    public class AccountWebAutoMapperProfile : Profile
    {
        public AccountWebAutoMapperProfile()
        {
            CreateMap<ProfileDto, PersonalSettingsInfoModel>();
        }
    }
}
