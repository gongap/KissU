using Microsoft.Extensions.Logging;
using Surging.Core.CPlatform.Module;
using Surging.Core.KestrelHttpServer;

namespace Surging.Core.Util
{
    public class UtilModule : KestrelHttpModule
    {
        private ILogger<UtilModule> _logger;
        public override void Initialize(AppModuleContext context)
        {
            _logger = context.ServiceProvoider.GetInstances<ILogger<UtilModule>>();
        }

        public override void RegisterBuilder(ConfigurationContext context)
        {
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            builder.ContainerBuilder.AddUtil();
        }
    }
}
