using KissU.Helpers;
using KissU.Modularity;
using KissU.Surging.CPlatform;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Surging.Log4net
{
    /// <summary>
    /// Log4netModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class Log4netModule : EnginePartModule
    {
        private string log4NetConfigFile = "${LogPath}|log4net.config";

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            var section = AppConfig.GetSection("Logging");
            log4NetConfigFile = EnvironmentHelper.GetEnvironmentVariable(log4NetConfigFile);
            serviceProvider.GetInstances<ILoggerFactory>().AddProvider(new Log4NetProvider(log4NetConfigFile));
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Configure(ApplicationInitializationContext context)
        {
            var serviceProvider = context.ServiceProvider;
            base.Configure(context);
            var section = AppConfig.GetSection("Logging");
            log4NetConfigFile = EnvironmentHelper.GetEnvironmentVariable(log4NetConfigFile);
            serviceProvider.GetService<ILoggerFactory>().AddProvider(new Log4NetProvider(log4NetConfigFile));
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">The services.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddLogging();
        }
    }
}