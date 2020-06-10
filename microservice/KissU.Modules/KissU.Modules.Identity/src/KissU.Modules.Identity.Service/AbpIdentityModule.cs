using KissU.Abp.Autofac;
using KissU.Modules.Identity.Application;
using KissU.Modules.Identity.Application.Contracts.Localization;
using KissU.Modules.Identity.Application.Settings;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using KissU.Modules.Identity.Domain;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Identity.Service
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpIdentityModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<AbpIdentitySettingDefinitionProvider>();
                options.DefinitionProviders.Add<AccountSettingDefinitionProvider>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}