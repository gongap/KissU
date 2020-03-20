﻿using System;
using KissU.Surging.CPlatform.Messages;
using Microsoft.AspNetCore.Http;

namespace KissU.Surging.KestrelHttpServer.Filters.Implementation
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