using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.CPlatform.Runtime.Client
{
    /// <summary>
    /// 服务订阅管理器
    /// </summary>
    public interface IServiceSubscribeManager
    {
        /// <summary>
        /// 获取所有可用的服务订阅者信息。
        /// </summary>
        /// <returns>服务路由集合。</returns>
        Task<IEnumerable<ServiceSubscriber>> GetSubscribersAsync();

        /// <summary>
        /// 设置服务订阅者。
        /// </summary>
        /// <param name="subscibers">The subscibers.</param>
        /// <returns>一个任务。</returns>
        Task SetSubscribersAsync(IEnumerable<ServiceSubscriber> subscibers);

        /// <summary>
        /// 清空所有的服务订阅者。
        /// </summary>
        /// <returns>一个任务。</returns>
        Task ClearAsync();
    }
}