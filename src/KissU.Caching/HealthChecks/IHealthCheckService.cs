using System.Threading.Tasks;
using KissU.CPlatform.Cache;

namespace KissU.Caching.HealthChecks
{
    /// <summary>
    /// Interface IHealthCheckService
    /// </summary>
    public interface IHealthCheckService
    {
        /// <summary>
        /// 监控一个地址。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>一个任务。</returns>
        void Monitor(CacheEndpoint address, string cacheId);

        /// <summary>
        /// 判断一个地址是否健康。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>健康返回true，否则返回false。</returns>
        ValueTask<bool> IsHealth(CacheEndpoint address, string cacheId);

        /// <summary>
        /// 标记一个地址为失败的。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>一个任务。</returns>
        Task MarkFailure(CacheEndpoint address, string cacheId);
    }
}