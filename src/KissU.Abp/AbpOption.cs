namespace KissU.Abp
{
    /// <summary>
    /// AbpOption.
    /// </summary>
    public class AbpOption
    {
        public bool IsEnabledRemoteAuditingStore { get; set; } = true;
        public bool IsEnabledRemoteFeatureChecker { get; set; } = true;
        public bool IsEnabledRemotePermissionChecker { get; set; } = true;
        public bool IsEnabledRemoteSettingProvider { get; set; } = true;
        public bool IsEnabledRemoteTenantStore { get; set; } = true;
        public string PermissionRoutePath { get; set; } = "api/internal/permission";
        public string FeatureRoutePath { get; set; } = "api/internal/feature";
        public string SettingRoutePath { get; set; } = "api/internal/setting";
        public string AuditingRoutePath { get; set; } = "api/internal/auditing";
        public string TenantRoutePath { get; set; } = "api/internal/tenant";
        public int AppConfigurationCacheExpiration = 300; //单位：秒
        public int TenantConfigurationCacheExpiration = 300; //单位：秒
        public string SettingConfigRoutePath { get; set; } = "api/setting/getsettingconfig";
        public string AuthConfigRoutePath { get; set; } = "api/permission/getauthconfig";
        public string FeatureConfigRoutePath { get; set; } = "api/feature/getfeaturesconfig";
        public string TimingConfigRoutePath { get; set; } = "api/configuration/gettimingconfig";
        public string ClockConfigRoutePath { get; set; } = "api/configuration/getclockconfig";
        public string MultiTenancyRoutePath { get; set; } = "api/configuration/getmultitenancy";
        public string CurrentTenantRoutePath { get; set; } = "api/configuration/getcurrenttenant";
        public string CurrentUserRoutePath { get; set; } = "api/configuration/getcurrentuser";
    }
}
