using System.Linq;
using System.Threading.Tasks;
using Autofac;
using KissU.AspNetCore.Filters;
using KissU.CPlatform;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.Dependency;

namespace KissU.Kestrel.Http.Filters.Implementation
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

        /// <summary>
        /// The HTTP405 endpoint status code
        /// </summary>
        internal const int Http405EndpointStatusCode = 405;

        private readonly IServiceEntryLocate _serviceEntryLocate;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestFilterAttribute" /> class.
        /// </summary>
        public HttpRequestFilterAttribute()
        {
            _serviceRouteProvider = ServiceLocator.Current.Resolve<IServiceRouteProvider>();
            ;
            _serviceEntryLocate = ServiceLocator.Current.Resolve<IServiceEntryLocate>();
            ;
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
            var serviceEntry = _serviceEntryLocate.Locate(filterContext.Message);
            if (serviceEntry != null)
            {
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
    }
}