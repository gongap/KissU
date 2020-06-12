using System.Collections.Generic;
using KissU.Dependency;
using KissU.Helpers;

namespace KissU.Module
{
    /// <summary>
    /// 应用模块上下文
    /// </summary>
    public class AppModuleContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppModuleContext" /> class.
        /// </summary>
        /// <param name="modules">模块集合</param>
        /// <param name="virtualPaths">虚拟目录集合</param>
        /// <param name="serviceProvoider">平台容器</param>
        public AppModuleContext(List<AbstractModule> modules, string[] virtualPaths, CPlatformContainer serviceProvoider)
        {
            ServiceProvoider = Check.NotNull(serviceProvoider, nameof(serviceProvoider));
            Modules = Check.NotNull(modules, nameof(modules));
            VirtualPaths = Check.NotNull(virtualPaths, nameof(virtualPaths));
        }

        /// <summary>
        /// 平台容器
        /// </summary>
        public CPlatformContainer ServiceProvoider { get; }

        /// <summary>
        /// 模块集合
        /// </summary>
        public List<AbstractModule> Modules { get; }

        /// <summary>
        /// 虚拟目录集合
        /// </summary>
        public string[] VirtualPaths { get; }
    }
}