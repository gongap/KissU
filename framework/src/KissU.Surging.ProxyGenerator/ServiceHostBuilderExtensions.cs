using Autofac;
using KissU.Surging.CPlatform.Engines;
using KissU.Surging.ServiceHosting.Internal;

namespace KissU.Surging.ProxyGenerator
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