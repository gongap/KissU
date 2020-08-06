using System.Threading.Tasks;

namespace KissU.ServiceProxy.Interceptors
{
    /// <summary>
    /// CacheInterceptor.
    /// Implements the <see cref="IInterceptor" />
    /// </summary>
    /// <seealso cref="IInterceptor" />
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