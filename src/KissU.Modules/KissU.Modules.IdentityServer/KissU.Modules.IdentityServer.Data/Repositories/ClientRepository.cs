﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util;
using KissU.Util.Datas.Ef.Core;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ClientRepository : RepositoryBase<Client, int>, IClientRepository
    {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ClientRepository(IIdentityServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientId">应用编号</param>
        /// <returns>Task&lt;Client&gt;.</returns>
        public async Task<Client> FindEnabledClientByIdAsync(string clientId)
        {
            var queryable = Find(p => p.ClientId == clientId && p.Enabled)
                .Include(x => x.ClientSecrets)
                .Include(x => x.Claims);
            return await queryable.SingleAsync();
        }

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns>Task&lt;List&lt;ClientClaim&gt;&gt;.</returns>
        public async Task<List<ClientClaim>> GetClientClaimsAsync(int clientId)
        {
            var queryable = from clientClaim in UnitOfWork.Set<ClientClaim>()
                join client in Set on clientClaim.Client.Id equals client.Id
                where clientClaim.Client.Id == clientId
                select clientClaim;
            return await queryable.Include(x => x.Client).ToListAsync();
        }

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns>Task&lt;ClientClaim&gt;.</returns>
        public async Task<ClientClaim> GetClientClaimAsync(int id)
        {
            var queryable = from clientClaim in UnitOfWork.Set<ClientClaim>()
                join client in Set on clientClaim.Client.Id equals client.Id
                select clientClaim;
            return await queryable.Include(x => x.Client).SingleAsync();
        }

        /// <summary>
        /// 添加应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        public async Task CreateClientClaimAsync(ClientClaim entity)
        {
            await UnitOfWork.Set<ClientClaim>().AddAsync(entity);
        }

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        /// <returns>Task.</returns>
        public Task UpdateClientClaimAsync(ClientClaim entity)
        {
            UnitOfWork.Set<ClientClaim>().Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明</param>
        public async Task DeleteClientClaimAsync(int id)
        {
            var entity = await UnitOfWork.Set<ClientClaim>().Where(x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ClientClaim>().Remove(entity);
        }

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns>Task&lt;List&lt;ClientSecret&gt;&gt;.</returns>
        public async Task<List<ClientSecret>> GetClientSecretsAsync(int clientId)
        {
            var queryable = from clientSecret in UnitOfWork.Set<ClientSecret>()
                join client in Set on clientSecret.Client.Id equals client.Id
                where clientSecret.Client.Id == clientId
                select clientSecret;
            return await queryable.Include(x => x.Client).ToListAsync();
        }

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns>Task&lt;ClientSecret&gt;.</returns>
        public async Task<ClientSecret> GetClientSecretAsync(int id)
        {
            var queryable = from clientSecret in UnitOfWork.Set<ClientSecret>()
                join client in Set on clientSecret.Client.Id equals client.Id
                where clientSecret.Id == id
                select clientSecret;
            return await queryable.Include(x => x.Client).SingleAsync();
        }

        /// <summary>
        /// 添加应用程序密钥
        /// </summary>
        /// <param name="entity">应用程序密钥</param>
        public async Task CreateClientSecretAsync(ClientSecret entity)
        {
            await UnitOfWork.Set<ClientSecret>().AddAsync(entity);
        }

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥</param>
        public async Task DeleteClientSecretAsync(int id)
        {
            var entity = await UnitOfWork.Set<ClientSecret>().Where(x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ClientSecret>().Remove(entity);
        }

        #endregion
    }
}