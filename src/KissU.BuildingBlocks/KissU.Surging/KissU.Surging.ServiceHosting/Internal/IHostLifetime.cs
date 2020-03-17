using System.Threading;
using System.Threading.Tasks;

namespace KissU.Surging.ServiceHosting.Internal
{
    /// <summary>
    /// 主机生命周期
    /// </summary>
    public interface IHostLifetime
    {
        /// <summary>
        /// 等待启动
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        Task WaitForStartAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        Task StopAsync(CancellationToken cancellationToken);
    }
}