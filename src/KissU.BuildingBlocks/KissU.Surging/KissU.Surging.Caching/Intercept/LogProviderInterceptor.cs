using System.Diagnostics;
using System.Threading.Tasks;
using KissU.Surging.ProxyGenerator.Interceptors;

namespace KissU.Surging.Caching.Intercept
{
    /// <summary>
    /// LogProviderInterceptor.
    /// Implements the <see cref="KissU.Surging.ProxyGenerator.Interceptors.IInterceptor" />
    /// </summary>
    /// <seealso cref="KissU.Surging.ProxyGenerator.Interceptors.IInterceptor" />
    public class LogProviderInterceptor : IInterceptor
    {
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public async Task Intercept(IInvocation invocation)
        {
            var watch = Stopwatch.StartNew();
            await invocation.Proceed();
            var result = invocation.ReturnValue;
        }
    }
}