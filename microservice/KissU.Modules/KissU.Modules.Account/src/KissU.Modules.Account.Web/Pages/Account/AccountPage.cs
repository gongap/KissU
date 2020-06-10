using KissU.Modules.Identity.Application.Contracts.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KissU.Modules.Account.Web.Pages.Account
{
    public abstract class AccountPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AccountResource> L { get; set; }
    }
}
