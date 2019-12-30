using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ids4 = IdentityServer4.Models;

namespace KissU.Modules.IdentityServer.Data.Stores
{
    /// <summary>
    /// 认证操作数据存储器
    /// </summary>
    public class PersistedGrantStore : IPersistedGrantStore
    {
        /// <summary>
        /// 令牌许可仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="persistedGrantRepository">认证操作数据仓储</param>
        public PersistedGrantStore(IIdentityServerUnitOfWork unitOfWork,
            IPersistedGrantRepository persistedGrantRepository,
            ILogger<PersistedGrantStore> logger)
        {
            _persistedGrantRepository = persistedGrantRepository;
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 令牌许可仓储
        /// </summary>
        public IPersistedGrantRepository _persistedGrantRepository { get; set; }

        /// <summary>
        /// 日志记录器
        /// </summary>
        public ILogger<PersistedGrantStore> Logger { get; }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 持久化授权收据
        /// </summary>
        /// <param name="token">令牌</param>
        /// <returns></returns>
        public async Task StoreAsync(Ids4.PersistedGrant token)
        {
            var existing = await _persistedGrantRepository.SingleAsync(x => x.Key == token.Key);
            if (existing == null)
            {
                Logger.LogDebug("{persistedGrantKey} not found in database", token.Key);

                var persistedGrant = token.MapTo<PersistedGrant>();
                persistedGrant.Init();
                await _persistedGrantRepository.AddAsync(persistedGrant);
                await UnitOfWork.CommitAsync();
            }
            else
            {
                Logger.LogDebug("{persistedGrantKey} found in database", token.Key);

                var persistedGrant = token.MapTo(existing);
                await _persistedGrantRepository.UpdateAsync(persistedGrant);
                try
                {
                    await UnitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Logger.LogWarning("exception updating {persistedGrantKey} persisted grant in database: {error}", token.Key, ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取授权收据
        /// </summary>
        /// <param name="key">标识key</param>
        /// <returns></returns>
        public async Task<Ids4.PersistedGrant> GetAsync(string key)
        {
            var persistedGrant = await _persistedGrantRepository.SingleAsync(x => x.Key == key);

            var model = persistedGrant?.MapTo<Ids4.PersistedGrant>();

            Logger.LogDebug("{persistedGrantKey} found in database: {persistedGrantKeyFound}", key, model != null);

            return model;
        }

        /// <summary>
        /// 获取用户所有授权收据
        /// </summary>
        /// <param name="subjectId">用户主体</param>
        /// <returns></returns>
        public async Task<IEnumerable<Ids4.PersistedGrant>> GetAllAsync(string subjectId)
        {
            var persistedGrants = await _persistedGrantRepository.Find(x => x.SubjectId == subjectId).ToListAsync();

            var model = persistedGrants?.MapToList<Ids4.PersistedGrant>().AsEnumerable();

            Logger.LogDebug("{persistedGrantCount} persisted grants found for {subjectId}", persistedGrants.Count, subjectId);

            return model;
        }

        /// <summary>
        /// 删除授权数据
        /// </summary>
        /// <param name="key">标识key</param>
        /// <returns></returns>
        public async Task RemoveAsync(string key)
        {
            var persistedGrant = await _persistedGrantRepository.SingleAsync(x => x.Key == key);
            if (persistedGrant != null)
            {
                Logger.LogDebug("removing {persistedGrantKey} persisted grant from database", key);

                await _persistedGrantRepository.RemoveAsync(persistedGrant);
                
                try
                {
                    await UnitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Logger.LogInformation("exception removing {persistedGrantKey} persisted grant from database: {error}", key, ex.Message);
                }
            }
            else
            {
                Logger.LogDebug("no {persistedGrantKey} persisted grant found in database", key);
            }
        }

        /// <summary>
        /// 删除授权数据
        /// </summary>
        /// <param name="subjectId">用户Id</param>
        /// <param name="clientId">应用Id</param>
        /// <returns></returns>
        public async Task RemoveAllAsync(string subjectId, string clientId)
        {
            var persistedGrants = await _persistedGrantRepository.Find(x => x.SubjectId == subjectId && x.ClientId == clientId).ToListAsync();

            Logger.LogDebug("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}", persistedGrants.Count, subjectId, clientId);

            if (persistedGrants?.Count > 0)
            {
                await _persistedGrantRepository.RemoveAsync(persistedGrants);
                
                try
                {
                    await UnitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Logger.LogInformation("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}: {error}", persistedGrants.Count, subjectId, clientId, ex.Message);
                }
            }
        }

        /// <summary>
        /// 删除授权数据
        /// </summary>
        /// <param name="subjectId">用户Id</param>
        /// <param name="clientId">应用Id</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public async Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            var persistedGrants = await _persistedGrantRepository.Find(x => x.SubjectId == subjectId && x.ClientId == clientId && x.Type == type).ToListAsync();

            Logger.LogDebug("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}, grantType {persistedGrantType}", persistedGrants.Count, subjectId, clientId, type);
            if (persistedGrants?.Count > 0)
            {
                await _persistedGrantRepository.RemoveAsync(persistedGrants);
                
                try
                {
                    await UnitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Logger.LogInformation("exception removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}, grantType {persistedGrantType}: {error}", persistedGrants.Count, subjectId, clientId, type, ex.Message);
                }
            }
        }
    }
}