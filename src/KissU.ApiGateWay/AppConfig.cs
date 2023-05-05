using System;
using KissU.ApiGateWay.Configurations;
using Microsoft.Extensions.Configuration;

namespace KissU.ApiGateWay
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public static class AppConfig
    {
        private static string _authorizationServiceKey;

        private static string _authorizationRoutePath;

        private static string _revocationRoutePath;

        private static TimeSpan _accessTokenExpireTimeSpan = TimeSpan.FromMinutes(30);

        private static string _tokenEndpointPath = "api/connect/token";

        private static string _revocationEndpointPath = "api/connect/revocation";

        private static string _cacheMode = "MemoryCache";

        private static string _cacheKey = "userName";

        private static Register _register = new Register();

        private static ServicePart _servicePart = new ServicePart();

        private static AccessPolicy _accessPolicy = new AccessPolicy();

        /// <summary>
        /// Gets or sets the Configuration
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
        /// Gets or sets the authorization route path.
        /// </summary>
        public static string RevocationRoutePath
        {
            get
            {
                if (Configuration == null)
                    return _revocationRoutePath;
                return Configuration["RevocationRoutePath"] ?? _revocationRoutePath;
            }
            set => _revocationRoutePath = value;
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
        /// Gets or sets the revocation endpoint path.
        /// </summary>
        public static string RevocationEndpointPath
        {
            get
            {
                if (Configuration == null)
                    return _revocationEndpointPath;
                return Configuration["RevocationEndpointPath"] ?? _revocationEndpointPath;
            }
            set => _revocationEndpointPath = value;
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

        /// <summary>
        /// Gets or sets the cache key.
        /// </summary>
        public static string CacheKey
        {
            get
            {
                if (Configuration == null)
                    return _cacheKey;

                return Configuration["CacheKey"] ?? _cacheKey;
            }
            set => _cacheKey = value;
        }

        

        /// <summary>
        /// Gets the register.
        /// </summary>
        public static Register Register
        {
            get
            {
                if (Configuration == null)
                    return _register;

                return Configuration?.GetSection("Register")?.Get<Register>() ?? _register;
            }
            set => _register = value;
        }

        /// <summary>
        /// Gets the service part.
        /// </summary>
        public static ServicePart ServicePart
        {
            get
            {
                if (Configuration == null)
                    return _servicePart;

                return Configuration?.GetSection("ServicePart")?.Get<ServicePart>() ?? _servicePart;
            }
            set => _servicePart = value;
        }

        /// <summary>
        /// Gets the policy.
        /// </summary>
        public static AccessPolicy Policy
        {
            get
            {
                if (Configuration == null)
                    return _accessPolicy;

                return Configuration?.GetSection("AccessPolicy")?.Get<AccessPolicy>() ?? _accessPolicy;
            }
            set => _accessPolicy = value;
        }
    }
}