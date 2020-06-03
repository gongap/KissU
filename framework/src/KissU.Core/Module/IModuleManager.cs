using System.IO;

namespace KissU.Module
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    public interface IModuleManager
    {
        /// <summary>
        /// 安装指定的模块软件包.
        /// </summary>
        /// <param name="modulePackageFileName">Name of the module package file.</param>
        /// <param name="textWriter">The text writer.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Install(string modulePackageFileName, TextWriter textWriter);

        /// <summary>
        /// 启动指定的模块.
        /// </summary>
        /// <param name="module">The module.</param>
        void Start(AssemblyEntry module);

        /// <summary>
        /// 停止指定的模块.
        /// </summary>
        /// <param name="module">The module.</param>
        void Stop(AssemblyEntry module);

        /// <summary>
        /// 卸载指定的模块.
        /// </summary>
        /// <param name="module">The module.</param>
        void Uninstall(AssemblyEntry module);

        /// <summary>
        /// 删除指定的模块.
        /// </summary>
        /// <param name="module">The module.</param>
        void Delete(AssemblyEntry module);

        /// <summary>
        /// 保存指定的模块.
        /// </summary>
        /// <param name="module">The module.</param>
        void Save(AssemblyEntry module);
    }
}