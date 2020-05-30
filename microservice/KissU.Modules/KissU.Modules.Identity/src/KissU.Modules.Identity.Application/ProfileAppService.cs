using System.Threading.Tasks;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Domain;
using KissU.Modules.Identity.Domain.Extensions;
using KissU.Modules.Identity.Domain.Shared.Settings;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Settings;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Application
{
    [Authorize]
    public class ProfileAppService : IdentityAppServiceBase, IProfileAppService
    {
        protected IdentityUserManager UserManager { get; }

        public ProfileAppService(IdentityUserManager userManager)
        {
            UserManager = userManager;
        }

        public virtual async Task<ProfileDto> GetAsync()
        {
            return ObjectMapper.Map<IdentityUser, ProfileDto>(
                await UserManager.GetByIdAsync(CurrentUser.GetId())
            );
        }

        public virtual async Task<ProfileDto> UpdateAsync(UpdateProfileDto input)
        {
            var user = await UserManager.GetByIdAsync(CurrentUser.GetId());

            if (await SettingProvider.IsTrueAsync(IdentitySettingNames.User.IsUserNameUpdateEnabled))
            {
                (await UserManager.SetUserNameAsync(user, input.UserName)).CheckErrors();
            }

            if (await SettingProvider.IsTrueAsync(IdentitySettingNames.User.IsEmailUpdateEnabled))
            {
                (await UserManager.SetEmailAsync(user, input.Email)).CheckErrors();
            }

            (await UserManager.SetPhoneNumberAsync(user, input.PhoneNumber)).CheckErrors();

            user.Name = input.Name;
            user.Surname = input.Surname;

            input.MapExtraPropertiesTo(user);

            (await UserManager.UpdateAsync(user)).CheckErrors();

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityUser, ProfileDto>(user);
        }

        public virtual async Task ChangePasswordAsync(ChangePasswordInput input)
        {
            var currentUser = await UserManager.GetByIdAsync(CurrentUser.GetId());
            (await UserManager.ChangePasswordAsync(currentUser, input.CurrentPassword, input.NewPassword)).CheckErrors();
        }
    }
}
