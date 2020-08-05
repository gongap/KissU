using System.Threading.Tasks;
using KissU.Surging.ApiGateWay;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Filters.Implementation;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.Kestrel.Filters;
using KissU.Surging.Kestrel.Internal;

namespace KissU.Surging.Kestrel.IdentityServer.Filters
{
    /// <summary>
    /// JWTBearerAuthorizationFilterAttribute.
    /// Implements the <see cref="Surging.Stage.Filters.AuthorizationFilterAttribute" />
    /// </summary>
    /// <seealso cref="Surging.Stage.Filters.AuthorizationFilterAttribute" />
    public class JWTBearerAuthorizationFilterAttribute : IAuthorizationFilter
    {
        /// <summary>
        /// Called when [authorization].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public async Task OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.Route != null && filterContext.Route.ServiceDescriptor.DisableNetwork())
            {
                filterContext.Result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.RequestError, Message = "Request error" };
            }
            else
            {
                if (filterContext.Route != null && filterContext.Route.ServiceDescriptor.EnableAuthorization())
                {
                    if (filterContext.Route.ServiceDescriptor.AuthType() == AuthorizationType.JWTBearer.ToString())
                    {
                        if (filterContext.Context.User.Identity?.IsAuthenticated == true)
                        {
                            RestContext.GetContext().SetClaimsPrincipal("payload", filterContext.Context.User);
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
        }
    }
}