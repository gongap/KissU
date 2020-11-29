using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.Identity.Service.Implements
{
    [ModuleName("Profile")]
    public class ProfileService : ProxyServiceBase, IProfileService
    {
        private readonly IProfileAppService _appService;

        public ProfileService(IProfileAppService appService)
        {
            _appService = appService;
        }

        public virtual Task<ProfileDto> GetAsync()
        {
            return _appService.GetAsync();
        }

        public virtual Task<ProfileDto> UpdateAsync(UpdateProfileDto input)
        {
            return _appService.UpdateAsync(input);
        }

        public virtual Task ChangePasswordAsync(ChangePasswordInput input)
        {
            return _appService.ChangePasswordAsync(input);
        }
    }
}