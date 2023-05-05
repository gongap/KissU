using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.ApiGateWay.OAuth;
using KissU.AspNetCore.Filters;
using KissU.CPlatform;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport.Implementation;
using KissU.Dependency;
using KissUtil.Extensions;
using Microsoft.AspNetCore.Http;

namespace KissU.AspNetCore.Stage.Filters
{
    /// <summary>
    /// ActionFilterAttribute.
    /// Implements the <see cref="IActionFilter" />
    /// </summary>
    /// <seealso cref="IActionFilter" />
    public class ActionFilterAttribute : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationServerProvider _authorizationServerProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionFilterAttribute" /> class.
        /// </summary>
        public ActionFilterAttribute(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorizationServerProvider = ServiceLocator.GetService<IAuthorizationServerProvider>();
        }

        /// <summary>
        /// Called when [action executed].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>Task.</returns>
        public Task OnActionExecuted(ActionExecutedContext filterContext)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>Task.</returns>
        public async Task OnActionExecuting(ActionExecutingContext filterContext)
        {
            var disableNetwork = filterContext.Route?.ServiceDescriptor.DisableNetwork()?? false;
            if (disableNetwork)
            {
                filterContext.Result = new HttpResultMessage<object>
                {
                    IsSucceed = false, StatusCode = (int) StatusCode.RequestError,
                    Message = "Disable network, Request error!"
                };

                return;
            }
            
            var tenant = filterContext.Context.Request.Headers["__tenant"];
            var gatewayAppConfig = AppConfig.Options.ApiGetWay;
            if (filterContext.Message.RoutePath == gatewayAppConfig.AuthorizationRoutePath)
            {
                SetRpcAttachment(tenant);
                var result = await _authorizationServerProvider.GenerateTokenCredential(new Dictionary<string, object>(filterContext.Message.Parameters));
                if (result != null)
                {
                    filterContext.Result = HttpResultMessage<object>.Create(true, result);
                    filterContext.Result.StatusCode = (int) StatusCode.Success;
                }
                else
                {
                    filterContext.Result = new HttpResultMessage<object>
                    {
                        IsSucceed = false,
                        StatusCode = (int) StatusCode.Unauthorized,
                        Message = "Generates the token credential failed!"
                    };
                }
            }
            else if (filterContext.Message.RoutePath == gatewayAppConfig.RevocationRoutePath)
            {
                var accessToken = filterContext.Context.Request.Headers["Authorization"];
                SetRpcAttachment(tenant, accessToken);
                await _authorizationServerProvider.Revocation(accessToken);
                filterContext.Result = HttpResultMessage<object>.Create(true, string.Empty);
                filterContext.Result.StatusCode = (int) StatusCode.Success;
            }
        }

        private void SetRpcAttachment(string tenant = null, string accessToken = null)
        {
            var remoteIpAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress;
            var remotePort = _httpContextAccessor?.HttpContext?.Connection?.RemotePort;
            var browserInfo = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"];
            var requestMethod = _httpContextAccessor?.HttpContext?.Request?.Method;
            var requestScheme = _httpContextAccessor?.HttpContext?.Request?.Scheme;
            var requestHost = _httpContextAccessor?.HttpContext?.Request?.Host.Host;
            var requestPath = _httpContextAccessor?.HttpContext?.Request?.Path;
            var queryString = _httpContextAccessor?.HttpContext?.Request?.QueryString;
            RpcContext.GetContext().SetAttachment("RemoteIpAddress", string.Concat(new[] {remoteIpAddress.SafeString(), ":", remotePort.SafeString()}));
            RpcContext.GetContext().SetAttachment("User-Agent", browserInfo.SafeString());
            RpcContext.GetContext().SetAttachment("HttpRequestMethod", requestMethod.SafeString());
            RpcContext.GetContext().SetAttachment("HttpRequestScheme", requestScheme.SafeString());
            RpcContext.GetContext().SetAttachment("HttpRequestHost", requestHost.SafeString());
            RpcContext.GetContext().SetAttachment("HttpRequestPath", requestPath.SafeString());
            RpcContext.GetContext().SetAttachment("HttpQueryString", queryString.SafeString());
            if (tenant != null)
            {
                RpcContext.GetContext().SetAttachment("__tenant", tenant);
            }
            if (accessToken != null)
            {
                RpcContext.GetContext().SetAttachment("payload", _authorizationServerProvider.GetPayloadString(accessToken));
            }
        }
    }
}
