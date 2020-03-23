﻿using System;
using KissU.Surging.ProxyGenerator.Interceptors.Implementation;

namespace KissU.Surging.Caching.Intercept
{
    /// <summary>
    /// CacheKeyAttribute 自定义特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property)]
    public class CacheKeyAttribute : KeyAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheKeyAttribute" /> class.
        /// </summary>
        /// <param name="sortIndex">Index of the sort.</param>
        public CacheKeyAttribute(int sortIndex) : base(sortIndex)
        {
        }
    }
}