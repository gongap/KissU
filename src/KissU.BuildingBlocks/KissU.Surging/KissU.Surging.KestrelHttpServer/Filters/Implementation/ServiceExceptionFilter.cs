using System;
using KissU.Surging.CPlatform.Exceptions;
using KissU.Surging.CPlatform.Filters.Implementation;

namespace KissU.Surging.KestrelHttpServer.Filters.Implementation
{
    /// <summary>
    /// ServiceExceptionFilter.
    /// Implements the <see cref="KissU.Surging.CPlatform.Filters.Implementation.ExceptionFilterAttribute" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Filters.Implementation.ExceptionFilterAttribute" />
    public class ServiceExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="Exception"></exception>
        public override void OnException(RpcActionExecutedContext context)
        {
            if (context.Exception is CPlatformCommunicationException)
                throw new Exception(context.Exception.Message, context.Exception);
        }
    }
}