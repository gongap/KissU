using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Modularity
{
    /// <summary>
    /// KestrelHttpModule
    /// </summary>
    public class KestrelHttpModule : AbstractModule
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="context">The builder.</param>
        public override void Configure(ApplicationInitializationContext context)
        {
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">The services.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}