using System.Security.Claims;
using System.Threading.Tasks;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Models;
using KissU.Randoms;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.Identity;

namespace KissU.Modules.Account.Application
{
    public class MyAccountAppService : AccountAppService, IMyAccountAppService
    {
        protected AbpUserClaimsPrincipalFactory UserClaimsPrincipalFactory { get; }
        protected IRandomBuilder RandomBuilder { get; }

        public MyAccountAppService(AbpUserClaimsPrincipalFactory userClaimsPrincipalFactory, IRandomBuilder randomBuilder, IdentityUserManager userManager, IIdentityRoleRepository roleRepository, IAccountEmailer accountEmailer, IdentitySecurityLogManager identitySecurityLogManager, IOptions<IdentityOptions> identityOptions)
            : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
        {
            UserClaimsPrincipalFactory = userClaimsPrincipalFactory;
            RandomBuilder = randomBuilder;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input">The parameters.</param>
        /// <returns>Task&lt;ClaimsPrincipal&gt;.</returns>
        public async Task<ClaimsPrincipal> SignInAsync(SignInDto input)
        {
            await IdentityOptions.SetAsync();
            var user = await UserManager.FindByNameAsync(input.UserName);
            if (user != null)
            {
                var check = await UserManager.CheckPasswordAsync(user, input.Passowrd);
                if (check)
                {
                    return await UserClaimsPrincipalFactory.CreateAsync(user);
                }
            }

            throw new UserFriendlyException("用户名或密码错误");
        }
    }
}
