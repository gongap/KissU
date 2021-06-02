using KissU.Modularity;
using KissU.Modules.Identity.Application;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Modules.Identity.Service.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Identity.Service
{
    [DependsOn(typeof(IdentityServiceContractsModule),
        typeof(IdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule)
    )]
    public class IdentityServiceModule : AbpModule, IBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<AbpIdentitySettingDefinitionProvider>();
            });

            context.Services.GetObject<IdentityBuilder>().AddTokenProviders();

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}