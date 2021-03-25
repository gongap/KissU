using System;
using System.Collections.Generic;
using System.Linq;
using KissU.Dependency;
using Microsoft.Extensions.Logging;

namespace KissU.Modularity
{
    /// <summary>
    /// 模块提供器.
    /// Implements the <see cref="IModuleProvider" />
    /// </summary>
    /// <seealso cref="IModuleProvider" />
    public class ModuleProvider : IModuleProvider
    {
        private readonly ILogger<ModuleProvider> _logger;
        private readonly CPlatformContainer _serviceProvoider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleProvider" /> class.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvoider">The service provoider.</param>
        public ModuleProvider(List<AbstractModule> modules, string[] virtualPaths, ILogger<ModuleProvider> logger,
            CPlatformContainer serviceProvoider)
        {
            Modules = modules;
            VirtualPaths = virtualPaths;
            _serviceProvoider = serviceProvoider;
            _logger = logger;
        }

        /// <summary>
        /// 模块集合.
        /// </summary>
        public List<AbstractModule> Modules { get; }

        /// <summary>
        /// 虚拟路径.
        /// </summary>
        public string[] VirtualPaths { get; }

        /// <summary>
        /// 初始化.
        /// </summary>
        public virtual void Initialize()
        {
            Type[] types =
            {
                typeof(SystemModule), typeof(BusinessModule), typeof(EnginePartModule), typeof(AbstractModule)
            };

            Modules.ForEach(p =>
            {

                if (p.Enable && types.All(x => x != p.GetType()))
                {
                    p.Initialize(new ModuleInitializationContext(Modules, VirtualPaths, _serviceProvoider));
                }

                if (types.Any(ty => ty == p.GetType().BaseType))
                {
                    p.Dispose();
                }
            });

            WriteLog(types);
        }

        /// <summary>
        /// 写日志.
        /// </summary>
        private void WriteLog(Type[] types)
        {
            if (!_logger.IsEnabled(LogLevel.Debug)) return;
            _logger.LogDebug($"Loaded KissU modules");
            Modules.ForEach(p =>
            {
                if (p.Enable && types.All(x => x != p.GetType()))
                {
                    _logger.LogDebug($"{p.TypeName}：{p.ModuleName}");
                }
            });
        }
    }
}