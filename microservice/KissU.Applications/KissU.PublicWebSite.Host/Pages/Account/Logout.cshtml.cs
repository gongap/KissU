using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KissU.PublicWebSite.Host.Pages.Account
{
    public class LogoutModel : AbpPageModel
    {
        public virtual async Task<IActionResult> OnGetAsync()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
