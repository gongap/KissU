using Autofac;
using KissU.Core.AutoMapper.AutoMapper;
using KissU.Core.ServiceHosting.Internal;

namespace KissU.Core.AutoMapper
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