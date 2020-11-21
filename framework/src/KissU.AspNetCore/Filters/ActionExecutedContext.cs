using KissU.CPlatform.Messages;
using Microsoft.AspNetCore.Http;

namespace KissU.Kestrel.Filters
{
    /// <summary>
    /// ActionExecutedContext.
    /// </summary>
    public class ActionExecutedContext
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        public HttpRequestMessage Message { get; internal set; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public HttpContext Context { get; internal set; }
    }
}