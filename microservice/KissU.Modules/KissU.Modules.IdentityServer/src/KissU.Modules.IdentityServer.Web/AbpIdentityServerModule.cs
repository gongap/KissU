using KissU.Autofac;
using KissU.Modules.Identity.Domain;
using KissU.Modules.IdentityServer.DbMigrations.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.IdentityServer.Web
{
    [DependsOn(
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpIdentityServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<AbpIdentitySettingDefinitionProvider>();
            });
        }
    }
}