using KissU.Helpers;
using KissU.Modularity;
using KissU.Surging.CPlatform;
using Microsoft.Extensions.Logging;

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
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            log4NetConfigFile = EnvironmentHelper.GetEnvironmentVariable(log4NetConfigFile);
            serviceProvider.GetInstances<ILoggerFactory>().AddProvider(new Log4NetProvider(log4NetConfigFile));
        }
    }
}