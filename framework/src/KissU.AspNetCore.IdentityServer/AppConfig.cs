using KissU.Kestrel.IdentityServer.Configurations;

namespace KissU.Kestrel.IdentityServer
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