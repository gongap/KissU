using System.Threading.Tasks;
using KissU.Surging.ApiGateWay;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.Kestrel.Filters;
using KissU.Surging.Kestrel.Internal;
using KissU.Surging.Stage.Internal;
using Microsoft.AspNetCore.Http;

namespace KissU.Surging.Stage.Filters
{
    /// <summary>
    /// IPFilterAttribute.
    /// Implements the <see cref="IActionFilter" />
    /// </summary>
    /// <seealso cref="IActionFilter" />
    public class IPFilterAttribute : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIPChecker _ipChecker;

        /// <summary>
        /// Initializes a new instance of the <see cref="IPFilterAttribute" /> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="ipChecker">The ip checker.</param>
        public IPFilterAttribute(IHttpContextAccessor httpContextAccessor, IIPChecker ipChecker)
        {
            _httpContextAccessor = httpContextAccessor;
            _ipChecker = ipChecker;
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
        public Task OnActionExecuting(ActionExecutingContext filterContext)
        {
            var address = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            RestContext.GetContext().SetAttachment("RemoteIpAddress", address.ToString());
            if (_ipChecker.IsBlackIp(address, filterContext.Message.RoutePath))
            {
                filterContext.Result = new HttpResultMessage<object>
                {
                    IsSucceed = false, StatusCode = (int) ServiceStatusCode.AuthorizationFailed,
                    Message = "Your IP address is not allowed"
                };
            }

            return Task.CompletedTask;
        }
    }
}