using System.Threading;

namespace KissU.Core.Hosting
{
    /// <summary>
    /// 应用生存期
    /// </summary>
    public interface IApplicationLifetime
    {
        /// <summary>
        /// 应用已启动
        /// </summary>
        CancellationToken ApplicationStarted { get; }

        /// <summary>
        /// 应用停止中
        /// </summary>
        CancellationToken ApplicationStopping { get; }

        /// <summary>
        /// 应用已停止
        /// </summary>
        CancellationToken ApplicationStopped { get; }

        /// <summary>
        /// 停止应用
        /// </summary>
        void StopApplication();

        /// <summary>
        /// 通知已停止
        /// </summary>
        void NotifyStopped();

        /// <summary>
        /// 通知已启动
        /// </summary>
        void NotifyStarted();
    }
}