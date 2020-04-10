namespace KissU.Surging.Caching
{
    /// <summary>
    /// Enum CacheTargetType
    /// </summary>
    public enum CacheTargetType
    {
        /// <summary>
        /// The redis
        /// </summary>
        Redis,

        /// <summary>
        /// The couch base
        /// </summary>
        CouchBase,

        /// <summary>
        /// The memcached
        /// </summary>
        Memcached,

        /// <summary>
        /// The memory cache
        /// </summary>
        MemoryCache
    }
}