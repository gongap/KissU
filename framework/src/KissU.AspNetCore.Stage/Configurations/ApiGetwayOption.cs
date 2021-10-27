namespace KissU.AspNetCore.Stage.Configurations
{
    /// <summary>
    /// ApiGetwayOption.
    /// </summary>
    public class ApiGetwayOption
    {
        /// <summary>
        /// Gets or sets the cache mode.
        /// </summary>
        public string CacheMode { get; set; }

        /// <summary>
        /// Gets or sets the cache mode.
        /// </summary>
        public string CacheKey { get; set; }

        /// <summary>
        /// Gets or sets the authorization service key.
        /// </summary>
        public string AuthorizationServiceKey { get; set; }

        /// <summary>
        /// Gets or sets the authorization route path.
        /// </summary>
        public string AuthorizationRoutePath { get; set; }

        /// <summary>
        /// Gets or sets the access token expire time span.
        /// </summary>
        public int AccessTokenExpireTimeSpan { get; set; } = 30;

        /// <summary>
        /// Gets or sets the token endpoint path.
        /// </summary>
        public string TokenEndpointPath { get; set; }
    }
}