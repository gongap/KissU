using System.Security.Claims;
using System.Threading.Tasks;
using KissU.Modules.Account.Service.Contracts.Models;
using KissU.Randoms;
using KissU.Security.Principals;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace KissU.Modules.Account.Service.Applications
{
    public class AuthAppService : ApplicationService, IAuthAppService
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly AbpUserClaimsPrincipalFactory _userClaimsPrincipalFactory;
        private readonly IOptions<IdentityOptions> _identityOptions;
        private readonly IRandomBuilder _randomBuilder;

        public AuthAppService(IdentityUserManager identityUserManager, AbpUserClaimsPrincipalFactory userClaimsPrincipalFactory, IOptions<IdentityOptions> identityOptions, IRandomBuilder randomBuilder)
        {
            _identityUserManager = identityUserManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _identityOptions = identityOptions;
            _randomBuilder = randomBuilder;
        }

        public async Task<ClaimsPrincipal> AuthAsync(AuthDto input)
        {
            await _identityOptions.SetAsync();
            var user = await _identityUserManager.FindByNameAsync(input.Mobile);
            if (user == null)
            {
                user = new Volo.Abp.Identity.IdentityUser(GuidGenerator.Create(), input.Mobile, $"null@hrst.com", CurrentTenant.Id);
                user.Name = _randomBuilder.GenerateString(10);
                user.SetPhoneNumber(input.Mobile, true);
                (await _identityUserManager.CreateAsync(user)).CheckErrors();
               await CurrentUnitOfWork.SaveChangesAsync();
            }

            if (user != null)
            {
                return await _userClaimsPrincipalFactory.CreateAsync(user);
            }

            return UnauthenticatedPrincipal.Instance;
        }
    }
}
