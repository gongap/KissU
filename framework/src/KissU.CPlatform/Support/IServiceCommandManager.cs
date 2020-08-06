using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.CPlatform.Support.Implementation;

namespace KissU.CPlatform.Support
{
    /// <summary>
    /// 服务命令管理器
    /// </summary>
    public interface IServiceCommandManager
    {
        /// <summary>
        /// 服务命令被创建。
        /// </summary>
        event EventHandler<ServiceCommandEventArgs> Created;

        /// <summary>
        /// 服务命令被删除。
        /// </summary>
        event EventHandler<ServiceCommandEventArgs> Removed;

        /// <summary>
        /// 服务命令被修改。
        /// </summary>
        event EventHandler<ServiceCommandChangedEventArgs> Changed;

        /// <summary>
        /// 获取所有可用的服务命令信息。
        /// </summary>
        /// <returns>服务路由集合。</returns>
        Task<IEnumerable<ServiceCommandDescriptor>> GetServiceCommandsAsync();

        /// <summary>
        /// 设置服务命令。
        /// </summary>
        /// <param name="commands">服务命令集合。</param>
        /// <returns>一个任务。</returns>
        Task SetServiceCommandsAsync(IEnumerable<ServiceCommandDescriptor> commands);

        /// <summary>
        /// 设置服务命令.
        /// </summary>
        /// <returns>Task.</returns>
        Task SetServiceCommandsAsync();

        /// <summary>
        /// 清空所有的服务命令。
        /// </summary>
        /// <returns>一个任务。</returns>
        Task ClearAsync();
    }
}