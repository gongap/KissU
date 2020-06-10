using System.Threading.Tasks;
using KissU.Modules.Identity.Application.Contracts.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.UI.Navigation;

namespace KissU.Modules.Account.Web
{
    public class AbpAccountUserMenuContributor : IMenuContributor
    {
        public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.User)
            {
                return Task.CompletedTask;
            }

            var uiResource = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpUiResource>>();
            var accountResource = context.ServiceProvider.GetRequiredService<IStringLocalizer<AccountResource>>();

            context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["ManageYourProfile"], url: "/Account/Manage", icon: "fa fa-cog", order: 1000, null));
            context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));

            return Task.CompletedTask;
        }
    }
}