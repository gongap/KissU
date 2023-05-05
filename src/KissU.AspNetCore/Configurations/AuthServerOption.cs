namespace KissU.AspNetCore.Configurations
{
    /// <summary>
    /// AuthServerOption
    /// </summary>
    public class AuthServerOption
    {
        public string Authority { get; set; }

        public string ApiName { get; set; }

        public string ApiSecret { get; set; }

        public bool RequireHttpsMetadata { get; set; } = false;

        public bool EnableCaching { get; set; } = false;

        /// <summary>
        /// 单位分钟
        /// </summary>
        public int CacheDuration { get; set; } = 10;

        /// <summary>
        /// 单位分钟
        /// </summary>
        public int DiscoveryDocumentCacheCacheDuration { get; set; } = 60;
    }
}