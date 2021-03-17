using KissU.Modularity;

namespace KissU.AspNetCore
{
    /// <summary>
    /// KestrelHttpModule
    /// </summary>
    public class AspNetCoreModule : AbstractModule
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="context">The builder.</param>
        public virtual void Configure(ApplicationInitializationContext context)
        {
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="context">The services.</param>
        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void ConfigureWebHost(WebHostContext context)
        {
        }
    }
}