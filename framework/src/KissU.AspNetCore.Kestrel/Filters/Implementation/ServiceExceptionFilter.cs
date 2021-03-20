using System;
using KissU.CPlatform.Filters.Implementation;

namespace KissU.Kestrel.Http.Filters.Implementation
{
    /// <summary>
    /// ServiceExceptionFilter.
    /// Implements the <see cref="ExceptionFilterAttribute" />
    /// </summary>
    /// <seealso cref="ExceptionFilterAttribute" />
    public class ServiceExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="Exception"></exception>
        public override void OnException(RpcActionExecutedContext context)
        {
            throw context.Exception;
        }
    }
}