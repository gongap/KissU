using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Identity.Service.Contracts;

namespace Volo.Abp.Identity.Service.Implements
{
    [ModuleName("Profile")]
    public class ProfileService : ProxyServiceBase, IProfileService
    {
        protected IProfileAppService ProfileAppService { get; }

        public ProfileService(IProfileAppService profileAppService)
        {
            ProfileAppService = profileAppService;
        }

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
