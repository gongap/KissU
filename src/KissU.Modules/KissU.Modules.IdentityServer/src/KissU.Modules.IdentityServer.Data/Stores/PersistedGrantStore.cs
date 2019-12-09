// <copyright file="PersistedGrantStore.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Stores
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IdentityServer4.Stores;
    using KissU.Modules.IdentityServer.Data.UnitOfWorks;
    using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;
    using KissU.Modules.IdentityServer.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Util.Maps;
    using Ids4 = IdentityServer4.Models;

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
            IPersistedGrantRepository persistedGrantRepository)
        {
            _persistedGrantRepository = persistedGrantRepository;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 令牌许可仓储
        /// </summary>
        public IPersistedGrantRepository _persistedGrantRepository { get; set; }

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
                var persistedGrant = token.MapTo<PersistedGrant>();
                persistedGrant.Init();
                await _persistedGrantRepository.AddAsync(persistedGrant);
                await UnitOfWork.CommitAsync();
            }
            else
            {
                var persistedGrant = token.MapTo(existing);
                await _persistedGrantRepository.UpdateAsync(persistedGrant);
                await UnitOfWork.CommitAsync();
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
            return persistedGrant?.MapTo<Ids4.PersistedGrant>();
        }

        /// <summary>
        /// 获取用户所有授权收据
        /// </summary>
        /// <param name="subjectId">用户主体</param>
        /// <returns></returns>
        public async Task<IEnumerable<Ids4.PersistedGrant>> GetAllAsync(string subjectId)
        {
            var persistedGrants = await _persistedGrantRepository.Find(x => x.SubjectId == subjectId).ToListAsync();
            return persistedGrants?.MapToList<Ids4.PersistedGrant>().AsEnumerable();
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
                await _persistedGrantRepository.RemoveAsync(persistedGrant);
                await UnitOfWork.CommitAsync();
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
            var persistedGrants = await _persistedGrantRepository
                .Find(x => x.SubjectId == subjectId && x.ClientId == clientId).ToListAsync();
            if (persistedGrants?.Count > 0)
            {
                await _persistedGrantRepository.RemoveAsync(persistedGrants);
                await UnitOfWork.CommitAsync();
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
            var persistedGrants = await _persistedGrantRepository
                .Find(x => x.SubjectId == subjectId && x.ClientId == clientId && x.Type == type).ToListAsync();
            if (persistedGrants?.Count > 0)
            {
                await _persistedGrantRepository.RemoveAsync(persistedGrants);
                await UnitOfWork.CommitAsync();
            }
        }
    }
}
