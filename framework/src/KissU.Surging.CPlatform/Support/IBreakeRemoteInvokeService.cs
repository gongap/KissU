using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.Messages;

namespace KissU.Surging.CPlatform.Support
{
    /// <summary>
    /// 断开远程调用服务
    /// </summary>
    public interface IBreakeRemoteInvokeService
    {
        /// <summary>
        /// 异步调用.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>Task&lt;RemoteInvokeResultMessage&gt;.</returns>
        Task<RemoteInvokeResultMessage> InvokeAsync(IDictionary<string, object> parameters, string serviceId,
            string serviceKey, bool decodeJOject);
    }
}