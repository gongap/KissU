using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KissU.Core.Caching;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Cache;
using KissU.Core.CPlatform.Routing;
using KissU.Core.ProxyGenerator;
using Newtonsoft.Json;

namespace KissU.Core.ApiGateWay.OAuth.Implementation
{
    /// <summary>
    /// 授权服务提供者
    /// </summary>
    public class AuthorizationServerProvider : IAuthorizationServerProvider
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly CPlatformContainer _serviceProvider;
        private readonly IServiceProxyProvider _serviceProxyProvider;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationServerProvider" /> class.
        /// </summary>
        /// <param name="serviceProxyProvider">The service proxy provider.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public AuthorizationServerProvider(IServiceProxyProvider serviceProxyProvider
            , IServiceRouteProvider serviceRouteProvider
            , CPlatformContainer serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _serviceProxyProvider = serviceProxyProvider;
            _serviceRouteProvider = serviceRouteProvider;
            _cacheProvider = CacheContainer.GetService<ICacheProvider>(AppConfig.CacheMode);
        }

        /// <summary>
        /// Generates the token credential.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> GenerateTokenCredential(Dictionary<string, object> parameters)
        {
            string result = null;
            var payload = await _serviceProxyProvider.Invoke<object>(parameters, AppConfig.AuthorizationRoutePath,
                AppConfig.AuthorizationServiceKey);
            if (payload != null && !payload.Equals("null"))
            {
                var jwtHeader = JsonConvert.SerializeObject(new JWTSecureDataHeader
                    {TimeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")});
                var base64Payload = ConverBase64String(JsonConvert.SerializeObject(payload));
                var encodedString = $"{ConverBase64String(jwtHeader)}.{base64Payload}";
                var route = await _serviceRouteProvider.GetRouteByPath(AppConfig.AuthorizationRoutePath);
                var signature = HMACSHA256(encodedString, route.ServiceDescriptor.Token);
                result = $"{encodedString}.{signature}";
                _cacheProvider.Add(base64Payload, result, AppConfig.AccessTokenExpireTimeSpan);
            }

            return result;
        }

        /// <summary>
        /// Gets the payload string.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>System.String.</returns>
        public string GetPayloadString(string token)
        {
            string result = null;
            var jwtToken = token.Split('.');
            if (jwtToken.Length == 3)
            {
                result = Encoding.UTF8.GetString(Convert.FromBase64String(jwtToken[1]));
            }

            return result;
        }

        /// <summary>
        /// Validates the client authentication.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> ValidateClientAuthentication(string token)
        {
            var isSuccess = false;
            var jwtToken = token.Split('.');
            if (jwtToken.Length == 3)
            {
                isSuccess = await _cacheProvider.GetAsync<string>(jwtToken[1]) == token;
            }

            return isSuccess;
        }

        /// <summary>
        /// Refreshes the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> RefreshToken(string token)
        {
            var isSuccess = false;
            var jwtToken = token.Split('.');
            if (jwtToken.Length == 3)
            {
                var value = await _cacheProvider.GetAsync<string>(jwtToken[1]);
                if (!string.IsNullOrEmpty(value))
                {
                    _cacheProvider.Add(jwtToken[1], value, AppConfig.AccessTokenExpireTimeSpan);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }

        private string ConverBase64String(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        private string HMACSHA256(string message, string secret)
        {
            secret = secret ?? "";
            var keyByte = Encoding.UTF8.GetBytes(secret);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                var hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}