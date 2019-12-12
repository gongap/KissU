using System.Threading.Tasks;

namespace KissU.Core.ProxyGenerator.Interceptors
{
    public interface IInterceptor
    {
        Task Intercept(IInvocation invocation);
    }
}
