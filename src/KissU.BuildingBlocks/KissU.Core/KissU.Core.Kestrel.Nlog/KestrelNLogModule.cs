using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.KestrelHttpServer;
using KissU.Core.Nlog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Kestrel.Nlog
{
   public class KestrelNLogModule : KestrelHttpModule
    {
        private string nlogConfigFile = "${LogPath}|NLog.config";
        public override void Initialize(AppModuleContext context)
        {
  
        }

        public override void RegisterBuilder(WebHostContext context)
        { 
        }

        public override void Initialize(ApplicationInitializationContext context)
        {
            var serviceProvider = context.Builder.ApplicationServices;
            base.Initialize(context);
            var section = AppConfig.GetSection("Logging");
            nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);

            NLog.LogManager.LoadConfiguration(nlogConfigFile);
            serviceProvider.GetService<ILoggerFactory>().AddProvider(new NLogProvider());
        }

        public override void RegisterBuilder(ConfigurationContext context)
        {
             context.Services.AddLogging();
        }

        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
           
        }
    }
}
