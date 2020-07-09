using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace KissU.PublicWebSite.Host
{
    public class PublicWebSiteMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            //TODO: Localize menu items
            context.Menu.AddItem(new ApplicationMenuItem("App.Home", "Home", "/"));

            return Task.CompletedTask;
        }
    }
}
