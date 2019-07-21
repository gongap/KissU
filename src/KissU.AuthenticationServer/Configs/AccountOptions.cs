using System;

namespace GreatWall.Configs {
    /// <summary>
    /// 帐户配置
    /// </summary>
    public class AccountOptions {
        /// <summary>
        /// 允许本地登录
        /// </summary>
        public static bool AllowLocalLogin = true;
        /// <summary>
        /// 允许记住密码
        /// </summary>
        public static bool AllowRemember = true;
        /// <summary>
        /// 记住密码持续时间，默认值：30天
        /// </summary>
        public static TimeSpan RememberDuration = TimeSpan.FromDays( 30 );
        /// <summary>
        /// 显示登出提示
        /// </summary>
        public static bool ShowLogoutPrompt = true;
        /// <summary>
        /// 登出后自动跳转
        /// </summary>
        public static bool AutomaticRedirectAfterSignOut = true;
        /// <summary>
        /// Windows认证方案
        /// </summary>
        public static readonly string WindowsAuthenticationSchemeName = Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme;
        /// <summary>
        /// 包含Windows组
        /// </summary>
        public static bool IncludeWindowsGroups = false;
        /// <summary>
        /// 用户名或密码无效
        /// </summary>
        public static string InvalidCredentialsErrorMessage = "用户名或密码无效";
    }
}
