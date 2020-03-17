using KissU.Surging.CPlatform.Messages;

namespace KissU.Surging.CPlatform.Runtime.Client
{
    /// <summary>
    /// 远程调用上下文。
    /// </summary>
    public class RemoteInvokeContext
    {
        /// <summary>
        /// 远程调用消息。
        /// </summary>
        public RemoteInvokeMessage InvokeMessage { get; set; }

        /// <summary>
        /// 项目.
        /// </summary>
        public string Item { get; set; }
    }
}