using KissU.Core.Module;
using KissU.Core.Utilities;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Module;
using KissU.Surging.CPlatform.Utilities;
using Microsoft.Extensions.Logging;
using NLog;

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
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
        }
    }
}