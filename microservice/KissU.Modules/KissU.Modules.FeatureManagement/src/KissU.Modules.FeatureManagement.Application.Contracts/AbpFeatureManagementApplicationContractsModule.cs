using KissU.Modules.FeatureManagement.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.FeatureManagement.Application.Contracts
{
    [DependsOn(
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class AbpFeatureManagementApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpFeatureManagementApplicationContractsModule>("KissU.Modules.FeatureManagement.Application.Contracts");
            });
        }
    }
}
