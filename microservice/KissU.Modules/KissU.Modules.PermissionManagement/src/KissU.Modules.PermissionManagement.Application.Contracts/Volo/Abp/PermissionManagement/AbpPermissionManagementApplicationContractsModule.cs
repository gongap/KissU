using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainSharedModule))]
    public class AbpPermissionManagementApplicationContractsModule : AbpModule
    {
        
    }
}
