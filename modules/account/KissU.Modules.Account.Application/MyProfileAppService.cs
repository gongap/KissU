using KissU.Modules.Account.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Identity;

namespace KissU.Modules.Account.Application
{
    [Authorize]
    public class MyProfileAppService : ProfileAppService, IMyProfileAppService
    {
        public MyProfileAppService(IdentityUserManager userManager, IOptions<IdentityOptions> identityOptions) : base(userManager, identityOptions)
        {
        }
    }
}
