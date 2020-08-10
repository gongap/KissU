using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KissU.PublicWebSite.Host.Pages.Account
{
    public class LogoutModel : AbpPageModel
    {
        public virtual IActionResult OnGet()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
