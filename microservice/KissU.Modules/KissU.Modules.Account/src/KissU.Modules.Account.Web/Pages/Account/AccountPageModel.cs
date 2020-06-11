using System;
using System.Collections.Generic;
using System.Linq;
using KissU.Modules.Account.Application.Contracts.Localization;
using KissU.Modules.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using IdentityUser = KissU.Modules.Identity.Domain.IdentityUser;

namespace KissU.Modules.Account.Web.Pages.Account
{
    public abstract class AccountPageModel : AbpPageModel
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public IdentityUserManager UserManager { get; set; }

        protected AccountPageModel()
        {
            LocalizationResourceType = typeof(AccountResource);
            ObjectMapperContext = typeof(AbpAccountWebModule);
        }

        protected virtual RedirectResult RedirectSafely(string returnUrl, string returnUrlHash = null)
        {
            return Redirect(GetRedirectUrl(returnUrl, returnUrlHash));
        }

        protected virtual void CheckIdentityErrors(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                throw new UserFriendlyException("Operation failed: " + identityResult.Errors.Select(e => $"[{e.Code}] {e.Description}").JoinAsString(", "));
            }

            //identityResult.CheckErrors(LocalizationManager); //TODO: Get from old Abp
        }

        protected virtual string GetRedirectUrl(string returnUrl, string returnUrlHash = null)
        {
            returnUrl = NormalizeReturnUrl(returnUrl);

            if (!returnUrlHash.IsNullOrWhiteSpace())
            {
                returnUrl = returnUrl + returnUrlHash;
            }

            return returnUrl;
        }

        protected virtual string NormalizeReturnUrl(string returnUrl)
        {
            if (returnUrl.IsNullOrEmpty())
            {
                return GetAppHomeUrl();
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }

            return GetAppHomeUrl();
        }

        protected virtual void CheckCurrentTenant(Guid? tenantId)
        {
            if (CurrentTenant.Id != tenantId)
            {
                throw new ApplicationException($"Current tenant is different than given tenant. CurrentTenant.Id: {CurrentTenant.Id}, given tenantId: {tenantId}");
            }
        }

        protected virtual string GetAppHomeUrl()
        {
            return "/"; //TODO: ???
        }
    }
}
