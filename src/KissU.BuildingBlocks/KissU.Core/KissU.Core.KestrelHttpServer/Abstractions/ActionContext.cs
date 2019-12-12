using KissU.Core.CPlatform.Messages;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.KestrelHttpServer.Abstractions
{
    public  class ActionContext
    {
        public ActionContext()
        {

        }

        public HttpContext HttpContext { get; set; }

        public TransportMessage Message { get; set; }
         
    }
}
