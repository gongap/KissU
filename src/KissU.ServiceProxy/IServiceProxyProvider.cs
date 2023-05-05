using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.ServiceProxy
{
    /// <summary>
    /// 代理服务接口
    /// </summary>
    public interface IServiceProxyProvider
    {
        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="routePath">The route path.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath, bool? decodeJOject = null);

        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="routePath">The route path.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath, string serviceKey, bool? decodeJOject = null);
    }
}