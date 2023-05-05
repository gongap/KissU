using System;
using System.Threading.Tasks;
using KissU.ApiGateWay.OAuth;
using KissU.AspNetCore.Filters;
using KissU.AspNetCore.Internal;
using KissU.CPlatform;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Messages;
using KissU.Dependency;
using KissUtil.Extensions;

namespace KissU.AspNetCore.Stage.Filters
{
    /// <summary>
    /// AuthorizationFilterAttribute.
    /// Implements the <see cref="IAuthorizationFilter" />
    /// </summary>
    /// <seealso cref="IAuthorizationFilter" />
    public class AuthorizationFilterAttribute : IAuthorizationFilter
    {
        private readonly IAuthorizationServerProvider _authorizationServerProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilterAttribute" /> class.
        /// </summary>
        public AuthorizationFilterAttribute()
        {
            _authorizationServerProvider = ServiceLocator.GetService<IAuthorizationServerProvider>();
        }

        /// <summary>
        /// Called when [authorization].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public virtual async Task OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var accessToken = GetAccessToken(filterContext.Context.Request.Headers["Authorization"]);
            RestContext.GetContext().SetAttachment("accessToken", accessToken);

            var isAuthenticated = filterContext.Context.User.Identity?.IsAuthenticated == true;
            if (isAuthenticated)
            {
                RestContext.GetContext().SetClaimsPrincipal("payload", filterContext.Context.User);
            }

            if (!isAuthenticated)
            {
                var enableAuthorization = filterContext.Route?.ServiceDescriptor.EnableAuthorization() ??  (!string.IsNullOrWhiteSpace(accessToken));
                var authType = filterContext.Route?.ServiceDescriptor.AuthType().SafeString();
                var serviceToken = filterContext.Route?.ServiceDescriptor.Token.SafeString();
                if (enableAuthorization || string.Compare(filterContext.Path.ToLower(), AppConfig.Options.ApiGetWay.RevocationEndpointPath, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (authType == AuthorizationType.AppSecret.ToString())
                    {
                        if (!string.IsNullOrWhiteSpace(serviceToken))
                        {
                            var appSecret = filterContext.Context.Request.Headers["AppSecret"].ToString();
                            var timestamp = filterContext.Context.Request.Headers["Timestamp"].ToString();
                            var isSuccess =
                                await _authorizationServerProvider.ValidateAppSecretAuthentication(serviceToken,
                                    appSecret, timestamp.ToLongOrNull());
                            if (!isSuccess)
                            {
                                filterContext.Result = new HttpResultMessage<object>
                                {
                                    IsSucceed = false,
                                    StatusCode = (int) StatusCode.Unauthorized,
                                    Message = $"身份验证凭据无效"
                                };
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(accessToken))
                        {
                            var validateAppSecretAuthentication = true;
                            if (authType == AuthorizationType.JwtSecret.ToString())
                            {
                                if (!string.IsNullOrWhiteSpace(serviceToken))
                                {
                                    var appSecret = filterContext.Context.Request.Headers["AppSecret"].ToString();
                                    var timestamp = filterContext.Context.Request.Headers["Timestamp"].ToString();
                                    validateAppSecretAuthentication =
                                        await _authorizationServerProvider.ValidateAppSecretAuthentication(serviceToken,
                                            appSecret, timestamp.ToLongOrNull());
                                }
                            }

                            if (validateAppSecretAuthentication)
                            {
                                var isSuccess =
                                    await _authorizationServerProvider.ValidateClientAuthentication(accessToken);
                                if (isSuccess)
                                {
                                    var payload = _authorizationServerProvider.GetPayloadString(accessToken);
                                    RestContext.GetContext().SetAttachment("payload", payload);
                                }
                                else
                                {
                                    filterContext.Result = new HttpResultMessage<object>
                                    {
                                        IsSucceed = false,
                                        StatusCode = (int) StatusCode.Unauthorized,
                                        Message = $"身份验证凭据无效"
                                    };
                                }
                            }
                            else
                            {
                                filterContext.Result = new HttpResultMessage<object>
                                {
                                    IsSucceed = false,
                                    StatusCode = (int) StatusCode.Unauthorized,
                                    Message = $"身份验证凭据无效"
                                };
                            }
                        }
                        else
                        {
                            filterContext.Result = new HttpResultMessage<object>
                            {
                                IsSucceed = false,
                                StatusCode = (int) StatusCode.Unauthorized,
                                Message = $"身份验证凭据无效"
                            };
                        }
                    }
                }
            }

            if (string.Compare(filterContext.Path.ToLower(), AppConfig.Options.ApiGetWay.TokenEndpointPath, StringComparison.OrdinalIgnoreCase) == 0)
            {
                filterContext.Context.Items.Add("path", AppConfig.Options.ApiGetWay.AuthorizationRoutePath);
            }

            if (string.Compare(filterContext.Path.ToLower(), AppConfig.Options.ApiGetWay.RevocationEndpointPath, StringComparison.OrdinalIgnoreCase) == 0)
            {
                filterContext.Context.Items.Add("path", AppConfig.Options.ApiGetWay.RevocationRoutePath);
            }
        }

        private string GetAccessToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var tokenArray = token.Split(' ');
                if (tokenArray.Length == 2)
                {
                    token = tokenArray[1];
                }
            }

            return token;
        }
    }
}