using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Cache
{
    /// <summary>
    /// 服务缓存描述
    /// </summary>
    public class ServiceCacheDescriptor
    {
        /// <summary>
        /// 服务地址描述符集合。
        /// </summary>
        public IEnumerable<CacheEndpointDescriptor> AddressDescriptors { get; set; }

        /// <summary>
        /// 缓存描述符。
        /// </summary>
        public CacheDescriptor CacheDescriptor { get; set; }
    }
}