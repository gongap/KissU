using System;
using KissU.Core.CPlatform.Exceptions;
using KissU.Core.CPlatform.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
    /// <summary>
    /// ServiceExceptionFilter.
    /// Implements the <see cref="KissU.Core.CPlatform.Filters.Implementation.ExceptionFilterAttribute" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Filters.Implementation.ExceptionFilterAttribute" />
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
