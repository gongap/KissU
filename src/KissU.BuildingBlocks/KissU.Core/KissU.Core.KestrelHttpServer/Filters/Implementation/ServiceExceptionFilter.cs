using System;
using KissU.Core.CPlatform.Exceptions;
using KissU.Core.CPlatform.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
    public class ServiceExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(RpcActionExecutedContext context)
        {
            if (context.Exception is CPlatformCommunicationException)
                throw new Exception(context.Exception.Message, context.Exception);
        }
    }
}
