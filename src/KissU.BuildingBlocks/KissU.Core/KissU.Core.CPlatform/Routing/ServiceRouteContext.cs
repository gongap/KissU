using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Routing
{
    /// <summary>
    /// 服务路由上下文.
    /// </summary>
    public class ServiceRouteContext
    {
        /// <summary>
        /// Gets or sets 服务路由.
        /// </summary>
        public ServiceRoute Route { get; set; }

        /// <summary>
        /// 结果消息.
        /// </summary>
        public RemoteInvokeResultMessage ResultMessage { get; set; }

        /// <summary>
        /// 调用消息.
        /// </summary>
        public RemoteInvokeMessage InvokeMessage { get; set; }
    }
}