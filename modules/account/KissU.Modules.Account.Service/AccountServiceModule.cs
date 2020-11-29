using KissU.Modules.Account.Service.Contracts;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.Account;
using KissU.Modularity;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(AccountServiceContractsModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule)
        )]
    public class AbpAccountServiceModule : AbpBusinessModule
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