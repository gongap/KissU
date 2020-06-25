using KissU.Modules.Account.Application.Contracts.Localization;
using KissU.Modules.Identity.Application.Contracts;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.Account.Application.Contracts
{
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule),
            typeof(AbpLocalizationModule)
    )]
    public class AbpAccountApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAccountApplicationContractsModule>("KissU.Modules.Account.Application.Contracts");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AccountResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Resources");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Volo.Abp.Account", typeof(AccountResource));
            });
        }
    }
}