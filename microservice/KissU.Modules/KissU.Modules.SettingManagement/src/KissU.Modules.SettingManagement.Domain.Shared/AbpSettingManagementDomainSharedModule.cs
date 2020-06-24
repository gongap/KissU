using KissU.Modules.SettingManagement.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.SettingManagement.Domain.Shared
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class AbpSettingManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSettingManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpSettingManagementResource>("en")
                    .AddVirtualJson("/Volo/Abp/SettingManagement/Localization/Resources/AbpSettingManagement");
            });
        }
    }
}
