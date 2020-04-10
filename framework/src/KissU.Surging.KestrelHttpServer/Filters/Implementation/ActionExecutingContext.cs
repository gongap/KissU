using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Routing;
using Microsoft.AspNetCore.Http;

namespace KissU.Surging.KestrelHttpServer.Filters.Implementation
{
    /// <summary>
    /// ActionExecutingContext.
    /// </summary>
    public class ActionExecutingContext
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        public HttpRequestMessage Message { get; internal set; }

        /// <summary>
        /// Gets the route.
        /// </summary>
        public ServiceRoute Route { get; internal set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        public HttpResultMessage<object> Result { get; set; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public HttpContext Context { get; internal set; }
    }
}