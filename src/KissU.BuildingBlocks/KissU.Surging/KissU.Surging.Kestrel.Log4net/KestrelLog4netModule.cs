using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Module;
using KissU.Surging.CPlatform.Utilities;
using KissU.Surging.KestrelHttpServer;
using KissU.Surging.Log4net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Kestrel.Log4net
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
        public override void Initialize(AppModuleContext context)
        {
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void RegisterBuilder(WebHostContext context)
        {
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ApplicationInitializationContext context)
        {
            var serviceProvider = context.Builder.ApplicationServices;
            base.Initialize(context);
            var section = AppConfig.GetSection("Logging");
            log4NetConfigFile = EnvironmentHelper.GetEnvironmentVariable(log4NetConfigFile);
            serviceProvider.GetService<ILoggerFactory>().AddProvider(new Log4NetProvider(log4NetConfigFile));
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void RegisterBuilder(ConfigurationContext context)
        {
            context.Services.AddLogging();
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
        }
    }
}