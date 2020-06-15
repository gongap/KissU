using KissU.Abp.Autofac;
using KissU.Modules.Account.Application;
using KissU.Modules.Account.Application.Contracts.Localization;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using KissU.Modules.Identity.Domain;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(AbpAccountApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
        )]
    public class AbpAccountModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<AbpIdentitySettingDefinitionProvider>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}