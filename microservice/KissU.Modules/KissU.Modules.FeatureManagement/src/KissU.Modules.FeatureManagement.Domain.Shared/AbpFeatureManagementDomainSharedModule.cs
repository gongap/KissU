using KissU.Modules.FeatureManagement.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.FeatureManagement.Domain.Shared
{
    [DependsOn(
        typeof(AbpValidationModule)
        )]
    public class AbpFeatureManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpFeatureManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpFeatureManagementResource>("en")
                    .AddBaseTypes(
                        typeof(AbpValidationResource)
                    ).AddVirtualJson("Volo/Abp/FeatureManagement/Localization/Domain");
            });
        }
    }
}
