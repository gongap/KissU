using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Nlog
{
    public class NLogModule : EnginePartModule
    {
        private string nlogConfigFile = "${LogPath}|NLog.config";
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            var section = AppConfig.GetSection("Logging");
            nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
            NLog.LogManager.LoadConfiguration(nlogConfigFile);
            serviceProvider.GetInstances<ILoggerFactory>().AddProvider(new NLogProvider());
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
           
        }
    }
}
