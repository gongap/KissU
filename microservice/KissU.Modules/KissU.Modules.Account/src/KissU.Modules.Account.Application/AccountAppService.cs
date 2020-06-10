using System;
using System.Threading.Tasks;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Models;
using KissU.Modules.Account.Application.Contracts.Settings;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Domain;
using KissU.Modules.Identity.Domain.Extensions;
using Microsoft.AspNetCore.Identity;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using UserLoginInfo = KissU.Modules.Account.Application.Contracts.Models.UserLoginInfo;
using IdentityUser = KissU.Modules.Identity.Domain.IdentityUser;

namespace KissU.Modules.Account.Application
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IdentityUserManager UserManager { get; }
        protected SignInManager<IdentityUser> SignInManager { get; }

        public AccountAppService(
            SignInManager<IdentityUser> signInManager,
            IdentityUserManager userManager,
            ISettingProvider settingProvider,
            IIdentityRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
            UserManager = userManager;
            SignInManager = signInManager;
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

        public virtual async Task<AbpLoginResult> Login(UserLoginInfo login)
        {
            await CheckLocalLoginAsync();

            ValidateLoginInfo(login);

            await ReplaceEmailToUsernameOfInputIfNeeds(login);

            return GetAbpLoginResult(await SignInManager.PasswordSignInAsync(
                login.UserNameOrEmailAddress,
                login.Password,
                login.RememberMe,
                true
            ));
        }

        public virtual async Task Logout()
        {
            await SignInManager.SignOutAsync();
        }

        public virtual async Task<AbpLoginResult> CheckPassword(UserLoginInfo login)
        {
            ValidateLoginInfo(login);

            await ReplaceEmailToUsernameOfInputIfNeeds(login);

            var identityUser = await UserManager.FindByNameAsync(login.UserNameOrEmailAddress);

            if (identityUser == null)
            {
                return new AbpLoginResult(LoginResultType.InvalidUserNameOrPassword);
            }

            return GetAbpLoginResult(await SignInManager.CheckPasswordSignInAsync(identityUser, login.Password, true));
        }

        protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds(UserLoginInfo login)
        {
            if (!ValidationHelper.IsValidEmailAddress(login.UserNameOrEmailAddress))
            {
                return;
            }

            var userByUsername = await UserManager.FindByNameAsync(login.UserNameOrEmailAddress);
            if (userByUsername != null)
            {
                return;
            }

            var userByEmail = await UserManager.FindByEmailAsync(login.UserNameOrEmailAddress);
            if (userByEmail == null)
            {
                return;
            }

            login.UserNameOrEmailAddress = userByEmail.UserName;
        }

        private static AbpLoginResult GetAbpLoginResult(SignInResult result)
        {
            if (result.IsLockedOut)
            {
                return new AbpLoginResult(LoginResultType.LockedOut);
            }

            if (result.RequiresTwoFactor)
            {
                return new AbpLoginResult(LoginResultType.RequiresTwoFactor);
            }

            if (result.IsNotAllowed)
            {
                return new AbpLoginResult(LoginResultType.NotAllowed);
            }

            if (!result.Succeeded)
            {
                return new AbpLoginResult(LoginResultType.InvalidUserNameOrPassword);
            }

            return new AbpLoginResult(LoginResultType.Success);
        }

        protected virtual void ValidateLoginInfo(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentException(nameof(login));
            }

            if (login.UserNameOrEmailAddress.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(login.UserNameOrEmailAddress));
            }

            if (login.Password.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(login.Password));
            }
        }

        protected virtual async Task CheckLocalLoginAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
            {
                throw new UserFriendlyException(L["LocalLoginDisabledMessage"]);
            }
        }
    }
}