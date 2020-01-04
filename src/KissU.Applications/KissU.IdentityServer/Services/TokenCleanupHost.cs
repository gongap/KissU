using System;
using System.Threading;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Services;
using KissU.Modules.IdentityServer.Application.Services.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KissU.IdentityServer.Services
{
    /// <summary>
    /// 清除过期持久授权的帮助程序
    /// </summary>
    public class TokenCleanupHost : IHostedService
    {
        private readonly ILogger<TokenCleanupHost> _logger;
        private readonly OperationalStoreOptions _options;
        private readonly IServiceProvider _serviceProvider;

        private CancellationTokenSource _source;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public TokenCleanupHost(IServiceProvider serviceProvider, OperationalStoreOptions options,
            ILogger<TokenCleanupHost> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger;
        }

        private TimeSpan CleanupInterval => TimeSpan.FromSeconds(_options.TokenCleanupInterval);

        /// <summary>
        /// 启动令牌清理轮询
        /// </summary>
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