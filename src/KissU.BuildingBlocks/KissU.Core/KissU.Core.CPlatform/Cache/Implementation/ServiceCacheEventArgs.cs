namespace KissU.Core.CPlatform.Cache.Implementation
{
    /// <summary>
    /// 服务缓存事件参数
    /// </summary>
    public class ServiceCacheEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCacheEventArgs" /> class.
        /// </summary>
        /// <param name="cache">服务缓存</param>
        public ServiceCacheEventArgs(ServiceCache cache)
        {
            Cache = cache;
        }

        /// <summary>
        /// 服务缓存
        /// </summary>
        public ServiceCache Cache { get; private set; }
    }
}