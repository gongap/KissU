using System;
using System.Collections.Generic;

namespace KissU.ServiceProxy.Interceptors
{
    /// <summary>
    /// Interface ICacheInvocation
    /// Implements the <see cref="IInvocation" />
    /// </summary>
    /// <seealso cref="IInvocation" />
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