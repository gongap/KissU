using System.Threading.Tasks;
using Autofac;
using KissU.Dependency;
using KissU.Surging.ApiGateWay;
using KissU.Surging.ApiGateWay.OAuth;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Filters.Implementation;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.KestrelHttpServer.Filters;
using KissU.Surging.KestrelHttpServer.Filters.Implementation;
using KissU.Surging.KestrelHttpServer.Internal;

namespace KissU.Surging.Stage.Filters
{
    /// <summary>
    /// AuthorizationFilterAttribute.
    /// Implements the <see cref="KissU.Surging.KestrelHttpServer.Filters.IAuthorizationFilter" />
    /// </summary>
    /// <seealso cref="KissU.Surging.KestrelHttpServer.Filters.IAuthorizationFilter" />
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

            if (string.Compare(filterContext.Path.ToLower(), gatewayAppConfig.TokenEndpointPath, true) == 0)
                filterContext.Context.Items.Add("path", gatewayAppConfig.AuthorizationRoutePath);
        }
    }
}