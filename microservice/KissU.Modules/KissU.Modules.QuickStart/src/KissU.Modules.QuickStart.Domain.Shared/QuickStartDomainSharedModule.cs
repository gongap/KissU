using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using KissU.Modules.QuickStart.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.QuickStart
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class QuickStartDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<QuickStartDomainSharedModule>("KissU.Modules.QuickStart");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<QuickStartResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/QuickStart");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("QuickStart", typeof(QuickStartResource));
            });
        }
    }
}
