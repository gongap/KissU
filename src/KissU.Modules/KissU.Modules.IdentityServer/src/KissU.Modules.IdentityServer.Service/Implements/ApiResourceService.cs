using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.Shared;
using KissU.Modules.IdentityServer.Domain.Shared.Enums;
using KissU.Modules.IdentityServer.Service.Contracts.Abstractions;
using KissU.Modules.IdentityServer.Service.Contracts.Commands;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
using KissU.Modules.IdentityServer.Service.Contracts.Queries;
using Util;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Exceptions;
using Util.Maps;
using ApiResource = KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate.ApiResource;
using Extensions = KissU.Modules.IdentityServer.Domain.Extensions.Extensions;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public class ApiResourceService : CrudServiceBase<ApiResource, ApiResourceDto, ApiResourceDto,ApiResourceCreateRequest, ApiResourceDto,ApiResourceQuery, Guid>, IApiResourceService
    {
        /// <summary>
        /// 初始化Api资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiResourceRepository">Api资源仓储</param>
        public ApiResourceService(IIdentityServerUnitOfWork unitOfWork, IApiResourceRepository apiResourceRepository)
            : base(unitOfWork, apiResourceRepository)
        {
            ApiResourceRepository = apiResourceRepository;
            UnitOfWork = unitOfWork;
        }
        /// <summary>
        /// Api资源仓储
        /// </summary>
        public IApiResourceRepository ApiResourceRepository { get; set; }
        /// <summary>
        /// 工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        protected override IQueryBase<ApiResource> CreateQuery(ApiResourceQuery param)
        {
            var query = new Query<ApiResource>(param).Or(t => t.Name.Contains(param.Keyword), t => t.DisplayName.Contains(param.Keyword));

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
                ThrowApiResourceNameRepeatException(entity.Name);
        }

        /// <summary>
        /// 抛出Name重复异常
        /// </summary>
        private void ThrowApiResourceNameRepeatException(string code)
        {
            throw new Warning(string.Format(IdentityServerConsts.DuplicateName, code));
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore(ApiResource entity)
        {
            base.UpdateBefore(entity);
            if (ApiResourceRepository.Exists(t => t.Id != entity.Id && t.Name == entity.Name))
                ThrowApiResourceNameRepeatException(entity.Name);
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<ApiResource> Filter(IQueryable<ApiResource> queryable, ApiResourceQuery parameter)
        {
            return base.Filter(queryable, parameter);
        }

        #region Api许可范围
        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        public async Task<List<ApiResourceScopeDto>> GetApiResourceScopesAsync(Guid apiResourceId)
        {
            var entities = await ApiResourceRepository.GetApiResourceScopesAsync(apiResourceId);
            return entities?.MapToList<ApiResourceScopeDto>();
        }

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        public async Task<ApiResourceScopeDto> GetApiResourceScopeAsync(Guid id)
        {
            var entity = await ApiResourceRepository.GetApiResourceScopeAsync(id);
            return entity?.MapTo<ApiResourceScopeDto>();
        }

        /// <summary>
        /// 添加Api许可范围
        /// </summary>
        /// <param name="request">Api许可范围</param>
        /// <returns></returns>
        public async Task<Guid> CreateApiResourceScopeAsync(ApiResourceScopeCreateRequest request)
        {
            var apiResource = await ApiResourceRepository.FindAsync(request.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            var entity = request.MapTo<ApiResourceScope>();
            entity.Init();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.CreateApiResourceScopeAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="dto">Api许可范围</param>
        /// <returns></returns>
        public async Task UpdateApiResourceScopeAsync(ApiResourceScopeDto dto)
        {
            var apiResource = await ApiResourceRepository.FindAsync(dto.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            var entity = dto.MapTo<ApiResourceScope>();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.UpdateApiResourceScopeAsync(entity);
        }

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        public async Task DeleteApiResourceScopeAsync(Guid id)
        {
            await ApiResourceRepository.DeleteApiResourceScopeAsync(id);
        }
        #endregion

        #region Api密钥
        /// <summary>
        /// 哈希Api密钥
        /// </summary>
        /// <param name="request">Api密钥</param>
        private void HashApiSharedSecret(ApiResourceSecretCreateRequest request)
        {
            if (request.Type != IdentityServerConstants.SecretTypes.SharedSecret) return;

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
        /// 获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        public async Task<List<ApiResourceSecretDto>> GetApiResourceSecretsAsync(Guid apiResourceId)
        {
            var entities = await ApiResourceRepository.GetApiResourceSecretsAsync(apiResourceId);
            return entities?.MapToList<ApiResourceSecretDto>();
        }

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        public async Task<ApiResourceSecretDto> GetApiResourceSecretAsync(Guid id)
        {
            var entity = await ApiResourceRepository.GetApiResourceSecretAsync(id);
            return entity?.MapTo<ApiResourceSecretDto>();
        }

        /// <summary>
        /// 添加Api密钥
        /// </summary>
        /// <param name="request">Api密钥</param>
        /// <returns></returns>
        public async Task<Guid> CreateApiResourceSecretAsync(ApiResourceSecretCreateRequest request)
        {
            var apiResource = await ApiResourceRepository.FindAsync(request.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            HashApiSharedSecret(request);
            var entity = request.MapTo<ApiResourceSecret>();
            entity.Init();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.CreateApiResourceSecretAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        public async Task DeleteApiResourceSecretAsync(Guid id)
        {
            await ApiResourceRepository.DeleteApiResourceSecretAsync(id);
        }
        #endregion
    }
}
