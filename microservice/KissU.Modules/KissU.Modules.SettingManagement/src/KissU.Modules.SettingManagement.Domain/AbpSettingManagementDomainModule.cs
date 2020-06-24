using KissU.Modules.SettingManagement.Domain.Shared;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.SettingManagement.Domain
{
    [DependsOn(
        typeof(AbpSettingsModule),
        typeof(AbpDddDomainModule),
        typeof(AbpSettingManagementDomainSharedModule), 
        typeof(AbpCachingModule)
        )]
    public class AbpSettingManagementDomainModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<SettingManagementOptions>(options =>
            {
                options.Providers.Add<DefaultValueSettingManagementProvider>();
                options.Providers.Add<ConfigurationSettingManagementProvider>();
                options.Providers.Add<GlobalSettingManagementProvider>();
                options.Providers.Add<TenantSettingManagementProvider>();
                options.Providers.Add<UserSettingManagementProvider>();
            });
        }
    }
}
