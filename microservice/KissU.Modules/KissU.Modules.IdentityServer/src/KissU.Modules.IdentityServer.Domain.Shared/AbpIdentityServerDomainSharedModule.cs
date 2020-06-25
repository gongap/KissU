using KissU.Modules.IdentityServer.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.IdentityServer.Domain.Shared
{
    [DependsOn(
        typeof(AbpValidationModule)
        )]
    public class AbpIdentityServerDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIdentityServerDomainSharedModule>("KissU.Modules.IdentityServer.Domain.Shared");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<AbpIdentityServerResource>("en")
                    .AddBaseTypes(
                        typeof(AbpValidationResource)
                    ).AddVirtualJson("/Localization/Resources");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Volo.IdentityServer", typeof(AbpIdentityServerResource));
            });
        }
    }
}
