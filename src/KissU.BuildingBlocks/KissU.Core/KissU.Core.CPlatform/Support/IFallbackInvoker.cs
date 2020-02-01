using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.CPlatform.Support
{
    /// <summary>
    /// 后备调用者
    /// </summary>
    public interface IFallbackInvoker
    {
        /// <summary>
        /// 调用.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="_serviceKey">The service key.</param>
        /// <returns>Task.</returns>
        Task Invoke(IDictionary<string, object> parameters, string serviceId, string _serviceKey);

        /// <summary>
        /// 调用.
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="_serviceKey">The service key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> Invoke<T>(IDictionary<string, object> parameters, string serviceId, string _serviceKey);
    }
}
