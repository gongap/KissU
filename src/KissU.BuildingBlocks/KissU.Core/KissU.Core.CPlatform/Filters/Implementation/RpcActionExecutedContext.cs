using System;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Filters.Implementation
{
    /// <summary>
    /// Rpc操作执行上下文.
    /// </summary>
    public class RpcActionExecutedContext
    {
        /// <summary>
        /// 远程调用消息.
        /// </summary>
        public RemoteInvokeMessage InvokeMessage { get; set; }

        /// <summary>
        /// 异常.
        /// </summary>
        public Exception Exception { get; set; }
    }
}