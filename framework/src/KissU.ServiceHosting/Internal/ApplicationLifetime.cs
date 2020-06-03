using System;
using System.Threading;
using KissU.Core.Hosting;
using Microsoft.Extensions.Logging;

namespace KissU.ServiceHosting.Internal
{
    /// <summary>
    /// 应用生存期
    /// </summary>
    public class ApplicationLifetime : IApplicationLifetime
    {
        private readonly ILogger<ApplicationLifetime> _logger;
        private readonly CancellationTokenSource _startedSource = new CancellationTokenSource();
        private readonly CancellationTokenSource _stoppedSource = new CancellationTokenSource();
        private readonly CancellationTokenSource _stoppingSource = new CancellationTokenSource();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLifetime" /> class.
        /// 初始化
        /// </summary>
        /// <param name="logger">日志记录器</param>
        public ApplicationLifetime(ILogger<ApplicationLifetime> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 应用已启动
        /// </summary>
        public CancellationToken ApplicationStarted => _startedSource.Token;

        /// <summary>
        /// 应用停止中
        /// </summary>
        public CancellationToken ApplicationStopping => _stoppingSource.Token;

        /// <summary>
        /// 应用已停止
        /// </summary>
        public CancellationToken ApplicationStopped => _stoppedSource.Token;

        /// <summary>
        /// 通知已启动
        /// </summary>
        public void NotifyStarted()
        {
            try
            {
                ExecuteHandlers(_startedSource);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred starting the application", ex);
            }
        }

        /// <summary>
        /// 通知已停止
        /// </summary>
        public void NotifyStopped()
        {
            try
            {
                ExecuteHandlers(_stoppedSource);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred stopping the application", ex);
            }
        }

        /// <summary>
        /// 停止应用
        /// </summary>
        public void StopApplication()
        {
            lock (_stoppingSource)
            {
                try
                {
                    ExecuteHandlers(_stoppedSource);
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occurred stopping the application", ex);
                }
            }
        }

        /// <summary>
        /// 执行处理程序.
        /// </summary>
        /// <param name="cts">取消令牌源</param>
        private void ExecuteHandlers(CancellationTokenSource cts)
        {
            if (cts.IsCancellationRequested)
            {
                return;
            }

            cts.Cancel(false);
        }
    }
}