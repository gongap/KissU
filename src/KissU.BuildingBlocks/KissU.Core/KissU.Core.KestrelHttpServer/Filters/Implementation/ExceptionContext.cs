using System;
using KissU.Core.CPlatform.Messages;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
   public class ExceptionContext
    {
        public string RoutePath { get; internal set; }

        public Exception Exception { get; internal set; }

        public HttpResultMessage<object> Result { get; set; }

        public HttpContext Context { get; internal set; }
    }
}
