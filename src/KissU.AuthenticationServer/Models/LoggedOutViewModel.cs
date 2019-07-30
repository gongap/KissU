namespace GreatWall.Models {
    /// <summary>
    /// 登出参数
    /// </summary>
    public class LoggedOutViewModel {
        /// <summary>
        /// 登出成功跳转地址
        /// </summary>
        public string PostLogoutRedirectUri { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 登出Iframe地址
        /// </summary>
        public string SignOutIframeUrl { get; set; }
        /// <summary>
        /// 登出后自动跳转
        /// </summary>
        public bool AutomaticRedirectAfterSignOut { get; set; }
        /// <summary>
        /// 登出标识
        /// </summary>
        public string LogoutId { get; set; }
        /// <summary>
        /// 是否触发外部登出
        /// </summary>
        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;
        /// <summary>
        /// 外部认证方案
        /// </summary>
        public string ExternalAuthenticationScheme { get; set; }
    }
}