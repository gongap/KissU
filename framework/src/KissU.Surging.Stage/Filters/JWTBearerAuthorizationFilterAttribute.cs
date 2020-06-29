using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using KissU.Dependency;
using KissU.Surging.ApiGateWay;
using KissU.Surging.ApiGateWay.OAuth;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Filters.Implementation;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.KestrelHttpServer.Filters.Implementation;
using KissU.Surging.KestrelHttpServer.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KissU.Surging.Stage.Filters
{
    /// <summary>
    /// JWTBearerAuthorizationFilterAttribute.
    /// Implements the <see cref="KissU.Surging.Stage.Filters.AuthorizationFilterAttribute" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Stage.Filters.AuthorizationFilterAttribute" />
    public class JWTBearerAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        private readonly IAuthorizationServerProvider _authorizationServerProvider;
        private readonly IBase64UrlEncoder _base64UrlEncoder;
        private readonly RSACryptoServiceProvider _cryptoServiceProvider;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IJwtValidator _jwtValidator;


        /// <summary>
        /// Initializes a new instance of the <see cref="JWTBearerAuthorizationFilterAttribute" /> class.
        /// </summary>
        public JWTBearerAuthorizationFilterAttribute()
        {
            _authorizationServerProvider = ServiceLocator.Current.Resolve<IAuthorizationServerProvider>();
            _base64UrlEncoder = new JwtBase64UrlEncoder();
            _jsonSerializer = new JsonNetSerializer();
            _dateTimeProvider = new UtcDateTimeProvider();
            _cryptoServiceProvider = new RSACryptoServiceProvider();
            _jwtValidator = new JwtValidator(_jsonSerializer, _dateTimeProvider);
        }

        /// <summary>
        /// Called when [authorization].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override async Task OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.Route != null && filterContext.Route.ServiceDescriptor.DisableNetwork())
                filterContext.Result = new HttpResultMessage<object>
                    {IsSucceed = false, StatusCode = (int) ServiceStatusCode.RequestError, Message = "Request error"};
            else
            {
                if (filterContext.Route != null && filterContext.Route.ServiceDescriptor.EnableAuthorization())
                {
                    if (filterContext.Route.ServiceDescriptor.AuthType() == AuthorizationType.JWTBearer.ToString())
                    {
                        var author = filterContext.Context.Request.Headers["Authorization"];
                        if (author.Count > 0)
                        {
                            var payload = ValidateClientAuthentication(author);
                            if (!payload.Any())
                            {
                                filterContext.Result = new HttpResultMessage<object>
                                {
                                    IsSucceed = false,
                                    StatusCode = (int) ServiceStatusCode.AuthorizationFailed,
                                    Message = "Invalid authentication credentials"
                                };
                            }
                            else
                            {
                                RestContext.GetContext().SetAttachment("payload", payload);
                            }
                        }
                        else
                        {
                            filterContext.Result = new HttpResultMessage<object>
                            {
                                IsSucceed = false,
                                StatusCode = (int) ServiceStatusCode.AuthorizationFailed,
                                Message = "Invalid authentication credentials"
                            };
                        }
                    }
                }
            }
        }

        #region  ValidateClientAuthentication

        /// <summary>
        /// 解码JWT
        /// </summary>
        /// <param name="jwtToken">jwt访问令牌</param>
        /// <returns></returns>
        private IDictionary<string, object> ValidateClientAuthentication(string jwtToken)
        {
            var result = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrWhiteSpace(jwtToken)) jwtToken = jwtToken.Replace("Bearer ", "");
                var jwtParts = new JwtParts(jwtToken);
                var header = Encoding.UTF8.GetString(_base64UrlEncoder.Decode(jwtParts.Header));
                var kid = JsonConvert.DeserializeObject<JObject>(header)["kid"].ToString();

                //请求获取ids4配置信息 获取jwks_uri
                var webClient = new WebClient();
                var authServer = AppConfig.Options.AuthServer;
                //知道文档地址
                var endpoint = $"{authServer.Authority}/.well-known/openid-configuration";

                var json = webClient.DownloadString(endpoint);

                var metadata = JsonConvert.DeserializeObject<JObject>(json);

                var jwksUri = metadata["jwks_uri"].ToString();

                //从jwks_uri获取keys
                var jwks = webClient.DownloadString(jwksUri);

                var jwkModels = JsonConvert.DeserializeObject<JwkModels>(jwks);

                //从keys中找到匹配kid的key
                var jwkModel = jwkModels.keys.Where(t => t.kid == kid).FirstOrDefault();

                if (jwkModel == null)
                {
                    result.Add("Bad Token", "No matching kid found");
                    return result;
                }

                //对称函数
                var hmac = new HMACSHA256();
                //jwt解密
                var decodeJwt = Rs256Decode(jwtToken, Convert.ToBase64String(hmac.Key), jwkModel.e, jwkModel.n);

                return decodeJwt;
            }
            catch (Exception e)
            {
                result.Add("Bad Token", "Wrong Token information:" + e.Message);
                return result;
            }
        }

        /// <summary>
        /// 解密令牌
        /// </summary>
        /// <param name="token">令牌</param>
        /// <param name="secret">密钥</param>
        /// <param name="exponent"></param>
        /// <param name="modulus"></param>
        /// <returns></returns>
        private IDictionary<string, object> Rs256Decode(string token, string secret, string exponent, string modulus)
        {
            var algorithmFactory = new RSAlgorithmFactory(() =>
            {
                _cryptoServiceProvider.ImportParameters(new RSAParameters
                {
                    Exponent = _base64UrlEncoder.Decode(exponent),
                    Modulus = _base64UrlEncoder.Decode(modulus)
                });
                var cspBlob = _cryptoServiceProvider.ExportCspBlob(true);
                var x509Certificate2 = new X509Certificate2(cspBlob);
                return x509Certificate2;
            });
            var jwtDecoder = new JwtDecoder(_jsonSerializer, _jwtValidator, _base64UrlEncoder, algorithmFactory);
            var jsonJwt = jwtDecoder.DecodeToObject(token, secret, false);
            return jsonJwt;
        }

        /// <summary>
        /// JwkModels.
        /// </summary>
        private class JwkModels
        {
            /// <summary>
            /// Gets or sets the keys.
            /// </summary>
            public List<JwkModel> keys { get; set; }
        }

        /// <summary>
        /// JwkModel.
        /// </summary>
        private class JwkModel
        {
            /// <summary>
            /// Gets or sets the kty.
            /// </summary>
            public string kty { get; set; }

            /// <summary>
            /// Gets or sets the use.
            /// </summary>
            public string use { get; set; }

            /// <summary>
            /// Gets or sets the kid.
            /// </summary>
            public string kid { get; set; }

            /// <summary>
            /// Gets or sets the e.
            /// </summary>
            public string e { get; set; }

            /// <summary>
            /// Gets or sets the n.
            /// </summary>
            public string n { get; set; }

            /// <summary>
            /// Gets or sets the alg.
            /// </summary>
            public string alg { get; set; }
        }

        #endregion
    }
}