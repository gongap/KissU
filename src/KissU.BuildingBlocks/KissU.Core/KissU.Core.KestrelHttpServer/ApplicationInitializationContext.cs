using System.Collections.Generic;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.KestrelHttpServer
{
    public class ApplicationInitializationContext
    {
        public ApplicationInitializationContext(IApplicationBuilder builder,
    List<AbstractModule> modules,
    string[] virtualPaths,
   IConfigurationRoot configuration)
        {
            Builder = Check.NotNull(builder, nameof(builder));
            Modules = Check.NotNull(modules, nameof(modules));
            VirtualPaths = Check.NotNull(virtualPaths, nameof(virtualPaths));
            Configuration = Check.NotNull(configuration, nameof(configuration));
        }

        public IApplicationBuilder Builder { get; }

        public IConfigurationRoot Configuration { get; }

        public List<AbstractModule> Modules { get; }

        public string[] VirtualPaths { get; }
    }
}
