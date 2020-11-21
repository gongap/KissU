using System;
using KissU.CPlatform.Messages;
using Microsoft.AspNetCore.Http;

namespace KissU.AspNetCore.Filters
{
    /// <summary>
    /// ExceptionContext.
    /// </summary>
    public class ExceptionContext
    {
        /// <summary>
        /// Gets the route path.
        /// </summary>
        public string RoutePath { get; internal set; }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; internal set; }

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