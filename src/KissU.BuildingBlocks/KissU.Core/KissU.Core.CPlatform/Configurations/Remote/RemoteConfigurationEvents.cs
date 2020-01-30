using System;
using System.Collections.Generic;
using System.Net.Http;

namespace KissU.Core.CPlatform.Configurations.Remote
{
    /// <summary>
    /// 远程配置事件.
    /// </summary>
    public class RemoteConfigurationEvents
    {
        /// <summary>
        /// 发送请求操作.
        /// </summary>
        public Action<HttpRequestMessage> OnSendingRequest { get; set; } = msg => { };

        /// <summary>
        /// 解析数据操作.
        /// </summary>
        public Func<IDictionary<string, string>, IDictionary<string, string>> OnDataParsed { get; set; } = data => data;

        /// <summary>
        /// 发送请求.
        /// </summary>
        /// <param name="msg">The msg.</param>
        public virtual void SendingRequest(HttpRequestMessage msg) => OnSendingRequest(msg);

        /// <summary>
        /// 解析的数据.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        public virtual IDictionary<string, string> DataParsed(IDictionary<string, string> data) => OnDataParsed(data);
    }
}