using System.Threading;

namespace KissU.Core.CPlatform.Engines
{
    /// <summary>
    /// 服务引擎生命周期
    /// </summary>
    public interface IServiceEngineLifetime
    {
        /// <summary>
        /// Gets the service engine started.
        /// </summary>
        CancellationToken ServiceEngineStarted { get; }

        /// <summary>
        /// Gets the service engine stopping.
        /// </summary>
        CancellationToken ServiceEngineStopping { get; }

        /// <summary>
        /// Gets the service engine stopped.
        /// </summary>
        CancellationToken ServiceEngineStopped { get; }

        /// <summary>
        /// 停止应用.
        /// </summary>
        void StopApplication();

        /// <summary>
        /// 通知已停止.
        /// </summary>
        void NotifyStopped();

        /// <summary>
        /// 通知已启动.
        /// </summary>
        void NotifyStarted();
    }
}