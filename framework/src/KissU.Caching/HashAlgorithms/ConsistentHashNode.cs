using KissU.CPlatform.Cache;

namespace KissU.Caching.HashAlgorithms
{
    /// <summary>
    /// 哈希节点对象
    /// </summary>
    /// <remarks>
    ///     <para>创建：范亮</para>
    ///     <para>日期：2016/4/2</para>
    /// </remarks>
    public class ConsistentHashNode : CacheEndpoint
    {
        private string _maxSize = "50";

        private string _minSize = "1";

        /// <summary>
        /// 缓存目标类型
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public CacheTargetType Type { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public new string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public new string Port { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public string Password { get; set; }

        /// <summary>
        /// 数据库
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
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