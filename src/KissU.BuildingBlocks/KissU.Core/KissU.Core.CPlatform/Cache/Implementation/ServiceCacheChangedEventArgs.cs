namespace KissU.Core.CPlatform.Cache.Implementation
{
    /// <summary>
    /// 服务缓存已更改事件参数.
    /// Implements the <see cref="KissU.Core.CPlatform.Cache.Implementation.ServiceCacheEventArgs" />
    /// </summary>
    public class ServiceCacheChangedEventArgs : ServiceCacheEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCacheChangedEventArgs" /> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="oldCache">The old cache.</param>
        public ServiceCacheChangedEventArgs(ServiceCache cache, ServiceCache oldCache)
            : base(cache)
        {
            OldCache = oldCache;
        }

        /// <summary>
        /// Gets or sets the old cache.
        /// </summary>
        public ServiceCache OldCache { get; set; }
    }
}