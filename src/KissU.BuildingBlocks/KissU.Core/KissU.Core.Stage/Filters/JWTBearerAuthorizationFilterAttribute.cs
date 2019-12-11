using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Surging.Core.ApiGateWay;
using Surging.Core.ApiGateWay.OAuth;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Filters.Implementation;
using Surging.Core.CPlatform.Messages;
using Surging.Core.CPlatform.Transport.Implementation;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.KestrelHttpServer.Filters;
using Surging.Core.KestrelHttpServer.Filters.Implementation;

namespace Surging.Core.Stage.Filters
{
    public class JWTBearerAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        private readonly IAuthorizationServerProvider _authorizationServerProvider;
        private readonly IBase64UrlEncoder _base64UrlEncoder;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IJwtValidator _jwtValidator;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly RSACryptoServiceProvider _cryptoServiceProvider;


        public JWTBearerAuthorizationFilterAttribute()
        {
            _authorizationServerProvider = ServiceLocator.Current.Resolve<IAuthorizationServerProvider>();
            _base64UrlEncoder = new JwtBase64UrlEncoder();
            _jsonSerializer = new JsonNetSerializer();
            _dateTimeProvider = new UtcDateTimeProvider();
           _cryptoServiceProvider = new RSACryptoServiceProvider();
            _jwtValidator = new JwtValidator(_jsonSerializer, _dateTimeProvider);
        }
        
        public override async Task OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.Route != null && filterContext.Route.ServiceDescriptor.DisableNetwork())
                filterContext.Result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.RequestError, Message = "Request error" };
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
                                    StatusCode = (int)ServiceStatusCode.AuthorizationFailed,
                                    Message = "Invalid authentication credentials"
                                };
                            }
                            else
                            {
                                RpcContext.GetContext().SetAttachment("payload", payload);
                                filterContext.Context.User = GetPrincipal(payload);
                            }
                        }
                        else
                        {
                            filterContext.Result = new HttpResultMessage<object>
                            {
                                IsSucceed = false,
                                StatusCode = (int)ServiceStatusCode.AuthorizationFailed,
                                Message = "Invalid authentication credentials"
                            };
                        }
                    }
                }
            }

            base.OnAuthorization(filterContext);
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
                var gatewayAppConfig = AppConfig.Options.ApiGetWay;
                //知道文档地址
                var endpoint = $"{gatewayAppConfig.AuthorizationRoutePath}/.well-known/openid-configuration";

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
                    Modulus = _base64UrlEncoder.Decode(modulus),
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
        ///     此方法用解码payload，并返回秘钥的信息对象
        /// </summary>
        /// <param name="payload">载荷</param>
        /// <returns></returns>
        private ClaimsPrincipal GetPrincipal(IDictionary<string, object> payload)
        {
            // 这里就是验证成功后要做的逻辑
            var claims = new List<Claim>();
            foreach (var item in payload) claims.Add(new Claim(item.Key, item.Value.ToString()));
            // 根据验证token后获取的用户名重新在建一个声明
            claims.Add(new Claim(ClaimTypes.Name, claims.Where(x => x.Type == "name").Select(x => x.Value).FirstOrDefault()));
            claims.Add(new Claim("application_id", "E9138A35-A4FF-460E-AC55-B743D55B9691"));
            // 构造身份证
            var identity = new ClaimsIdentity(claims, "JWTBearer");
            // 将身份证放在ClaimsPrincipal里面，相当于把身份证给持有人
            var claimsPrincipal = new ClaimsPrincipal(identity);
            return claimsPrincipal;
        }

        private class JwkModels
        {
            public List<JwkModel> keys { get; set; }
        }
        private class JwkModel
        {
            public string kty { get; set; }
            public string use { get; set; }
            public string kid { get; set; }
            public string e { get; set; }
            public string n { get; set; }
            public string alg { get; set; }
        }
        #endregion
    }
}
