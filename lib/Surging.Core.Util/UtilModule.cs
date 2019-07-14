using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Module;
using Surging.Core.KestrelHttpServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Util;
using Util.Logs.Extensions;


namespace Surging.Core.Util
{
    public class UtilModule : KestrelHttpModule
    {
        private ILogger<UtilModule> _logger;
        public override void Initialize(AppModuleContext context)
        {
            _logger = context.ServiceProvoider.GetInstances<ILogger<UtilModule>>();
        }

        public override void Initialize(ApplicationInitializationContext context)
        {

        }

        public override void RegisterBuilder(ConfigurationContext context)
        {
            context.Services.AddUtil();
        }
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {

        }
    }
}
