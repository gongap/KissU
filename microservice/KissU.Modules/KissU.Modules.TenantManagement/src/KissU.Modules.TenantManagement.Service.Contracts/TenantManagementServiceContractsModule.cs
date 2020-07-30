using KissU.Modules.TenantManagement.Application.Contracts;
using KissU.Modules.TenantManagement.Domain.Shared.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Services.TenantManagement.Contract
{
    [DependsOn(
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpUiModule)
    )]
    public class TenantManagementServiceContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpTenantManagementResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}