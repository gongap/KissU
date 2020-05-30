using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement
{
    [DependsOn(
        typeof(AbpPermissionManagementDomainModule), 
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpPermissionManagementApplicationModule : AbpModule
    {
        
    }
}
