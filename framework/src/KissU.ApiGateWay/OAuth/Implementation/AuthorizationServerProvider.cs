using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Caching;
using KissU.CPlatform.Cache;
using KissU.CPlatform.Routing;
using KissU.Serialization;
using KissU.ServiceProxy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KissU.ApiGateWay.OAuth.Implementation
{
    /// <summary>
    /// 授权服务提供者
    /// </summary>
    public class AuthorizationServerProvider : IAuthorizationServerProvider
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly CPlatformContainer _serviceProvider;
        private readonly ISerializer<string> _jsonSerializer;
        private readonly IServiceProxyProvider _serviceProxyProvider;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly ConcurrentDictionary<string, string> _tokens;

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
            _jsonSerializer = serviceProvider.GetInstances<ISerializer<string>>();
            _tokens = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        /// Generates the token credential.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> GenerateTokenCredential(Dictionary<string, object> parameters)
        {
            string result = null;
            var cacheKey = string.Empty;
            var payload = await _serviceProxyProvider.Invoke<object>(parameters, AppConfig.AuthorizationRoutePath,AppConfig.AuthorizationServiceKey);
            if (payload != null && !payload.Equals("null"))
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.Value is JObject  jsonModel)
                    {
                        if (jsonModel.TryGetValue(AppConfig.CacheKey, out var jtoken))
                        {
                            cacheKey = jtoken.ToString();
                        }
                    }
                }

                var jwtHeader = new JWTSecureDataHeader
                {
                    CacheKey = cacheKey,
                    TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                };
                var jwtHeaderStr = _jsonSerializer.Serialize(jwtHeader);
                var base64Payload = ConverBase64String(JsonConvert.SerializeObject(payload));
                var encodedString = $"{ConverBase64String(jwtHeaderStr)}.{base64Payload}";
                var route = await _serviceRouteProvider.GetRouteByPath(AppConfig.AuthorizationRoutePath);
                var signature = HMACSHA256(encodedString, route.ServiceDescriptor.Token);
                result = $"{encodedString}.{signature}";

                cacheKey = string.IsNullOrWhiteSpace(jwtHeader.CacheKey) ? base64Payload : jwtHeader.CacheKey;
                SaveToken(cacheKey, result);
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
            if (token == null)
            {
                return false;
            }

            var tokenArray = token.Split(' ');
            if (tokenArray.Length == 2)
            {
                token = tokenArray[1];
            }

            var isSuccess = false;
            var jwtToken = token.Split('.');
            if (jwtToken.Length == 3)
            {
                var cacheKey = GeCacheKey(jwtToken[0]);
                cacheKey = string.IsNullOrWhiteSpace(cacheKey) ? jwtToken[1] : cacheKey;
                isSuccess = await GetToken(cacheKey) == token;
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
                var cacheKey = GeCacheKey(jwtToken[0]);
                cacheKey = string.IsNullOrWhiteSpace(cacheKey) ? jwtToken[1] : cacheKey;
                var value = await GetToken(cacheKey);
                if (!string.IsNullOrEmpty(value))
                {
                    SaveToken(cacheKey, value);
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

        private string GeCacheKey(string jwtHeaderString)
        {
            var cacheKey = string.Empty;
            try
            {
                var jwtHeader = _jsonSerializer.Deserialize<string, JWTSecureDataHeader> (Encoding.UTF8.GetString(Convert.FromBase64String(jwtHeaderString)));
                cacheKey = jwtHeader.CacheKey;
            }
            catch
            {
                // ignored
            }

            return cacheKey;
        }

       private Task SaveToken(string cacheKey, string value)
        {
            _cacheProvider.Remove(cacheKey);
            _cacheProvider.Add(cacheKey, value, AppConfig.AccessTokenExpireTimeSpan);
            _tokens.AddOrUpdate(cacheKey, value, (o, n) => value);
            return Task.CompletedTask;
        }

       private async Task<string> GetToken(string cacheKey)
       {
           if (!_tokens.TryGetValue(cacheKey, out var token))
           {
               token = await _cacheProvider.GetAsync<string>(cacheKey);
               _tokens.TryAdd(cacheKey, token);
            }

           return token;
       }
    }
}