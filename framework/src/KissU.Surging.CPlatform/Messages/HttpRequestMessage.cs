using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Messages
{
    /// <summary>
    /// Http请求消息.
    /// </summary>
    public class HttpRequestMessage
    {
        /// <summary>
        /// 路由路径.
        /// </summary>
        public string RoutePath { get; set; }

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