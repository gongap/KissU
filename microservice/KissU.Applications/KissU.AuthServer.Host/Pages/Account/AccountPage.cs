using KissU.Modules.Account.Application.Contracts.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KissU.AuthServer.Host.Pages.Account
{
    public abstract class AccountPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AccountResource> L { get; set; }
    }
}
