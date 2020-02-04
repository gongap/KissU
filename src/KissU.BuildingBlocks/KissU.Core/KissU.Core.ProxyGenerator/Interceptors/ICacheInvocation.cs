using System;
using System.Collections.Generic;

namespace KissU.Core.ProxyGenerator.Interceptors
{
    /// <summary>
    /// Interface ICacheInvocation
    /// Implements the <see cref="KissU.Core.ProxyGenerator.Interceptors.IInvocation" />
    /// </summary>
    /// <seealso cref="KissU.Core.ProxyGenerator.Interceptors.IInvocation" />
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