// <copyright file="ApiResourceService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.Shared;
using KissU.Modules.IdentityServer.Domain.Shared.Enums;
using KissU.Modules.IdentityServer.Service.Contracts.Abstractions;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests;
using KissU.Modules.IdentityServer.Service.Contracts.Queries;
using KissU.Util;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;
using KissU.Util.Exceptions;
using KissU.Util.Maps;
using Extensions = KissU.Modules.IdentityServer.Domain.Shared.Extensions;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// 资源服务
    /// </summary>
    public class ApiResourceService : IApiResourceService
    {
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiResourceRepository">资源仓储</param>
        public ApiResourceService(IIdentityServerUnitOfWork unitOfWork, IApiResourceRepository apiResourceRepository)
            : base(unitOfWork, apiResourceRepository)
        {
            ApiResourceRepository = apiResourceRepository;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 资源仓储
        /// </summary>
        public IApiResourceRepository ApiResourceRepository { get; set; }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public override async Task DeleteAsync(string ids)
        {
            await base.DeleteAsync(ids);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public Task<ApiResourceDto> GetByIdAsync(string id)
        {
            return base.GetByIdAsync(id);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        public override async Task<string> CreateAsync(ApiResourceCreateRequest request)
        {
            var result = await base.CreateAsync(request);
            await UnitOfWork.CommitAsync();
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public override async Task UpdateAsync(ApiResourceDto request)
        {
            await base.UpdateAsync(request);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        protected override IQueryBase<ApiResource> CreateQuery(ApiResourceQuery param)
        {
            var query = new Query<ApiResource>(param).Or(t => t.Name.Contains(param.Keyword),
                t => t.DisplayName.Contains(param.Keyword));

            if (param.Enabled.HasValue)
            {
                query.And(t => t.Enabled == param.Enabled.Value);
            }

            if (string.IsNullOrWhiteSpace(param.Order))
            {
                query.OrderBy(x => x.CreationTime, true);
            }

            return query;
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected override void CreateBefore(ApiResource entity)
        {
            base.CreateBefore(entity);
            if (ApiResourceRepository.Exists(t => t.Name == entity.Name))
            {
                ThrowApiResourceNameRepeatException(entity.Name);
            }
        }

        /// <summary>
        /// 抛出Name重复异常
        /// </summary>
        private void ThrowApiResourceNameRepeatException(string code)
        {
            throw new Warning(string.Format("名称{0} 重复", code));
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore(ApiResource entity)
        {
            base.UpdateBefore(entity);
            if (ApiResourceRepository.Exists(t => t.Id != entity.Id && t.Name == entity.Name))
            {
                ThrowApiResourceNameRepeatException(entity.Name);
            }
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<ApiResource> Filter(IQueryable<ApiResource> queryable, ApiResourceQuery parameter)
        {
            return base.Filter(queryable, parameter);
        }

        #region 许可范围

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns></returns>
        public async Task<List<ApiResourceScopeDto>> GetScopesAsync(string id)
        {
            var entities = await ApiResourceRepository.GetApiResourceScopesAsync(id.ToGuid());
            return entities?.MapToList<ApiResourceScopeDto>();
        }

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns></returns>
        public async Task<ApiResourceScopeDto> GetScopeAsync(string scopeId)
        {
            var entity = await ApiResourceRepository.GetApiResourceScopeAsync(scopeId.ToGuid());
            return entity?.MapTo<ApiResourceScopeDto>();
        }

        /// <summary>
        /// 添加许可范围
        /// </summary>
        /// <param name="request">许可范围</param>
        /// <returns></returns>
        public async Task<Guid> CreateScopeAsync(ApiResourceScopeCreateRequest request)
        {
            var apiResource = await ApiResourceRepository.FindAsync(request.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            var entity = request.MapTo<ApiScope>();
            entity.Init();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.CreateApiResourceScopeAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity.Id;
        }

        /// <summary>
        /// 更新许可范围
        /// </summary>
        /// <param name="dto">许可范围</param>
        /// <returns></returns>
        public async Task UpdateScopeAsync(ApiResourceScopeDto dto)
        {
            var apiResource = await ApiResourceRepository.FindAsync(dto.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            var entity = dto.MapTo<ApiScope>();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.UpdateApiResourceScopeAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 删除许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns></returns>
        public async Task DeleteScopeAsync(string scopeId)
        {
            await ApiResourceRepository.DeleteApiResourceScopeAsync(scopeId.ToGuid());
            await UnitOfWork.CommitAsync();
        }

        #endregion

        #region 密钥

        /// <summary>
        /// 哈希密钥
        /// </summary>
        /// <param name="request">密钥</param>
        private void HashApiSharedSecret(ApiResourceSecretCreateRequest request)
        {
            if (request.Type != IdentityServerConstants.SecretTypes.SharedSecret)
            {
                return;
            }

            if (request.HashType == HashType.Sha256)
            {
                request.Value = Extensions.Sha256(request.Value);
            }
            else if (request.HashType == HashType.Sha512)
            {
                request.Value = Extensions.Sha512(request.Value);
            }
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns></returns>
        public async Task<List<ApiResourceSecretDto>> GetSecretsAsync(string id)
        {
            var entities = await ApiResourceRepository.GetApiResourceSecretsAsync(id.ToGuid());
            return entities?.MapToList<ApiResourceSecretDto>();
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns></returns>
        public async Task<ApiResourceSecretDto> GetSecretAsync(string secretId)
        {
            var entity = await ApiResourceRepository.GetApiResourceSecretAsync(secretId.ToGuid());
            return entity?.MapTo<ApiResourceSecretDto>();
        }

        /// <summary>
        /// 添加密钥
        /// </summary>
        /// <param name="request">密钥</param>
        /// <returns></returns>
        public async Task<Guid> CreateSecretAsync(ApiResourceSecretCreateRequest request)
        {
            var apiResource = await ApiResourceRepository.FindAsync(request.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            HashApiSharedSecret(request);
            var entity = request.MapTo<ApiSecret>();
            entity.Init();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.CreateApiResourceSecretAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity.Id;
        }

        /// <summary>
        /// 删除密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns></returns>
        public async Task DeleteSecretAsync(string secretId)
        {
            await ApiResourceRepository.DeleteApiResourceSecretAsync(secretId.ToGuid());
            await UnitOfWork.CommitAsync();
        }

        #endregion
    }
}
