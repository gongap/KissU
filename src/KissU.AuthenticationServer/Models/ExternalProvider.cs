namespace GreatWall.Models {
    /// <summary>
    /// 外部认证提供器
    /// </summary>
    public class ExternalProvider {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 认证方案
        /// </summary>
        public string AuthenticationScheme { get; set; }
    }
}