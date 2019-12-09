// <copyright file="ClientRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KissU.Modules.IdentityServer.Data.UnitOfWorks;
    using KissU.Modules.IdentityServer.Domain.Models.ClientAggregate;
    using KissU.Modules.IdentityServer.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Util;
    using Util.Datas.Ef.Core;

    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
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
        /// <param name="clientCode">应用编号</param>
        /// <returns></returns>
        public async Task<Client> FindEnabledClientByCodeAsync(string clientCode)
        {
            var queryable = Find(p => p.ClientCode == clientCode && p.Enabled)
                .Include(x => x.ClientSecrets)
                .Include(x => x.Claims);
            return await queryable.SingleAsync();
        }

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        public async Task<List<ClientClaim>> GetClientClaimsAsync(Guid clientId)
        {
            var queryable = from clientClaim in UnitOfWork.Set<ClientClaim>()
                join client in Set on clientClaim.Client.Id equals client.Id
                where clientClaim.Client.Id == clientId
                select clientClaim;
            return await EntityFrameworkQueryableExtensions.Include<ClientClaim, Client>(queryable, x => x.Client)
                .ToListAsync();
        }

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        public async Task<ClientClaim> GetClientClaimAsync(Guid id)
        {
            var queryable = from clientClaim in UnitOfWork.Set<ClientClaim>()
                join client in Set on clientClaim.Client.Id equals client.Id
                where clientClaim.Id == id
                select clientClaim;
            return await EntityFrameworkQueryableExtensions.Include<ClientClaim, Client>(queryable, x => x.Client)
                .SingleAsync();
        }

        /// <summary>
        /// 添加应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        /// <returns></returns>
        public async Task CreateClientClaimAsync(ClientClaim entity)
        {
            await UnitOfWork.Set<ClientClaim>().AddAsync(entity);
        }

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        /// <returns></returns>
        public Task UpdateClientClaimAsync(ClientClaim entity)
        {
            UnitOfWork.Set<ClientClaim>().Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明</param>
        /// <returns></returns>
        public async Task DeleteClientClaimAsync(Guid id)
        {
            var entity = await Queryable.Where(UnitOfWork.Set<ClientClaim>(), x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ClientClaim>().Remove(entity);
        }

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        public async Task<List<ClientSecret>> GetClientSecretsAsync(Guid clientId)
        {
            var queryable = from clientSecret in UnitOfWork.Set<ClientSecret>()
                join client in Set on clientSecret.Client.Id equals client.Id
                where clientSecret.Client.Id == clientId
                select clientSecret;
            return await EntityFrameworkQueryableExtensions.Include<ClientSecret, Client>(queryable, x => x.Client)
                .ToListAsync();
        }

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        public async Task<ClientSecret> GetClientSecretAsync(Guid id)
        {
            var queryable = from clientSecret in UnitOfWork.Set<ClientSecret>()
                join client in Set on clientSecret.Client.Id equals client.Id
                where clientSecret.Id == id
                select clientSecret;
            return await EntityFrameworkQueryableExtensions.Include<ClientSecret, Client>(queryable, x => x.Client)
                .SingleAsync();
        }

        /// <summary>
        /// 添加应用程序密钥
        /// </summary>
        /// <param name="entity">应用程序密钥</param>
        /// <returns></returns>
        public async Task CreateClientSecretAsync(ClientSecret entity)
        {
            await UnitOfWork.Set<ClientSecret>().AddAsync(entity);
        }

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥</param>
        /// <returns></returns>
        public async Task DeleteClientSecretAsync(Guid id)
        {
            var entity = await Queryable.Where(UnitOfWork.Set<ClientSecret>(), x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ClientSecret>().Remove(entity);
        }

        #endregion
    }
}
