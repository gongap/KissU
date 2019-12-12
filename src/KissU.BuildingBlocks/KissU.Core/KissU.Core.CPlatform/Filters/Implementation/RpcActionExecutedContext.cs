using System;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Filters.Implementation
{
    public class RpcActionExecutedContext
    {

        public RemoteInvokeMessage InvokeMessage { get; set; }
         
        public Exception Exception { get; set; }
    }
}
