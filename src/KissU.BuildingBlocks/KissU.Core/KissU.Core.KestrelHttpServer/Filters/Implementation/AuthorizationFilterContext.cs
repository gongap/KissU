using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Routing;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
   public class AuthorizationFilterContext
    {
        public ServiceRoute Route { get; internal set; }

        public string Path { get;  set; }

        public HttpResultMessage<object>  Result { get;  set; }

        public HttpContext Context { get; internal set; }
    }
}
