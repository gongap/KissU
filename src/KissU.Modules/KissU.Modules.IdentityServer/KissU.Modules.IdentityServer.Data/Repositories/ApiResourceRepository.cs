// <copyright file="ApiResourceRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using KissU.Util;
using KissU.Util.Datas.Ef.Core;

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    /// <summary>
    /// API资源仓储
    /// </summary>
    public class ApiResourceRepository : RepositoryBase<ApiResource>, IApiResourceRepository
    {
        /// <summary>
        /// 初始化API资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiResourceRepository(IIdentityServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Api许可范围

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        public async Task<List<ApiScope>> GetApiResourceScopesAsync(Guid apiResourceId)
        {
            var queryable = from apiScope in UnitOfWork.Set<ApiScope>()
                join apiResource in Set on apiScope.ApiResource.Id equals apiResource.Id
                where apiScope.ApiResource.Id == apiResourceId
                select apiScope;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiScope, ApiResource>(queryable, x => x.ApiResource).ToListAsync();
        }

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        public async Task<ApiScope> GetApiResourceScopeAsync(Guid id)
        {
            var queryable = from apiScope in UnitOfWork.Set<ApiScope>()
                join apiResource in Set on apiScope.ApiResource.Id equals apiResource.Id
                where apiScope.Id == id
                select apiScope;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiScope, ApiResource>(queryable, x => x.ApiResource).SingleAsync();
        }

        /// <summary>
        /// 添加Api许可范围
        /// </summary>
        /// <param name="entity">Api许可范围</param>
        /// <returns></returns>
        public async Task CreateApiResourceScopeAsync(ApiScope entity)
        {
            await UnitOfWork.Set<ApiScope>().AddAsync(entity);
        }

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="entity">Api许可范围</param>
        /// <returns></returns>
        public Task UpdateApiResourceScopeAsync(ApiScope entity)
        {
            UnitOfWork.Set<ApiScope>().Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围</param>
        /// <returns></returns>
        public async Task DeleteApiResourceScopeAsync(Guid id)
        {
            var entity = await Queryable.Where(UnitOfWork.Set<ApiScope>(), x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ApiScope>().Remove(entity);
        }

        #endregion

        #region Api密钥

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        public async Task<List<ApiSecret>> GetApiResourceSecretsAsync(Guid apiResourceId)
        {
            var queryable = from apiSecret in UnitOfWork.Set<ApiSecret>()
                join apiResource in Set on apiSecret.ApiResource.Id equals apiResource.Id
                where apiSecret.ApiResource.Id == apiResourceId
                select apiSecret;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiSecret, ApiResource>(queryable, x => x.ApiResource).ToListAsync();
        }

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        public async Task<ApiSecret> GetApiResourceSecretAsync(Guid id)
        {
            var queryable = from apiSecret in UnitOfWork.Set<ApiSecret>()
                join apiResource in Set on apiSecret.ApiResource.Id equals apiResource.Id
                where apiSecret.Id == id
                select apiSecret;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiSecret, ApiResource>(queryable, x => x.ApiResource).SingleAsync();
        }

        /// <summary>
        /// 添加Api密钥
        /// </summary>
        /// <param name="entity">Api密钥</param>
        /// <returns></returns>
        public async Task CreateApiResourceSecretAsync(ApiSecret entity)
        {
            await UnitOfWork.Set<ApiSecret>().AddAsync(entity);
        }

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥</param>
        /// <returns></returns>
        public async Task DeleteApiResourceSecretAsync(Guid id)
        {
            var entity = await Queryable.Where(UnitOfWork.Set<ApiSecret>(), x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ApiSecret>().Remove(entity);
        }

        #endregion
    }
}
