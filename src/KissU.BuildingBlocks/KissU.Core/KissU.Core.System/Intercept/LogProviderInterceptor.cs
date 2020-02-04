using System.Diagnostics;
using System.Threading.Tasks;
using KissU.Core.ProxyGenerator.Interceptors;

namespace KissU.Core.System.Intercept
{
    /// <summary>
    /// LogProviderInterceptor.
    /// Implements the <see cref="KissU.Core.ProxyGenerator.Interceptors.IInterceptor" />
    /// </summary>
    /// <seealso cref="KissU.Core.ProxyGenerator.Interceptors.IInterceptor" />
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
