using System.Threading.Tasks;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Settings;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Domain;
using KissU.Modules.Identity.Domain.Extensions;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;
using IdentityUser = KissU.Modules.Identity.Domain.IdentityUser;

namespace KissU.Modules.Account.Application
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IdentityUserManager UserManager { get; }

        public AccountAppService(
            IdentityUserManager userManager,
            IIdentityRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
            UserManager = userManager;
            UserManager = userManager;
        }

        public virtual async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            await CheckSelfRegistrationAsync();

            var user = new IdentityUser(GuidGenerator.Create(), input.UserName, input.EmailAddress, CurrentTenant.Id);

            (await UserManager.CreateAsync(user, input.Password)).CheckErrors();

            await UserManager.SetEmailAsync(user,input.EmailAddress);
            await UserManager.AddDefaultRolesAsync(user);

            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        }

        protected virtual async Task CheckSelfRegistrationAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled))
            {
                throw new UserFriendlyException(L["SelfRegistrationDisabledMessage"]);
            }
        }
    }
}