using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Messages
{
    /// <summary>
    /// 远程调用消息.
    /// </summary>
    public class RemoteInvokeMessage
    {
        /// <summary>
        /// 服务Id.
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 解码对象.
        /// </summary>
        public bool DecodeJObject { get; set; }

        /// <summary>
        /// 服务键.
        /// </summary>
        public string ServiceKey { get; set; }

        /// <summary>
        /// 服务参数.
        /// </summary>
        public IDictionary<string, object> Parameters { get; set; }

        /// <summary>
        /// 附件.
        /// </summary>
        public IDictionary<string, object> Attachments { get; set; }
    }
}