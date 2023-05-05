using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.AspNetCore.Mvc.MultiTenancy;
using System;

namespace KissU.Abp.AppConfigurations
{
    [Serializable]
    public class AppConfigurationDto
    {
        public ApplicationAuthConfigurationDto Auth { get; set; }

        public ApplicationSettingConfigurationDto Setting { get; set; }

        public ApplicationFeatureConfigurationDto Features { get; set; }

        public MultiTenancyInfoDto MultiTenancy { get; set; }

        public TimingDto Timing { get; set; }

        public ClockDto Clock { get; set; }

        public CurrentUserDto CurrentUser { get; set; }

        public CurrentTenantDto CurrentTenant { get; set; }
    }
}
