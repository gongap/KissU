using System;
using KissU.Modules.Application.Configurations.ObjectExtending;
using KissU.Modules.Application.MultiTenancy;

namespace KissU.Modules.Application.Configurations
{
    [Serializable]
    public class ApplicationConfigurationDto
    {
        public ApplicationLocalizationConfigurationDto Localization { get; set; }

        public ApplicationAuthConfigurationDto Auth { get; set; }

        public ApplicationSettingConfigurationDto Setting { get; set; }

        public CurrentUserDto CurrentUser { get; set; }

        public ApplicationFeatureConfigurationDto Features { get; set; }

        public MultiTenancyInfoDto MultiTenancy { get; set; }

        public CurrentTenantDto CurrentTenant { get; set; }

        public TimingDto Timing { get; set; }

        public ClockDto Clock { get; set; }

        public ObjectExtensionsDto ObjectExtensions { get; set; }
    }
}
