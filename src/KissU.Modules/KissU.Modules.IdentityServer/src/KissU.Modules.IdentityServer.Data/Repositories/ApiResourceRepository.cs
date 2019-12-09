// <copyright file="ApiResourceRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KissU.Modules.IdentityServer.Data.UnitOfWorks;
    using KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate;
    using KissU.Modules.IdentityServer.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Util;
    using Util.Datas.Ef.Core;

    /// <summary>
    ///     API资源仓储
    /// </summary>
    public class ApiResourceRepository : RepositoryBase<ApiResource>, IApiResourceRepository
    {
        /// <summary>
        ///     初始化API资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiResourceRepository(IIdentityServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Api许可范围

        /// <summary>
        ///     获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        public async Task<List<ApiResourceScope>> GetApiResourceScopesAsync(Guid apiResourceId)
        {
            var queryable = from apiScope in UnitOfWork.Set<ApiResourceScope>()
                join apiResource in Set on apiScope.ApiResource.Id equals apiResource.Id
                where apiScope.ApiResource.Id == apiResourceId
                select apiScope;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiResourceScope, ApiResource>(queryable, x => x.ApiResource).ToListAsync();
        }

        /// <summary>
        ///     获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        public async Task<ApiResourceScope> GetApiResourceScopeAsync(Guid id)
        {
            var queryable = from apiScope in UnitOfWork.Set<ApiResourceScope>()
                join apiResource in Set on apiScope.ApiResource.Id equals apiResource.Id
                where apiScope.Id == id
                select apiScope;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiResourceScope, ApiResource>(queryable, x => x.ApiResource).SingleAsync();
        }

        /// <summary>
        ///     添加Api许可范围
        /// </summary>
        /// <param name="entity">Api许可范围</param>
        /// <returns></returns>
        public async Task CreateApiResourceScopeAsync(ApiResourceScope entity)
        {
            await UnitOfWork.Set<ApiResourceScope>().AddAsync(entity);
        }

        /// <summary>
        ///     更新Api许可范围
        /// </summary>
        /// <param name="entity">Api许可范围</param>
        /// <returns></returns>
        public Task UpdateApiResourceScopeAsync(ApiResourceScope entity)
        {
            UnitOfWork.Set<ApiResourceScope>().Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        ///     删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围</param>
        /// <returns></returns>
        public async Task DeleteApiResourceScopeAsync(Guid id)
        {
            var entity = await Queryable.Where(UnitOfWork.Set<ApiResourceScope>(), x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ApiResourceScope>().Remove(entity);
        }

        #endregion

        #region Api密钥

        /// <summary>
        ///     获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        public async Task<List<ApiResourceSecret>> GetApiResourceSecretsAsync(Guid apiResourceId)
        {
            var queryable = from apiSecret in UnitOfWork.Set<ApiResourceSecret>()
                join apiResource in Set on apiSecret.ApiResource.Id equals apiResource.Id
                where apiSecret.ApiResource.Id == apiResourceId
                select apiSecret;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiResourceSecret, ApiResource>(queryable, x => x.ApiResource).ToListAsync();
        }

        /// <summary>
        ///     获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        public async Task<ApiResourceSecret> GetApiResourceSecretAsync(Guid id)
        {
            var queryable = from apiSecret in UnitOfWork.Set<ApiResourceSecret>()
                join apiResource in Set on apiSecret.ApiResource.Id equals apiResource.Id
                where apiSecret.Id == id
                select apiSecret;
            return await EntityFrameworkQueryableExtensions
                .Include<ApiResourceSecret, ApiResource>(queryable, x => x.ApiResource).SingleAsync();
        }

        /// <summary>
        ///     添加Api密钥
        /// </summary>
        /// <param name="entity">Api密钥</param>
        /// <returns></returns>
        public async Task CreateApiResourceSecretAsync(ApiResourceSecret entity)
        {
            await UnitOfWork.Set<ApiResourceSecret>().AddAsync(entity);
        }

        /// <summary>
        ///     删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥</param>
        /// <returns></returns>
        public async Task DeleteApiResourceSecretAsync(Guid id)
        {
            var entity = await Queryable.Where(UnitOfWork.Set<ApiResourceSecret>(), x => x.Id == id).SingleAsync();

            entity.CheckNull(nameof(entity));

            UnitOfWork.Set<ApiResourceSecret>().Remove(entity);
        }

        #endregion
    }
}
