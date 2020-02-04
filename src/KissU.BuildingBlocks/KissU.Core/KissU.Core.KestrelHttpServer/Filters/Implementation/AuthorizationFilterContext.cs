using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Routing;
using Microsoft.AspNetCore.Http;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
    /// <summary>
    /// AuthorizationFilterContext.
    /// </summary>
    public class AuthorizationFilterContext
    {
        /// <summary>
        /// Gets the route.
        /// </summary>
        public ServiceRoute Route { get; internal set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get;  set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        public HttpResultMessage<object>  Result { get;  set; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public HttpContext Context { get; internal set; }
    }
}
