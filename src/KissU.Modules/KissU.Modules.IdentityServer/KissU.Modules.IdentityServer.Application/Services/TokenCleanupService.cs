using System;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Services.Options;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.IdentityServer.Application.Services
{
    /// <summary>
    /// 帮助清除过时的持久授权和设备代码
    /// </summary>
    public class TokenCleanupService
    {
        private readonly IDeviceFlowCodeRepository _deviceFlowCodeRepository;
        private readonly ILogger<TokenCleanupService> _logger;
        private readonly OperationalStoreOptions _options;
        private readonly IPersistedGrantRepository _persistedGrantRepository;
        private readonly IIdentityServerUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="persistedGrantRepository">The persisted grant repository.</param>
        /// <param name="deviceFlowCodeRepository">The device flow code repository.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">options</exception>
        /// <exception cref="ArgumentNullException">persistedGrantRepository</exception>
        /// <exception cref="ArgumentNullException">logger</exception>
        /// <exception cref="ArgumentException">Token cleanup batch size interval must be at least 1</exception>
        public TokenCleanupService(
            OperationalStoreOptions options,
            IIdentityServerUnitOfWork unitOfWork,
            IPersistedGrantRepository persistedGrantRepository,
            IDeviceFlowCodeRepository deviceFlowCodeRepository,
            ILogger<TokenCleanupService> logger)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _unitOfWork = unitOfWork;
            if (_options.TokenCleanupBatchSize < 1)
                throw new ArgumentException("Token cleanup batch size interval must be at least 1");
            _persistedGrantRepository = persistedGrantRepository ??throw new ArgumentNullException(nameof(persistedGrantRepository));
            _deviceFlowCodeRepository = deviceFlowCodeRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 清除过期的持久授权
        /// </summary>
        public async Task RemoveExpiredGrantsAsync()
        {
            try
            {
                _logger.LogTrace("Querying for expired grants to remove");

                await RemoveGrantsAsync();
                await RemoveDeviceCodesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception removing expired grants: {exception}", ex.Message);
            }
        }

        /// <summary>
        /// 移除过时的持久化授权
        /// </summary>
        protected virtual async Task RemoveGrantsAsync()
        {
            var found = int.MaxValue;

            while (found >= _options.TokenCleanupBatchSize)
            {
                var expiredGrants = await _persistedGrantRepository.Find(x => x.Expiration < DateTime.UtcNow)
                    .OrderBy(x => x.Key)
                    .Take(_options.TokenCleanupBatchSize)
                    .ToArrayAsync();

                found = expiredGrants.Length;
                _logger.LogInformation("Removing {grantCount} grants", found);

                if (found > 0)
                {
                    await _persistedGrantRepository.RemoveAsync(expiredGrants);
                    try
                    {
                        await _unitOfWork.CommitAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        // we get this if/when someone else already deleted the records
                        // we want to essentially ignore this, and keep working
                        _logger.LogDebug("Concurrency exception removing expired grants: {exception}", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 移除过时的设备代码
        /// </summary>
        protected virtual async Task RemoveDeviceCodesAsync()
        {
            var found = int.MaxValue;

            while (found >= _options.TokenCleanupBatchSize)
            {
                var expiredCodes = await _deviceFlowCodeRepository
                    .Find(x => x.Expiration < DateTime.UtcNow)
                    .OrderBy(x => x.DeviceCode)
                    .Take(_options.TokenCleanupBatchSize)
                    .ToArrayAsync();

                found = expiredCodes.Length;
                _logger.LogInformation("Removing {deviceCodeCount} device flow codes", found);

                if (found > 0)
                {
                    await _persistedGrantRepository.RemoveAsync(expiredCodes);
                    try
                    {
                        await _unitOfWork.CommitAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        // we get this if/when someone else already deleted the records
                        // we want to essentially ignore this, and keep working
                        _logger.LogDebug("Concurrency exception removing expired grants: {exception}", ex.Message);
                    }
                }
            }
        }
    }
}