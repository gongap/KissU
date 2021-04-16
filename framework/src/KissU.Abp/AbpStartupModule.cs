using KissU.Abp.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule)
        , typeof(AbpAspNetCoreModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var cultures = new List<CultureInfo> { new CultureInfo("zh-Hans"), new CultureInfo("en") };
            Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("zh-Hans");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

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
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("KissU.Abp", typeof(KissUAbpResource));
            });
        }
    }
}