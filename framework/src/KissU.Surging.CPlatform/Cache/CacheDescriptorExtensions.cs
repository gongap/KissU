namespace KissU.Surging.CPlatform.Cache
{
    /// <summary>
    /// 服务描述符扩展方法。
    /// </summary>
    public static class CacheDescriptorExtensions
    {
        /// <summary>
        /// 获取默认失效时间 。
        /// </summary>
        /// <param name="descriptor">缓存描述符。</param>
        /// <returns>失效时间。</returns>
        public static int DefaultExpireTime(this CacheDescriptor descriptor)
        {
            return descriptor.GetMetadata("DefaultExpireTime", 60);
        }

        /// <summary>
        /// 设置默认失效时间。
        /// </summary>
        /// <param name="descriptor">缓存描述述符。</param>
        /// <param name="defaultExpireTime">The default expire time.</param>
        /// <returns>缓存描述符。</returns>
        public static CacheDescriptor DefaultExpireTime(this CacheDescriptor descriptor, int defaultExpireTime)
        {
            descriptor.Metadatas["DefaultExpireTime"] = defaultExpireTime;
            return descriptor;
        }

        /// <summary>
        /// 获取连接超时时间。
        /// </summary>
        /// <param name="descriptor">缓存描述述符。</param>
        /// <returns>缓存描述符。</returns>
        public static int ConnectTimeout(this CacheDescriptor descriptor)
        {
            return descriptor.GetMetadata("ConnectTimeout", 60);
        }

        /// <summary>
        /// 设置连接超时时间。
        /// </summary>
        /// <param name="descriptor">缓存描述述符。</param>
        /// <param name="connectTimeout">超时时间。</param>
        /// <returns>缓存描述符。</returns>
        public static CacheDescriptor ConnectTimeout(this CacheDescriptor descriptor, int connectTimeout)
        {
            descriptor.Metadatas["ConnectTimeout"] = connectTimeout;
            return descriptor;
        }
    }
}