using System.Threading.Tasks;

namespace KissU.ProxyGenerator.Interceptors
{
    /// <summary>
    /// CacheInterceptor.
    /// Implements the <see cref="KissU.ProxyGenerator.Interceptors.IInterceptor" />
    /// </summary>
    /// <seealso cref="KissU.ProxyGenerator.Interceptors.IInterceptor" />
    public abstract class CacheInterceptor : IInterceptor
    {
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public async Task Intercept(IInvocation invocation)
        {
            await Intercept(invocation as ICacheInvocation);
        }

        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Task.</returns>
        public abstract Task Intercept(ICacheInvocation invocation);
    }
}