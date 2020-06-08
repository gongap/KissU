using KissU.Modules.PermissionManagement.Application.Contracts;
using KissU.Modules.PermissionManagement.Domain;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement.Application
{
    [DependsOn(
        typeof(AbpPermissionManagementDomainModule), 
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpPermissionManagementApplicationModule : AbpModule
    {
        
    }
}
