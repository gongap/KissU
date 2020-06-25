using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.DependencyInjection;

namespace KissU.AuthServer.Host.Pages.Account
{
    [ExposeServices(typeof(LogoutModel))]
    public class IdentityServerSupportedLogoutModel : LogoutModel
    {
        protected IIdentityServerInteractionService Interaction { get; }

        public IdentityServerSupportedLogoutModel(IIdentityServerInteractionService interaction)
        {
            Interaction = interaction;
        }

        public override async Task<IActionResult> OnGetAsync()
        {
            await SignInManager.SignOutAsync();

            var logoutId = Request.Query["logoutId"].ToString();

            if (!string.IsNullOrEmpty(logoutId))
            {
                var logoutContext = await Interaction.GetLogoutContextAsync(logoutId);

                var postLogoutUri = logoutContext.PostLogoutRedirectUri;

                if (!string.IsNullOrEmpty(postLogoutUri))
                {
                    return Redirect(postLogoutUri);
                }
            }

            if (ReturnUrl != null)
            {
                return LocalRedirect(ReturnUrl);
            }

            return RedirectToPage("/Account/Login");
        }
    }
}
