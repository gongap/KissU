using KissU.Helpers;
using KissU.Modularity;
using KissU.Surging.CPlatform;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Surging.Nlog
{
    /// <summary>
    /// NLogModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class NLogModule : EnginePartModule
    {
        private string nlogConfigFile = "${LogPath}|NLog.config";

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            var section = AppConfig.GetSection("Logging");
            nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
            LogManager.LoadConfiguration(nlogConfigFile);
            serviceProvider.GetInstances<ILoggerFactory>().AddProvider(new NLogProvider());
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
            nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
            LogManager.LoadConfiguration(nlogConfigFile);
            serviceProvider.GetService<ILoggerFactory>().AddProvider(new NLogProvider());
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">The services.</param>
        public override void ConfigureServices(ServiceConfigurationContext  context)
        {
            context.Services.AddLogging();
        }
    }
}