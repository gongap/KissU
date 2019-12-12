using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Utilities;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
   public class HttpRequestFilterAttribute : IActionFilter
    {
        internal const string Http405EndpointDisplayName = "405 HTTP Method Not Supported";
        internal const int Http405EndpointStatusCode = 405;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly IServiceEntryLocate _serviceEntryLocate;
        public HttpRequestFilterAttribute()
        {
            _serviceRouteProvider = ServiceLocator.Current.Resolve<IServiceRouteProvider>(); ;
            _serviceEntryLocate = ServiceLocator.Current.Resolve<IServiceEntryLocate>(); ;
        }
        public Task OnActionExecuted(ActionExecutedContext filterContext)
        {
            return Task.CompletedTask;
        }

        public  async Task OnActionExecuting(ActionExecutingContext filterContext)
        { 
            var serviceEntry= _serviceEntryLocate.Locate(filterContext.Message);
            if (serviceEntry != null)
            {
                var httpMethods = serviceEntry.Methods;
                if (httpMethods.Count()>0 && !httpMethods.Any(p => String.Compare(p, filterContext.Context.Request.Method, true) == 0))
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
