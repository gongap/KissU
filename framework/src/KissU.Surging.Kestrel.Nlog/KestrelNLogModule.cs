using KissU.Helpers;
using KissU.Modularity;
using KissU.Module;
using KissU.Surging.CPlatform;
using KissU.Surging.KestrelHttpServer;
using KissU.Surging.Nlog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;

namespace KissU.Surging.Kestrel.Nlog
{
    /// <summary>
    /// KestrelNLogModule.
    /// Implements the <see cref="KestrelHttpModule" />
    /// </summary>
    /// <seealso cref="KestrelHttpModule" />
    public class KestrelNLogModule : KestrelHttpModule
    {
        private string nlogConfigFile = "${LogPath}|NLog.config";

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureWebHost(WebHostContext context)
        {
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
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddLogging();
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
        }
    }
}