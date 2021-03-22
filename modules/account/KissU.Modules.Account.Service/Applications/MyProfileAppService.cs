using KissU.Modules.Account.Service.Applications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Volo.Abp.Identity
{
    [Authorize]
    public class MyProfileAppService : ProfileAppService, IMyProfileAppService
    {
        public MyProfileAppService(IdentityUserManager userManager, IOptions<IdentityOptions> identityOptions) : base(userManager, identityOptions)
        {
        }
    }
}
