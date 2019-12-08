using System;
using Surging.Core.CPlatform.Exceptions;
using Surging.Core.CPlatform.Filters.Implementation;

namespace KissU.Gateways.Host
{
    public class ServiceExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(RpcActionExecutedContext context)
        {
            if (context.Exception is CPlatformCommunicationException)
                throw new Exception(context.Exception.Message,context.Exception);
        }
    }
}
