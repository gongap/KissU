using KissU.Abp;
using KissU.Abp.Autofac;
using KissU.Abp.Business;
using KissU.Modules.Account.Application;
using KissU.Modules.Identity.Domain;
using KissU.Modules.Identity.EntityFrameworkCore;
using KissU.Services.Account.Contract;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(AccountServiceContractsModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
        )]
    public class AbpAccountServiceModule : AbpModule, IAbpStartupModule
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