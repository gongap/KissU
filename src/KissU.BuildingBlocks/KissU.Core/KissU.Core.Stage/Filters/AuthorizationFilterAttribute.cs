using System.Threading.Tasks;
using Autofac;
using KissU.Core.ApiGateWay;
using KissU.Core.ApiGateWay.OAuth;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Filters.Implementation;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Implementation;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.KestrelHttpServer.Filters;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.Stage.Filters
{
    /// <summary>
    /// AuthorizationFilterAttribute.
    /// Implements the <see cref="KissU.Core.KestrelHttpServer.Filters.IAuthorizationFilter" />
    /// </summary>
    /// <seealso cref="KissU.Core.KestrelHttpServer.Filters.IAuthorizationFilter" />
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
                filterContext.Result = new HttpResultMessage<object>
                    {IsSucceed = false, StatusCode = (int) ServiceStatusCode.RequestError, Message = "Request error"};
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
                                RpcContext.GetContext().SetAttachment("payload", payload);
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

            if (string.Compare(filterContext.Path.ToLower(), gatewayAppConfig.TokenEndpointPath, true) == 0)
                filterContext.Context.Items.Add("path", gatewayAppConfig.AuthorizationRoutePath);
        }
    }
}