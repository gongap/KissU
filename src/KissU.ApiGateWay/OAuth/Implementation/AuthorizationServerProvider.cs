using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KissU.CPlatform.Routing;
using KissU.Serialization;
using KissU.ServiceProxy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KissU.CPlatform.Messages;
using System.Reflection;
using KissU.CPlatform.Runtime.Server;
using KissU.Dependency;
using KissUtil.Helpers;
using Microsoft.Extensions.Caching.Distributed;

namespace KissU.ApiGateWay.OAuth.Implementation
{
    /// <summary>
    /// 授权服务提供者
    /// </summary>
    public class AuthorizationServerProvider : IAuthorizationServerProvider
    {
        private readonly ISerializer<string> _jsonSerializer;
        private readonly IServiceProxyProvider _serviceProxyProvider;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly IServiceEntryLocate _serviceEntryLocate;
        private readonly IDistributedCache _cacheProvider;
        private readonly CPlatformContainer _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationServerProvider" /> class.
        /// </summary>
        /// <param name="serviceProxyProvider">The service proxy provider.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="serviceEntryLocate">serviceEntryLocate</param>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="jsonSerializer">The json serializer.</param>
        public AuthorizationServerProvider(IServiceProxyProvider serviceProxyProvider
            , IServiceRouteProvider serviceRouteProvider
            , IServiceEntryLocate serviceEntryLocate
            , IDistributedCache cacheProvider
            , CPlatformContainer serviceProvider
            , ISerializer<string> jsonSerializer)
        {
            _serviceProxyProvider = serviceProxyProvider;
            _serviceRouteProvider = serviceRouteProvider;
            _serviceEntryLocate = serviceEntryLocate;
            _cacheProvider = cacheProvider;
            _serviceProvider = serviceProvider;
            _jsonSerializer = jsonSerializer;
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
            var httpMessage = new HttpRequestMessage()
            {
                Parameters = parameters,
                RoutePath = AppConfig.AuthorizationRoutePath,
                ServiceKey = AppConfig.AuthorizationServiceKey
            };
            var serviceEntry = _serviceEntryLocate.Locate(httpMessage);
            var payload = default(object);
            if (serviceEntry != null && _serviceProvider.IsRegisteredWithKey(httpMessage.ServiceKey, serviceEntry.Type))
            {
                payload = await LocalExecuteAsync(serviceEntry, httpMessage);
            }
            else
            {
                payload = await RemoteExecuteAsync(httpMessage);
            }

            if (payload != null && !payload.Equals("null"))
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.Value is JObject jsonModel)
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
            var tokenArray = token.Split(' ');
            if (tokenArray.Length == 2)
            {
                token = tokenArray[1];
            }

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
        public Task<bool> ValidateClientAuthentication(string token)
        {
            var isSuccess = false;
            if (token != null)
            {
                var tokenArray = token.Split(' ');
                if (tokenArray.Length == 2)
                {
                    token = tokenArray[1];
                }

                var jwtToken = token.Split('.');
                if (jwtToken.Length == 3)
                {
                    var cacheKey = GeCacheKey(jwtToken[0]);
                    cacheKey = string.IsNullOrWhiteSpace(cacheKey) ? jwtToken[1] : cacheKey;
                    isSuccess = GetToken(cacheKey) == token;
                }
            }

            return Task.FromResult(isSuccess);;
        }

        /// <summary>
        /// Refreshes the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public Task Revocation(string token)
        {
            var httpMessage = new HttpRequestMessage()
            {
                Parameters = null,
                RoutePath = AppConfig.RevocationRoutePath,
                ServiceKey = AppConfig.AuthorizationServiceKey,
            };
            var serviceEntry = _serviceEntryLocate.Locate(httpMessage);
            if (serviceEntry != null && _serviceProvider.IsRegisteredWithKey(httpMessage.ServiceKey, serviceEntry.Type))
            {
                _ = LocalExecuteAsync(serviceEntry, httpMessage);
            }
            else
            {
                _ = RemoteExecuteAsync(httpMessage);
            }

            var tokenArray = token.Split(' ');
            if (tokenArray.Length == 2)
            {
                token = tokenArray[1];
            }

            var jwtToken = token.Split('.');
            if (jwtToken.Length == 3)
            {
                var cacheKey = GeCacheKey(jwtToken[0]);
                cacheKey = string.IsNullOrWhiteSpace(cacheKey) ? jwtToken[1] : cacheKey;
                _cacheProvider.Remove(cacheKey);
            }

            return  Task.CompletedTask;
        }

        public Task<bool> ValidateAppSecretAuthentication(string token,  string appSecret,  long? timestamp)
        {
            var tokenExpireTime = KissU.CPlatform.AppConfig.ServerOptions.TokenExpireTime;
            if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrWhiteSpace(appSecret))
            {
                {
                    var time = TimeHelper.UnixTimestampToDateTime(timestamp.GetValueOrDefault(), DateTime.UtcNow);
                    var seconds = Math.Abs((DateTime.UtcNow - time).TotalSeconds);
                    if (seconds <= tokenExpireTime && seconds >= 0)
                    {
                        if (GetMD5($"{token}{time:yyyy-MM-dd HH:mm:ss}") == appSecret)
                        {
                            return Task.FromResult(true);
                        }
                    }
                }
            }
            
            return Task.FromResult(false);
        }

        private string GetMD5(string encypStr)
        {
            try
            {
                var md5 = MD5.Create();
                var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(encypStr));
                var sb = new StringBuilder();
                foreach (var b in bs)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString().ToLower();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                return null;
            }
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
                var jwtHeader =
                    _jsonSerializer.Deserialize<string, JWTSecureDataHeader>(
                        Encoding.UTF8.GetString(Convert.FromBase64String(jwtHeaderString)));
                cacheKey = jwtHeader.CacheKey;
            }
            catch
            {
                // ignored
            }

            return cacheKey;
        }

        private void SaveToken(string cacheKey, string value)
        {
            _cacheProvider.Remove(cacheKey);
            _cacheProvider.SetStringAsync(cacheKey, value, new DistributedCacheEntryOptions{ AbsoluteExpirationRelativeToNow = AppConfig.AccessTokenExpireTimeSpan});
        }

        private string GetToken(string cacheKey)
        {
            return  _cacheProvider.GetString(cacheKey);
        }

        private async Task<object> RemoteExecuteAsync(HttpRequestMessage httpMessage)
        {
            var result = await _serviceProxyProvider.Invoke<Dictionary<string, List<string>>>(httpMessage.Parameters, httpMessage.RoutePath, httpMessage.ServiceKey);
            return result;
        }

        private async Task<object> LocalExecuteAsync(ServiceEntry entry, HttpRequestMessage httpMessage)
        {
            if (entry != null)
            {
                try
                {
                    var result = await entry.Func(httpMessage.ServiceKey, httpMessage.Parameters);
                    var task = result as Task;
                    if (task != null)
                    {
                        task.Wait();
                        var taskType = task.GetType().GetTypeInfo();
                        if (taskType.IsGenericType)
                        {
                            return taskType.GetProperty("Result").GetValue(task);
                        }
                    }
                }
                catch( Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }

            return null;
        }
    }
}
