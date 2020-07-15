using System;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Domain.Shared.Localization.Blogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace KissU.PublicWebSite.Host
{
    public class PublicWebSiteMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public PublicWebSiteMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            context.Menu.AddItem(new ApplicationMenuItem("App.Home", "Home", "/"));
            context.Menu.AddItem(new ApplicationMenuItem("App.Products", "Products", "/Products"));
            context.Menu.AddItem(new ApplicationMenuItem("App.Blog", "Blog", "/Blogs"));

            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<BloggingResource>>();
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";
            if (currentUser.IsAuthenticated)
            {
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", l["ManageYourProfile"], $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000, null, "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", l["Logout"], url: "/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));
            }

            return Task.CompletedTask;
        }
    }
}
