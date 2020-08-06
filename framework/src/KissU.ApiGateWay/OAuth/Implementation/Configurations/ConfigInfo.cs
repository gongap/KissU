using System;

namespace KissU.ApiGateWay.OAuth.Implementation.Configurations
{
    /// <summary>
    /// ConfigInfo.
    /// </summary>
    public class ConfigInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigInfo" /> class.
        /// </summary>
        /// <param name="authorizationRoutePath">The authorization route path.</param>
        public ConfigInfo(string authorizationRoutePath) : this(authorizationRoutePath, null, TimeSpan.FromMinutes(30))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigInfo" /> class.
        /// </summary>
        /// <param name="authorizationRoutePath">The authorization route path.</param>
        /// <param name="authorizationServiceKey">The authorization service key.</param>
        /// <param name="accessTokenExpireTimeSpan">The access token expire time span.</param>
        public ConfigInfo(string authorizationRoutePath, string authorizationServiceKey,
            TimeSpan accessTokenExpireTimeSpan)
        {
            AuthorizationServiceKey = authorizationServiceKey;
            AuthorizationRoutePath = authorizationRoutePath;
            AccessTokenExpireTimeSpan = accessTokenExpireTimeSpan;
        }

        /// <summary>
        /// Gets or sets the authorization service key.
        /// </summary>
        public string AuthorizationServiceKey { get; set; }

        /// <summary>
        /// 授权服务路由地址
        /// </summary>
        public string AuthorizationRoutePath { get; set; }

        /// <summary>
        /// token 有效期
        /// </summary>
        public TimeSpan AccessTokenExpireTimeSpan { get; set; } = TimeSpan.FromMinutes(30);
    }
}