using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Runtime.Client.HealthChecks.Implementation;

namespace KissU.Core.CPlatform.Runtime.Client.HealthChecks
{
    /// <summary>
    /// 一个抽象的健康检查服务。
    /// </summary>
    public interface IHealthCheckService
    {
        /// <summary>
        /// 监控一个地址。
        /// </summary>
        /// <param name="address">地址模型。</param>
        void Monitor(AddressModel address);

        /// <summary>
        /// 判断一个地址是否健康。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <returns>健康返回true，否则返回false。</returns>
        ValueTask<bool> IsHealth(AddressModel address);

        /// <summary>
        /// 标记一个地址为失败的。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <returns>一个任务。</returns>
        Task MarkFailure(AddressModel address);

        /// <summary>
        /// Occurs when [removed].
        /// </summary>
        event EventHandler<HealthCheckEventArgs> Removed;

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        event EventHandler<HealthCheckEventArgs> Changed;
    }
}