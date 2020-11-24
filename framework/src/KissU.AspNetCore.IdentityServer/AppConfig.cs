using KissU.AspNetCore.IdentityServer.Configurations;

namespace KissU.AspNetCore.IdentityServer
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        public static AuthServerOption Options { get; internal set; }
    }
}