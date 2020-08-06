using System;
using System.Collections.Generic;

namespace KissU.ProxyGenerator.Interceptors
{
    /// <summary>
    /// Interface ICacheInvocation
    /// Implements the <see cref="KissU.ProxyGenerator.Interceptors.IInvocation" />
    /// </summary>
    /// <seealso cref="KissU.ProxyGenerator.Interceptors.IInvocation" />
    public interface ICacheInvocation : IInvocation
    {
        /// <summary>
        /// Gets the cache key.
        /// </summary>
        string[] CacheKey { get; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        List<Attribute> Attributes { get; }
    }
}