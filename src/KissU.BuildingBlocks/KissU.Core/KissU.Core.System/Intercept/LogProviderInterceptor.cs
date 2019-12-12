using System.Diagnostics;
using System.Threading.Tasks;
using KissU.Core.ProxyGenerator.Interceptors;

namespace KissU.Core.System.Intercept
{
    public class LogProviderInterceptor : IInterceptor
    {
        public async Task Intercept(IInvocation invocation)
        {
            var watch = Stopwatch.StartNew();
            await invocation.Proceed();
            var result = invocation.ReturnValue;
        }
    }
}
