using KissU.Modularity;
using KissUtil.Helpers;
using Microsoft.Extensions.Logging;
using NLog;

namespace KissU.Logging.NLog
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
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
            LogManager.LoadConfiguration(nlogConfigFile);
            serviceProvider.GetInstances<ILoggerFactory>().AddProvider(new NLogProvider());

        }
    }
}
