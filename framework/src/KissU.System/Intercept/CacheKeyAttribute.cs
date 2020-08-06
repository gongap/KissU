using System;
using KissU.ProxyGenerator.Interceptors.Implementation;

namespace KissU.System.Intercept
{
    /// <summary>
    /// CacheKeyAttribute 自定义特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class CacheKeyAttribute : KeyAttribute
    {
        public CacheKeyAttribute(int sortIndex) : base(sortIndex)
        {
        }
    }
}
