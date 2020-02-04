using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace KissU.Core.CPlatform.Module
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
            Modules.ForEach(p =>
            {
                try
                {
                    Type[] types =
                    {
                        typeof(SystemModule), typeof(BusinessModule), typeof(EnginePartModule), typeof(AbstractModule),
                    };
                    if (p.Enable)
                    {
                        p.Initialize(new AppModuleContext(Modules, VirtualPaths, _serviceProvoider));
                    }

                    var type = p.GetType().BaseType;
                    if (types.Any(ty => ty == type))
                    {
                        p.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
            WriteLog();
        }

        /// <summary>
        /// 写日志.
        /// </summary>
        public void WriteLog()
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                Modules.ForEach(p =>
                {
                    if (p.Enable)
                    {
                        _logger.LogDebug($"已初始化加载模块，类型：{p.TypeName}模块名：{p.ModuleName}。");
                    }
                });
            }
        }
    }
}