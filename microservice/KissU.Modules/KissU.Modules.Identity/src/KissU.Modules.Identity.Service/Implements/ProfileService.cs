using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Implements
{
    [ModuleName("Profile")]
    public class ProfileService : ProxyServiceBase, IProfileService
    {
        public ProfileService(IProfileAppService profileAppService)
        {
            ProfileAppService = profileAppService;
        }

        protected IProfileAppService ProfileAppService { get; }

        public virtual Task<ProfileDto> GetAsync()
        {
            return ProfileAppService.GetAsync();
        }

        public virtual Task<ProfileDto> UpdateAsync(UpdateProfileDto input)
        {
            return ProfileAppService.UpdateAsync(input);
        }

        public virtual Task ChangePasswordAsync(ChangePasswordInput input)
        {
            return ProfileAppService.ChangePasswordAsync(input);
        }
    }
}