using Autofac;
using KissU.Core.AutoMapper.AutoMapper;
using KissU.Core.ServiceHosting.Internal;

namespace KissU.Core.AutoMapper
{
    public static class ServiceHostBuilderExtensions
    {
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
