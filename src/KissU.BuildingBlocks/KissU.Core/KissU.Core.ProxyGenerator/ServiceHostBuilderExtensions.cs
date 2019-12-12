using Autofac;
using KissU.Core.CPlatform.Engines;
using KissU.Core.ServiceHosting.Internal;

namespace KissU.Core.ProxyGenerator
{
    public static class ServiceHostBuilderExtensions
    {
        public static IServiceHostBuilder UseProxy(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.MapServices(mapper =>
            {
                mapper.Resolve<IServiceEngineLifetime>().ServiceEngineStarted.Register(() =>
                 {
                     mapper.Resolve<IServiceProxyFactory>();
                 }); 
            });
        }
    }
}
