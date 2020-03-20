using System.Collections.Generic;

namespace KissU.Core.Module
{
    /// <summary>
    /// 模块提供者
    /// </summary>
    public interface IModuleProvider
    {
        /// <summary>
        /// 模块集合.
        /// </summary>
        List<AbstractModule> Modules { get; }

        /// <summary>
        /// 虚拟路径.
        /// </summary>
        string[] VirtualPaths { get; }

        /// <summary>
        /// 初始化.
        /// </summary>
        void Initialize();
    }
}