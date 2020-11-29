using Autofac;
using KissU.CPlatform.Engines;
using KissU.Extensions;
using Microsoft.Extensions.Hosting;

namespace KissU.ServiceProxy
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
            return hostBuilder.ConfigureContainer(mapper =>
            {
                mapper.Resolve<IServiceEngineLifetime>().ServiceEngineStarted.Register(() =>
                {
                    mapper.Resolve<IServiceProxyFactory>();
                });
            });
        }
    }
}