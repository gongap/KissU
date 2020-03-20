using System;

namespace KissU.Surging.Caching.Intercept
{
    /// <summary>
    /// 设置判断缓存拦截方法的特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Interface)]
    public class InterceptMethodAttribute : Attribute
    {
        #region 字段

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化一个新的<c>InterceptMethodAttribute</c>类型。
        /// </summary>
        /// <param name="method">缓存方式。</param>
        public InterceptMethodAttribute(CachingMethod method)
        {
            Method = method;
        }

        /// <summary>
        /// 初始化一个新的<c>InterceptMethodAttribute</c>类型。
        /// </summary>
        /// <param name="method">缓存方式。</param>
        /// <param name="correspondingMethodNames">与当前缓存方式相关的方法名称。注：此参数仅在缓存方式为Remove时起作用。</param>
        public InterceptMethodAttribute(CachingMethod method, params string[] correspondingMethodNames)
            : this(method)
        {
            CorrespondingKeys = correspondingMethodNames;
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 有效时间（分钟）
        /// </summary>
        public int Time { get; set; } = 60;

        /// <summary>
        /// 采用什么进行缓存
        /// </summary>
        public CacheTargetType Mode { get; set; } = CacheTargetType.MemoryCache;

        ///// <summary>
        ///// 设置SectionType
        ///// </summary>
        /// <summary>
        /// Gets or sets the type of the cache section.
        /// </summary>
        public SectionType CacheSectionType { get; set; }

        /// <summary>
        /// Gets or sets the l2 key.
        /// </summary>
        public string L2Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable l2 cache].
        /// </summary>
        public bool EnableL2Cache { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 获取或设置缓存方式。
        /// </summary>
        public CachingMethod Method { get; set; }

        /// <summary>
        /// 获取或设置一个<see cref="Boolean" />值，该值表示当缓存方式为Put时，是否强制将值写入缓存中。
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// 获取或设置与当前缓存方式相关的方法名称。注：此参数仅在缓存方式为Remove时起作用。
        /// </summary>
        public string[] CorrespondingKeys { get; set; }

        #endregion
    }
}