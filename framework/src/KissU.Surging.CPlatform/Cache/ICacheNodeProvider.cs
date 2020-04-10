using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Cache
{
    /// <summary>
    /// 缓存节点提供程序
    /// </summary>
    public interface ICacheNodeProvider
    {
        /// <summary>
        /// 获取服务缓存
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceCache&gt;.</returns>
        IEnumerable<ServiceCache> GetServiceCaches();
    }
}