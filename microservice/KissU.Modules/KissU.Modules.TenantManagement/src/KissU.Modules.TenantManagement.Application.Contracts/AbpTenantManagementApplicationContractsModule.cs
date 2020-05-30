using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(AbpTenantManagementDomainSharedModule))]
    public class AbpTenantManagementApplicationContractsModule : AbpModule
    {

    }
}