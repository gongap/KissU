using KissU.Abp.Autofac;
using KissU.Modules.Identity.Application;
using KissU.Modules.Identity.Domain;
using KissU.Modules.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Identity.Service
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpIdentityModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<AbpIdentitySettingDefinitionProvider>();
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}