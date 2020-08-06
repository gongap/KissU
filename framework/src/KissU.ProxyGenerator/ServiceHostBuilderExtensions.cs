using Autofac;
using KissU.Extensions;
using KissU.CPlatform.Engines;
using Microsoft.Extensions.Hosting;

namespace KissU.ProxyGenerator
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
            return hostBuilder.UseServiceHostBuilder(mapper =>
            {
                mapper.Resolve<IServiceEngineLifetime>().ServiceEngineStarted.Register(() =>
                {
                    mapper.Resolve<IServiceProxyFactory>();
                });
            });
        }
    }
}