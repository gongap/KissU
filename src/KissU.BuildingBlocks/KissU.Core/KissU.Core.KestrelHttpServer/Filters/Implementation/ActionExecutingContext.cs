using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Routing;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
   public  class ActionExecutingContext
    {
        public HttpRequestMessage Message { get; internal set; }

        public ServiceRoute Route { get; internal set; }

        public HttpResultMessage<object> Result { get; set; }
          
        public HttpContext Context { get; internal set; }
    }
}
