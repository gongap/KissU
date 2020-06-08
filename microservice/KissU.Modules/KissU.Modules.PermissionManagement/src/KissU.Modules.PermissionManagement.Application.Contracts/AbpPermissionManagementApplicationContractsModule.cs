using KissU.Modules.PermissionManagement.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainSharedModule))]
    public class AbpPermissionManagementApplicationContractsModule : AbpModule
    {
        
    }
}
