using KissU.Helpers;
using KissU.Modularity;
using KissU.CPlatform;
using KissU.Logging.Nlog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;

namespace KissU.Kestrel.Nlog
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
        public override void Configure(ApplicationInitializationContext context)
        {
            var serviceProvider = context.ServiceProvider;
            base.Configure(context);
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
    }
}