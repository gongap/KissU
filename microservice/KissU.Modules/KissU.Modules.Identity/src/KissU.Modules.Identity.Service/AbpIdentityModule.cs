using KissU.Abp.Autofac;
using KissU.Modules.Identity.Application;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using KissU.Modules.Identity.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Identity.Service
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AppAutofacModule)
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