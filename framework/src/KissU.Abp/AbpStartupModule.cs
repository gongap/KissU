using KissU.Abp.Localization;
using Volo.Abp.Autofac;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Security;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule)
        , typeof(AbpSecurityModule)
        , typeof(AbpValidationModule)
        , typeof(AbpExceptionHandlingModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpStartupModule>("KissU.Abp");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<KissUAbpResource>("zh-Hans")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Resources");

                options.Languages.Add(new LanguageInfo("zh", "zh", "zh-Hans"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("KissU.Abp", typeof(KissUAbpResource));
            });
        }
    }
}