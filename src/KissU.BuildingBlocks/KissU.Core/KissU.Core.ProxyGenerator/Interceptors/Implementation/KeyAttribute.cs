using System;

namespace KissU.Core.ProxyGenerator.Interceptors.Implementation
{
    /// <summary>
    /// CacheKeyAttribute 自定义特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public  abstract class KeyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyAttribute"/> class.
        /// </summary>
        /// <param name="sortIndex">Index of the sort.</param>
        protected KeyAttribute(int sortIndex)
        {
            SortIndex = sortIndex;
        }
        /// <summary>
        /// Gets or sets the index of the sort.
        /// </summary>
        public int SortIndex { get; set; }
    }
}
