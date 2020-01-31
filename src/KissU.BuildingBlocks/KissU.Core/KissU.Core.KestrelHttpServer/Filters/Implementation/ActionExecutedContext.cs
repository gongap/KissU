using KissU.Core.CPlatform.Messages;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
   public class ActionExecutedContext
    {
        public HttpRequestMessage Message { get; internal set; }
        public HttpContext Context { get; internal set; }
    }
}
