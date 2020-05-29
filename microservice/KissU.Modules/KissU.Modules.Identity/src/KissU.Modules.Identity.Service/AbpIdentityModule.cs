using KissU.Abp.Autofac;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
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
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}