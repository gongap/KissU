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

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void RegisterBuilder(ConfigurationContext context)
        {
            //context.Services.AddSingleton<IConfigurationAccessor>(new DefaultConfigurationAccessor(context.Configuration));
            //var referenceAssemblies = GetAssemblies(context.VirtualPaths).Concat(GetAssemblies());
            //foreach (var moduleAssembly in referenceAssemblies)
            //{
            //    GetAbstractModules(moduleAssembly).ForEach(p =>
            //    {
            //        if (_logger.IsEnabled(LogLevel.Debug))
            //            _logger.LogDebug($"已初始化加载Abp模块，类型：{p.GetType().FullName}模块名：{p.GetType().Name}。");
            //        var application = VoloAbp.AbpApplicationFactory.Create(p.GetType(), context.Services);
            //        _providers.Add(application);
            //    });
            //}
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
