using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.KestrelHttpServer;
using KissU.Core.Nlog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Kestrel.Nlog
{
    /// <summary>
    /// KestrelNLogModule.
    /// Implements the <see cref="KissU.Core.KestrelHttpServer.KestrelHttpModule" />
    /// </summary>
    /// <seealso cref="KissU.Core.KestrelHttpServer.KestrelHttpModule" />
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
            nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);

            NLog.LogManager.LoadConfiguration(nlogConfigFile);
            serviceProvider.GetService<ILoggerFactory>().AddProvider(new NLogProvider());
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
