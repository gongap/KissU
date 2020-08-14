using KissU.Modules.Account.Application;
using KissU.Modules.Account.Service.Contracts;
using KissU.Modules.Identity.Domain;
using KissU.Modules.Identity.EntityFrameworkCore;
using KissU.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(AccountServiceContractsModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule)
        )]
    public class AbpAccountServiceModule : Volo.Abp.Modularity.AbpModule, IAbpStartupModule
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
        }
    }
}