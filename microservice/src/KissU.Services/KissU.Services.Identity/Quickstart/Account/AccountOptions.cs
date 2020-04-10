using System;

namespace KissU.Services.Identity.Quickstart.Account
{
    /// <summary>
    /// AccountOptions.
    /// </summary>
    public class AccountOptions
    {
        /// <summary>
        /// The allow local login
        /// </summary>
        public static bool AllowLocalLogin = true;
        /// <summary>
        /// The allow remember login
        /// </summary>
        public static bool AllowRememberLogin = true;
        /// <summary>
        /// The remember me login duration
        /// </summary>
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        /// <summary>
        /// The show logout prompt
        /// </summary>
        public static bool ShowLogoutPrompt = true;
        /// <summary>
        /// The automatic redirect after sign out
        /// </summary>
        public static bool AutomaticRedirectAfterSignOut = false;

        // specify the Windows authentication scheme being used
        /// <summary>
        /// The windows authentication scheme name
        /// </summary>
        public static readonly string WindowsAuthenticationSchemeName = Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme;
        // if user uses windows auth, should we load the groups from windows
        /// <summary>
        /// The include windows groups
        /// </summary>
        public static bool IncludeWindowsGroups = false;

        /// <summary>
        /// The invalid credentials error message
        /// </summary>
        public static string InvalidCredentialsErrorMessage = "Invalid username or password";
    }
}
