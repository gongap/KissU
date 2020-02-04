﻿using System.Threading.Tasks;

namespace KissU.Core.ProxyGenerator.Interceptors
{
    /// <summary>
    /// Interface IInterceptor
    /// </summary>
    public interface IInterceptor
    {
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Task.</returns>
        Task Intercept(IInvocation invocation);
    }
}
