using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace KissU.Core.CPlatform.Engines.Implementation
{
    /// <summary>
    /// 服务引擎生命周期.
    /// Implements the <see cref="IServiceEngineLifetime" />
    /// </summary>
    /// <seealso cref="IServiceEngineLifetime" />
    public class ServiceEngineLifetime : IServiceEngineLifetime
    {
        private readonly CancellationTokenSource _startedSource = new CancellationTokenSource();
        private readonly CancellationTokenSource _stoppingSource = new CancellationTokenSource();
        private readonly CancellationTokenSource _stoppedSource = new CancellationTokenSource();
        private readonly ILogger<ServiceEngineLifetime> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceEngineLifetime"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ServiceEngineLifetime(ILogger<ServiceEngineLifetime> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the service engine started.
        /// </summary>
        public CancellationToken ServiceEngineStarted => _startedSource.Token;

        /// <summary>
        /// Gets the service engine stopping.
        /// </summary>
        public CancellationToken ServiceEngineStopping => _stoppingSource.Token;

        /// <summary>
        /// Gets the service engine stopped.
        /// </summary>
        public CancellationToken ServiceEngineStopped => _stoppedSource.Token;

        /// <summary>
        /// 通知已启动.
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
        /// 通知已停止.
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
        /// 停止应用.
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

        private void ExecuteHandlers(CancellationTokenSource cancel)
        {
            if (cancel.IsCancellationRequested)
            {
                return;
            }

            cancel.Cancel(throwOnFirstException: false);
        }
    }
}