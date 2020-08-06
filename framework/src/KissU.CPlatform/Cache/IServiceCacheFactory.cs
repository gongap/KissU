using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.CPlatform.Cache
{
    /// <summary>
    /// 服务缓存工厂
    /// </summary>
    public interface IServiceCacheFactory
    {
        /// <summary>
        /// 根据服务路由描述符创建服务路由。
        /// </summary>
        /// <param name="descriptors">服务路由描述符。</param>
        /// <returns>服务路由集合。</returns>
        Task<IEnumerable<ServiceCache>> CreateServiceCachesAsync(IEnumerable<ServiceCacheDescriptor> descriptors);
    }
}