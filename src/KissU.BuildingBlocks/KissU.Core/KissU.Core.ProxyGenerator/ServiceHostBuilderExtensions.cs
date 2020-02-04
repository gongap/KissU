using Autofac;
using KissU.Core.CPlatform.Engines;
using KissU.Core.ServiceHosting.Internal;

namespace KissU.Core.ProxyGenerator
{
    /// <summary>
    /// ServiceHostBuilderExtensions.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// Uses the proxy.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IServiceHostBuilder.</returns>
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
