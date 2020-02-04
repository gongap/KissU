using KissU.Core.CPlatform.Messages;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.KestrelHttpServer.Abstractions
{
    /// <summary>
    /// ActionContext.
    /// </summary>
    public class ActionContext
    {
        /// <summary>
        /// Gets or sets the HTTP context.
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public TransportMessage Message { get; set; }
    }
}