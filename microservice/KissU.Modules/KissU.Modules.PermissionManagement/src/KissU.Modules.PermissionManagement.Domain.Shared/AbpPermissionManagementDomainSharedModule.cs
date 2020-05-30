using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using KissU.Modules.PermissionManagement.Localization;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.PermissionManagement
{
    [DependsOn(
        typeof(AbpValidationModule)
        )]
    public class AbpPermissionManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpPermissionManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpPermissionManagementResource>("en")
                    .AddBaseTypes(
                        typeof(AbpValidationResource)
                    ).AddVirtualJson("/Volo/Abp/PermissionManagement/Localization/Domain");
            });
        }
    }
}
