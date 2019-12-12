using System.Threading.Tasks;
using KissU.Core.ApiGateWay;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Implementation;
using KissU.Core.KestrelHttpServer.Filters;
using KissU.Core.KestrelHttpServer.Filters.Implementation;
using KissU.Core.Stage.Internal;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.Stage.Filters
{
    public class IPFilterAttribute : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIPChecker _ipChecker;
        public IPFilterAttribute(IHttpContextAccessor httpContextAccessor, IIPChecker ipChecker)
        {
            _httpContextAccessor = httpContextAccessor;
            _ipChecker = ipChecker;
        }
        public  Task OnActionExecuted(ActionExecutedContext filterContext)
        {
            return Task.CompletedTask;
        }

        public    Task OnActionExecuting(ActionExecutingContext filterContext)
        {
            var address = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            RpcContext.GetContext().SetAttachment("RemoteIpAddress", address.ToString());
            if (_ipChecker.IsBlackIp(address,filterContext.Message.RoutePath))
            {
                filterContext.Result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.AuthorizationFailed, Message = "Your IP address is not allowed" };
            }
             return Task.CompletedTask;
        }
    }
}
