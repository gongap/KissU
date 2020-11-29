using System;
using System.Threading.Tasks;
using Autofac;
using KissU.ApiGateWay;
using KissU.ApiGateWay.OAuth;
using KissU.AspNetCore.Filters;
using KissU.AspNetCore.Internal;
using KissU.CPlatform;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Messages;
using KissU.Dependency;

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
            _authorizationServerProvider = ServiceLocator.Current.Resolve<IAuthorizationServerProvider>();
        }

        /// <summary>
        /// Called when [authorization].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public virtual async Task OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var gatewayAppConfig = AppConfig.Options.ApiGetWay;
            if (filterContext.Route != null && filterContext.Route.ServiceDescriptor.DisableNetwork())
            {
                filterContext.Result = new HttpResultMessage<object> {IsSucceed = false, StatusCode = (int) ServiceStatusCode.RequestError, Message = "Request error"};
            }
            else
            {
                if (filterContext.Route != null && filterContext.Route.ServiceDescriptor.EnableAuthorization())
                {
                    if (filterContext.Route.ServiceDescriptor.AuthType() == AuthorizationType.JWT.ToString())
                    {
                        var author = filterContext.Context.Request.Headers["Authorization"];
                        if (author.Count > 0)
                        {
                            var isSuccess = await _authorizationServerProvider.ValidateClientAuthentication(author);
                            if (!isSuccess)
                            {
                                filterContext.Result = new HttpResultMessage<object>
                                {
                                    IsSucceed = false, StatusCode = (int) ServiceStatusCode.AuthorizationFailed,
                                    Message = "Invalid authentication credentials"
                                };
                            }
                            else
                            {
                                var payload = _authorizationServerProvider.GetPayloadString(author);
                                RestContext.GetContext().SetAttachment("payload", payload);
                            }
                        }
                        else
                            filterContext.Result = new HttpResultMessage<object>
                            {
                                IsSucceed = false, StatusCode = (int) ServiceStatusCode.AuthorizationFailed,
                                Message = "Invalid authentication credentials"
                            };
                    }
                }
            }

            if (string.Compare(filterContext.Path.ToLower(), gatewayAppConfig.TokenEndpointPath, StringComparison.OrdinalIgnoreCase) == 0)
            {
                filterContext.Context.Items.Add("path", gatewayAppConfig.AuthorizationRoutePath);
            }
        }
    }
}