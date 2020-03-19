using System.Reflection;
using System.Threading.Tasks;

namespace KissU.Util.Schedulers
{
    /// <summary>
    /// 调度器
    /// </summary>
    public interface IScheduler
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <returns>Task.</returns>
        Task StartAsync();

        /// <summary>
        /// 暂停
        /// </summary>
        /// <returns>Task.</returns>
        Task PauseAsync();

        /// <summary>
        /// 恢复
        /// </summary>
        /// <returns>Task.</returns>
        Task ResumeAsync();

        /// <summary>
        /// 停止
        /// </summary>
        /// <returns>Task.</returns>
        Task StopAsync();

        /// <summary>
        /// 添加作业
        /// </summary>
        /// <typeparam name="TJob">作业类型</typeparam>
        /// <returns>Task.</returns>
        Task AddJobAsync<TJob>() where TJob : IJob, new();

        /// <summary>
        /// 扫描并添加作业
        /// </summary>
        /// <param name="assemblies">程序集列表</param>
        /// <returns>Task.</returns>
        Task ScanJobsAsync(params Assembly[] assemblies);
    }
}