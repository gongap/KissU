using System;
using KissU.Core.ApiGateWay.Configurations;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.ApiGateWay
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public static class AppConfig
    {
        private static string _authorizationServiceKey;

        private static string _authorizationRoutePath;

        private static TimeSpan _accessTokenExpireTimeSpan = TimeSpan.FromMinutes(30);

        private static string _tokenEndpointPath = "oauth2/token";

        private static string _cacheMode = "MemoryCache";

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Gets or sets the authorization service key.
        /// </summary>
        public static string AuthorizationServiceKey
        {
            get
            {
                if (Configuration == null)
                    return _authorizationServiceKey;
                return Configuration["AuthorizationServiceKey"] ?? _authorizationServiceKey;
            }
            set => _authorizationServiceKey = value;
        }

        /// <summary>
        /// Gets or sets the authorization route path.
        /// </summary>
        public static string AuthorizationRoutePath
        {
            get
            {
                if (Configuration == null)
                    return _authorizationRoutePath;
                return Configuration["AuthorizationRoutePath"] ?? _authorizationRoutePath;
            }
            set => _authorizationRoutePath = value;
        }

        /// <summary>
        /// Gets or sets the access token expire time span.
        /// </summary>
        public static TimeSpan AccessTokenExpireTimeSpan
        {
            get
            {
                if (Configuration == null)
                    return _accessTokenExpireTimeSpan;
                int tokenExpireTime;
                if (Configuration["AccessTokenExpireTimeSpan"] != null &&
                    int.TryParse(Configuration["AccessTokenExpireTimeSpan"], out tokenExpireTime))
                {
                    _accessTokenExpireTimeSpan = TimeSpan.FromMinutes(tokenExpireTime);
                }

                return _accessTokenExpireTimeSpan;
            }
            set => _accessTokenExpireTimeSpan = value;
        }

        /// <summary>
        /// Gets or sets the token endpoint path.
        /// </summary>
        public static string TokenEndpointPath
        {
            get
            {
                if (Configuration == null)
                    return _tokenEndpointPath;
                return Configuration["TokenEndpointPath"] ?? _tokenEndpointPath;
            }
            set => _tokenEndpointPath = value;
        }

        /// <summary>
        /// Gets the register.
        /// </summary>
        public static Register Register
        {
            get
            {
                var result = new Register();
                var section = Configuration.GetSection("Register");
                if (section != null)
                    result = section.Get<Register>();
                return result;
            }
        }

        /// <summary>
        /// Gets the service part.
        /// </summary>
        public static ServicePart ServicePart
        {
            get
            {
                var result = new ServicePart();
                var section = Configuration.GetSection("ServicePart");
                if (section != null)
                    result = section.Get<ServicePart>();
                return result;
            }
        }

        /// <summary>
        /// Gets the policy.
        /// </summary>
        public static AccessPolicy Policy
        {
            get
            {
                var result = new AccessPolicy();
                var section = Configuration.GetSection("AccessPolicy");
                if (section.Exists())
                    result = section.Get<AccessPolicy>();
                return result;
            }
        }

        /// <summary>
        /// Gets or sets the cache mode.
        /// </summary>
        public static string CacheMode
        {
            get
            {
                if (Configuration == null)
                    return _cacheMode;

                return Configuration["CacheMode"] ?? _cacheMode;
            }
            set => _cacheMode = value;
        }
    }
}