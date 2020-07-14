using KissU.Modules.SettingManagement.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.SettingManagement.Domain.Shared
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class AbpSettingManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSettingManagementDomainSharedModule>("KissU.Modules.SettingManagement.Domain.Shared");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpSettingManagementResource>("en")
                    .AddVirtualJson("/Localization/Resources/AbpSettingManagement");
            });
        }
    }
}
