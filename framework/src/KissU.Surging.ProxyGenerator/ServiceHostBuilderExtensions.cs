using Autofac;
using KissU.Extensions;
using KissU.Surging.CPlatform.Engines;
using Microsoft.Extensions.Hosting;

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
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseProxy(this IHostBuilder hostBuilder)
        {
            return hostBuilder.Configure(mapper =>
            {
                mapper.Resolve<IServiceEngineLifetime>().ServiceEngineStarted.Register(() =>
                {
                    mapper.Resolve<IServiceProxyFactory>();
                });
            });
        }
    }
}