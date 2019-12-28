using System;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Modules.IdentityServer.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.IdentityServer.Services
{
    /// <summary>
    /// Helper to cleanup stale persisted grants and device codes.
    /// </summary>
    public class TokenCleanupService
    {
        private readonly OperationalStoreOptions _options;
        private readonly IPersistedGrantRepository _persistedGrantRepository;
        private readonly IDeviceFlowCodeRepository _deviceFlowCodeRepository;
        private readonly IOperationalStoreNotification _operationalStoreNotification;
        private readonly IIdentityServerUnitOfWork _unitOfWork;
        private readonly ILogger<TokenCleanupService> _logger;

        /// <summary>
        /// Constructor for TokenCleanupService.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="persistedGrantRepository"></param>
        /// <param name="operationalStoreNotification"></param>
        /// <param name="deviceFlowCodeRepository"></param>
        /// <param name="logger"></param>
        public TokenCleanupService(
            OperationalStoreOptions options,
            IIdentityServerUnitOfWork unitOfWork,
            IPersistedGrantRepository persistedGrantRepository,
            IDeviceFlowCodeRepository deviceFlowCodeRepository,
            ILogger<TokenCleanupService> logger,
            IOperationalStoreNotification operationalStoreNotification = null)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _unitOfWork = unitOfWork;
            if (_options.TokenCleanupBatchSize < 1) throw new ArgumentException("Token cleanup batch size interval must be at least 1");

            _persistedGrantRepository = persistedGrantRepository ?? throw new ArgumentNullException(nameof(persistedGrantRepository));
            _deviceFlowCodeRepository = deviceFlowCodeRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _operationalStoreNotification = operationalStoreNotification;

        }

        /// <summary>
        /// Method to clear expired persisted grants.
        /// </summary>
        /// <returns></returns>
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
        /// Removes the stale persisted grants.
        /// </summary>
        /// <returns></returns>
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

                        if (_operationalStoreNotification != null)
                        {
                            await _operationalStoreNotification.PersistedGrantsRemovedAsync(expiredGrants);
                        }
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
        /// Removes the stale device codes.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task RemoveDeviceCodesAsync()
        {
            var found = Int32.MaxValue;

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