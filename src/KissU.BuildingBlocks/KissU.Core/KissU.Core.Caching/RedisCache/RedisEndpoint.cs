using KissU.Core.CPlatform.Cache;

namespace KissU.Core.Caching.RedisCache
{
    /// <summary>
    /// redis 终端
    /// </summary>
    /// <remarks>
    ///     <para>创建：范亮</para>
    ///     <para>日期：2016/4/2</para>
    /// </remarks>
    public class RedisEndpoint : CacheEndpoint
    {
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
        public new int Port { get; set; }

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