using System;
using KissU.CPlatform.Filters.Implementation;
using KissU.Exceptions;

namespace KissU.Kestrel.Http.Filters.Implementation
{
    /// <summary>
    /// ServiceExceptionFilter.
    /// Implements the <see cref="KissU.CPlatform.Filters.Implementation.ExceptionFilterAttribute" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Filters.Implementation.ExceptionFilterAttribute" />
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