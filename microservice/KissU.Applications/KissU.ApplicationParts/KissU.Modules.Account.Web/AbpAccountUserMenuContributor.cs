using System.Threading.Tasks;
using KissU.Modules.Account.Application.Contracts.Localization;
using Localization.Resources.AbpUi;
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

            var uiResource = context.GetLocalizer<AbpUiResource>();
            var accountResource = context.GetLocalizer<AccountResource>();

            context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["ManageYourProfile"], url: "~/Account/Manage", icon: "fa fa-cog", order: 1000, null));
            context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));

            return Task.CompletedTask;
        }
    }
}
