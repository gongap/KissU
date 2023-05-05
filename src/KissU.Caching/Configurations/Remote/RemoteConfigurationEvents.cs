using System;
using System.Collections.Generic;
using System.Net.Http;

namespace KissU.Caching.Configurations.Remote
{
    /// <summary>
    /// RemoteConfigurationEvents.
    /// </summary>
    public class RemoteConfigurationEvents
    {
        /// <summary>
        /// Gets or sets the on sending request.
        /// </summary>
        public Action<HttpRequestMessage> OnSendingRequest { get; set; } = msg => { };

        /// <summary>
        /// Gets or sets the on data parsed.
        /// </summary>
        public Func<IDictionary<string, string>, IDictionary<string, string>> OnDataParsed { get; set; } = data => data;

        /// <summary>
        /// Sendings the request.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void SendingRequest(HttpRequestMessage msg)
        {
            OnSendingRequest(msg);
        }

        /// <summary>
        /// Datas the parsed.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        public virtual IDictionary<string, string> DataParsed(IDictionary<string, string> data)
        {
            return OnDataParsed(data);
        }
    }
}