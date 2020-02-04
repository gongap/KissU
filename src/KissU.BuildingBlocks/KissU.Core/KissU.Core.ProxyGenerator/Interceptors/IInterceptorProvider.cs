using System;
using System.Collections.Generic;

namespace KissU.Core.ProxyGenerator.Interceptors
{
    /// <summary>
    /// Interface IInterceptorProvider
    /// </summary>
    public interface IInterceptorProvider
    {
        /// <summary>
        /// Gets the invocation.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <returns>IInvocation.</returns>
        IInvocation GetInvocation(object proxy, IDictionary<string, object> parameters, string serviceId,
            Type returnType);

        /// <summary>
        /// Gets the cache invocation.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <returns>IInvocation.</returns>
        IInvocation GetCacheInvocation(object proxy, IDictionary<string, object> parameters, string serviceId,
            Type returnType);
    }
}