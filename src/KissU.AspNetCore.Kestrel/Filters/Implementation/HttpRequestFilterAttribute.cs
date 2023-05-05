using System.Linq;
using System.Threading.Tasks;
using KissU.AspNetCore.Filters;
using KissU.AspNetCore.Internal;
using KissU.CPlatform;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.Dependency;
using KissUtil.Extensions;
using Microsoft.AspNetCore.Http;

namespace KissU.AspNetCore.Kestrel.Filters.Implementation
{
    /// <summary>
    /// HttpRequestFilterAttribute.
    /// Implements the <see cref="IActionFilter" />
    /// </summary>
    /// <seealso cref="IActionFilter" />
    public class HttpRequestFilterAttribute : IActionFilter
    {
        /// <summary>
        /// The HTTP405 endpoint display name
        /// </summary>
        internal const string Http405EndpointDisplayName = "405 HTTP Method Not Supported";
        private const string  _tenantKey = "__tenant";

        /// <summary>
        /// The HTTP405 endpoint status code
        /// </summary>
        internal const int Http405EndpointStatusCode = 405;
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceEntryLocate _serviceEntryLocate;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestFilterAttribute" /> class.
        /// </summary>
        public HttpRequestFilterAttribute(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceRouteProvider = ServiceLocator.GetService<IServiceRouteProvider>();
            _serviceEntryLocate = ServiceLocator.GetService<IServiceEntryLocate>();
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
        public async Task OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetHttpAttachment();
            var serviceEntry = _serviceEntryLocate.Locate(filterContext.Message);
            if (serviceEntry != null)
            {
                RestContext.GetContext().SetAttachment("HttpRoutePath", serviceEntry.RoutePath);
                var httpMethods = serviceEntry.Methods;
                if (httpMethods.Count() > 0 &&
                    !httpMethods.Any(p => string.Compare(p, filterContext.Context.Request.Method, true) == 0))
                {
                    filterContext.Result = new HttpResultMessage<object>
                    {
                        IsSucceed = false,
                        StatusCode = Http405EndpointStatusCode,
                        Message = Http405EndpointDisplayName
                    };
                }
            }
            else
            {
                RestContext.GetContext().SetAttachment("HttpRoutePath", filterContext.Message.RoutePath);
                var serviceRoute = await _serviceRouteProvider.GetRouteByPath(filterContext.Message.RoutePath);
                var httpMethods = serviceRoute.ServiceDescriptor.HttpMethod();
                if (!string.IsNullOrEmpty(httpMethods) && !httpMethods.Contains(filterContext.Context.Request.Method))
                {
                    filterContext.Result = new HttpResultMessage<object>
                    {
                        IsSucceed = false,
                        StatusCode = Http405EndpointStatusCode,
                        Message = Http405EndpointDisplayName
                    };
                }
            }
        }

        private void SetHttpAttachment()
        {
            var tenantIdOrName = _httpContextAccessor?.HttpContext?.Request?.Headers[_tenantKey];
            var remoteIpAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress;
            var remotePort = _httpContextAccessor?.HttpContext?.Connection?.RemotePort;
            var browserInfo = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"];
            var requestMethod = _httpContextAccessor?.HttpContext?.Request?.Method;
            var requestScheme = _httpContextAccessor?.HttpContext?.Request?.Scheme;
            var requestHost = _httpContextAccessor?.HttpContext?.Request?.Host.Host;
            var requestPath = _httpContextAccessor?.HttpContext?.Request?.Path;
            var queryString = _httpContextAccessor?.HttpContext?.Request?.QueryString;
            RestContext.GetContext().SetAttachment(_tenantKey, tenantIdOrName.SafeString());
            RestContext.GetContext().SetAttachment("RemoteIpAddress", string.Concat(new[] {remoteIpAddress.SafeString(), ":", remotePort.SafeString()}));
            RestContext.GetContext().SetAttachment("User-Agent", browserInfo.SafeString());
            RestContext.GetContext().SetAttachment("HttpRequestMethod", requestMethod.SafeString());
            RestContext.GetContext().SetAttachment("HttpRequestScheme", requestScheme.SafeString());
            RestContext.GetContext().SetAttachment("HttpRequestHost", requestHost.SafeString());
            RestContext.GetContext().SetAttachment("HttpRequestPath", requestPath.SafeString());
            RestContext.GetContext().SetAttachment("HttpQueryString", queryString.SafeString());
        }
    }
}
