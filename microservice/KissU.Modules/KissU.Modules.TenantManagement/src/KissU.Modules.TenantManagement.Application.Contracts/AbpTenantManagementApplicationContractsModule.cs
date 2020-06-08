using KissU.Modules.TenantManagement.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.Application.Contracts
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(AbpTenantManagementDomainSharedModule))]
    public class AbpTenantManagementApplicationContractsModule : AbpModule
    {

    }
}