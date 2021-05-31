using KissU.CPlatform.Cache;

namespace KissU.Caching.RedisCache
{
    /// <summary>
    /// redis 终端
    /// </summary>
    public class RedisEndpoint : CacheEndpoint
    {
        /// <summary>
        /// 主机
        /// </summary>
        public new string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public new int Port { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 数据库
        /// </summary>
        public int DbIndex { get; set; }

        /// <summary>
        /// Gets or sets the maximum size.
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        /// Gets or sets the minimum size.
        /// </summary>
        public int MinSize { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(Host, ":", Port.ToString(), "::", DbIndex.ToString());
        }
    }
}