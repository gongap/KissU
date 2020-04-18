using System;
using System.Threading;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Services;
using KissU.Modules.IdentityServer.Application.Services.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.IdentityServer.Service.Services
{
    /// <summary>
    /// 清除过期持久授权的帮助程序
    /// </summary>
    public class TokenCleanupHost : IHostedService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<TokenCleanupHost> _logger;
        /// <summary>
        /// The options
        /// </summary>
        private readonly OperationalStoreOptions _options;
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// The source
        /// </summary>
        private CancellationTokenSource _source;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="options">The options.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">serviceProvider</exception>
        /// <exception cref="ArgumentNullException">options</exception>
        public TokenCleanupHost(IServiceProvider serviceProvider, OperationalStoreOptions options,
            ILogger<TokenCleanupHost> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger;
        }

        /// <summary>
        /// Gets the cleanup interval.
        /// </summary>
        /// <value>The cleanup interval.</value>
        private TimeSpan CleanupInterval => TimeSpan.FromSeconds(_options.TokenCleanupInterval);

        /// <summary>
        /// 启动令牌清理轮询
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        /// <returns>Task.</returns>
        /// <exception cref="InvalidOperationException">Already started. Call Stop first.</exception>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_options.EnableTokenCleanup)
            {
                if (_source != null) throw new InvalidOperationException("Already started. Call Stop first.");

                _logger.LogDebug("Starting grant removal");

                _source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

                Task.Factory.StartNew(() => StartInternalAsync(_source.Token));
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// 停止令牌清理轮询
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        /// <returns>Task.</returns>
        /// <exception cref="InvalidOperationException">Not started. Call Start first.</exception>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_options.EnableTokenCleanup)
            {
                if (_source == null) throw new InvalidOperationException("Not started. Call Start first.");

                _logger.LogDebug("Stopping grant removal");

                _source.Cancel();
                _source = null;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// start internal as an asynchronous operation.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        private async Task StartInternalAsync(CancellationToken cancellationToken)
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

                await RemoveExpiredGrantsAsync();
            }
        }

        /// <summary>
        /// remove expired grants as an asynchronous operation.
        /// </summary>
        private async Task RemoveExpiredGrantsAsync()
        {
            try
            {
                using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var tokenCleanupService = serviceScope.ServiceProvider.GetRequiredService<TokenCleanupService>();
                    await tokenCleanupService.RemoveExpiredGrantsAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception removing expired grants: {exception}", ex.Message);
            }
        }
    }
}