using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using KFNets.Microservices.IdentityServer.Services.Options;
using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain.Repositories;

namespace KFNets.Microservices.IdentityServer.Services
{
    /// <summary>
    /// 令牌清理
    /// </summary>
    public class TokenCleanup
    {
        private readonly ILogger<TokenCleanup> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly OperationalStoreOptions _options;

        private CancellationTokenSource _source;

        /// <summary>
        /// 清理间隔
        /// </summary>
        public TimeSpan CleanupInterval => TimeSpan.FromSeconds(_options.TokenCleanupInterval);

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serviceProvider">配置服务</param>
        /// <param name="logger">日志记录器</param>
        /// <param name="options">配置选项</param>
        public TokenCleanup(IServiceProvider serviceProvider, ILogger<TokenCleanup> logger, OperationalStoreOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            if (_options.TokenCleanupInterval < 1) throw new ArgumentException("Token cleanup interval must be at least 1 second");
            if (_options.TokenCleanupBatchSize < 1) throw new ArgumentException("Token cleanup batch size interval must be at least 1");

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        /// <summary>
        /// 启动作业
        /// </summary>
        public void Start()
        {
            Start(CancellationToken.None);
        }

        /// <summary>
        /// 启动作业
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        public void Start(CancellationToken cancellationToken)
        {
            if (_source != null) throw new InvalidOperationException("Already started. Call Stop first.");

            _logger.LogDebug("Starting token cleanup");

            _source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            Task.Factory.StartNew(() => StartInternal(_source.Token));
        }

        /// <summary>
        /// 停止作业
        /// </summary>
        public void Stop()
        {
            if (_source == null) throw new InvalidOperationException("Not started. Call Start first.");

            _logger.LogDebug("Stopping token cleanup");

            _source.Cancel();
            _source = null;
        }

        private async Task StartInternal(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("CancellationRequested. Exiting.");
                    break;
                }

                try
                {
                    await Task.Delay(CleanupInterval, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    _logger.LogDebug("TaskCanceledException. Exiting.");
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Task.Delay exception: {0}. Exiting.", ex.Message);
                    break;
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("CancellationRequested. Exiting.");
                    break;
                }

                ClearTokens();
            }
        }

        /// <summary>
        /// 清理令牌
        /// </summary>
        public void ClearTokens()
        {
            try
            {
                _logger.LogTrace("Querying for tokens to clear");

                var found = Int32.MaxValue;

                using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    using (var unitOfWork = serviceScope.ServiceProvider.GetService<IIdentityServerUnitOfWork>())
                    {
                        var persistedGrantRepository = serviceScope.ServiceProvider.GetService<IPersistedGrantRepository>();

                        while (found >= _options.TokenCleanupBatchSize)
                        {
                            var expired = persistedGrantRepository.FindAll(x => x.Expiration < DateTime.UtcNow)
                                .OrderBy(x => x.Id)
                                .Take(_options.TokenCleanupBatchSize)
                                .ToArray();

                            found = expired.Length;
                            _logger.LogInformation("Clearing {tokenCount} tokens", found);

                            if (found > 0)
                            {
                                persistedGrantRepository.Remove(expired);
                                try
                                {
                                    unitOfWork.Commit();
                                }
                                catch (DbUpdateConcurrencyException ex)
                                {
                                    // we get this if/when someone else already deleted the records
                                    // we want to essentially ignore this, and keep working
                                    _logger.LogDebug("Concurrency exception clearing tokens: {exception}", ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception clearing tokens: {exception}", ex.Message);
            }
        }
    }
}