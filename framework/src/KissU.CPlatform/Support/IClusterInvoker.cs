using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.CPlatform.Support
{
    /// <summary>
    /// 集群调用者
    /// </summary>
    public interface IClusterInvoker
    {
        /// <summary>
        /// 调用.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>Task.</returns>
        Task Invoke(IDictionary<string, object> parameters, string serviceId, string serviceKey, bool decodeJOject);

        /// <summary>
        /// 调用.
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="_serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> Invoke<T>(IDictionary<string, object> parameters, string serviceId, string _serviceKey,
            bool decodeJOject);
    }
}