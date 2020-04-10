using Autofac;
using KissU.Surging.AutoMapper.AutoMapper;
using KissU.Surging.ServiceHosting.Internal;

namespace KissU.Surging.AutoMapper
{
    /// <summary>
    /// ServiceHostBuilderExtensions.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// Uses the automatic mapper.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseAutoMapper(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.MapServices(mapper =>
            {
                var autoMapperBootstrap = mapper.Resolve<IAutoMapperBootstrap>();
                autoMapperBootstrap.Initialize();
            });
        }
    }
}