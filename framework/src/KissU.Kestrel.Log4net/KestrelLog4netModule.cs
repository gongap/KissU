using KissU.Helpers;
using KissU.Modularity;
using KissU.CPlatform;
using KissU.Logging.Log4net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Kestrel.Log4net
{
    /// <summary>
    /// KestrelLog4netModule.
    /// Implements the <see cref="KestrelHttpModule" />
    /// </summary>
    /// <seealso cref="KestrelHttpModule" />
    public class KestrelLog4netModule : KestrelHttpModule
    {
        private string log4NetConfigFile = "${LogPath}|log4net.config";

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
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddLogging();
        }
    }
}