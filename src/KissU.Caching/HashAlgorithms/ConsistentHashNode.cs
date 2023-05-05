using KissU.CPlatform.Cache;
using KissU.ServiceProxy.Interceptors.Implementation.Metadatas;

namespace KissU.Caching.HashAlgorithms
{
    /// <summary>
    /// 哈希节点对象
    /// </summary>
    public class ConsistentHashNode : CacheEndpoint
    {
        private string _maxSize = "50";

        private string _minSize = "1";

        /// <summary>
        /// 缓存目标类型
        /// </summary>
        public CacheTargetType Type { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        public new string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public new string Port { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 数据库
        /// </summary>
        public string Db { get; set; }

        /// <summary>
        /// Gets or sets the maximum size.
        /// </summary>
        public string MaxSize
        {
            get => _maxSize;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _maxSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum size.
        /// </summary>
        public string MinSize
        {
            get => _minSize;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _minSize = value;
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(new[] {Host, ":", Port});
        }
    }
}