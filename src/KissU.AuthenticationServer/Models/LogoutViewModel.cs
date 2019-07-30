namespace GreatWall.Models {
    /// <summary>
    /// 登出参数
    /// </summary>
    public class LogoutViewModel {
        /// <summary>
        /// 登出标识
        /// </summary>
        public string LogoutId { get; set; }
        /// <summary>
        /// 是否显示登出提示
        /// </summary>
        public bool ShowLogoutPrompt { get; set; }
    }
}
