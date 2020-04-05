using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4;
using KissU.Core;
using KissU.Core.Exceptions;
using KissU.Core.Maps;
using KissU.Modules.IdentityServer.Application.Abstractions;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.Enums;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Applications;
using KissU.Util.Ddd.Datas.Queries;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Application.Implements
{
    /// <summary>
    /// 资源服务
    /// </summary>
    public class ApiResourceAppService :
        CrudServiceBase<ApiResource, ApiResourceDto, ApiResourceDto, ApiResourceCreateRequest, ApiResourceDto,
            ApiResourceQuery, int>, IApiResourceAppService
    {
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiResourceRepository">资源仓储</param>
        public ApiResourceAppService(IIdentityServerUnitOfWork unitOfWork, IApiResourceRepository apiResourceRepository)
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
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        public override async Task DeleteAsync(string ids)
        {
            await base.DeleteAsync(ids);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        public override async Task UpdateAsync(ApiResourceDto request)
        {
            await base.UpdateAsync(request);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        protected override async Task CreateAfterAsync(ApiResource entity)
        {
            await base.CreateAfterAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        /// <returns>IQueryBase&lt;ApiResource&gt;.</returns>
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
                query.OrderBy(x => x.Id, true);
            }

            return query;
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="entity">The entity.</param>
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
        /// <param name="entity">实体</param>
        protected override void UpdateBefore(ApiResource entity)
        {
            base.UpdateBefore(entity);
            if (ApiResourceRepository.Exists(t => t.Id != entity.Id && t.Name == entity.Name))
            {
                ThrowApiResourceNameRepeatException(entity.Name);
            }
        }

        #region 许可范围

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">资源编号</param>
        /// <returns>Task&lt;List&lt;ApiScopeDto&gt;&gt;.</returns>
        public async Task<List<ApiScopeDto>> GetApiScopesAsync(int apiResourceId)
        {
            var entities = await ApiResourceRepository.GetApiResourceScopesAsync(apiResourceId);
            return entities?.MapToList<ApiScopeDto>();
        }

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns>Task&lt;ApiScopeDto&gt;.</returns>
        public async Task<ApiScopeDto> GetApiScopeAsync(int scopeId)
        {
            var entity = await ApiResourceRepository.GetApiResourceScopeAsync(scopeId);
            return entity?.MapTo<ApiScopeDto>();
        }

        /// <summary>
        /// 添加Api许可范围
        /// </summary>
        /// <param name="request">许可范围</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CreateApiScopeAsync(ApiScopeCreateRequest request)
        {
            var apiResource = await ApiResourceRepository.FindAsync(request.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            var entity = request.MapTo<ApiScope>();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.CreateApiResourceScopeAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity.Id;
        }

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="dto">许可范围</param>
        /// <returns>Task.</returns>
        public async Task UpdateApiScopeAsync(ApiScopeDto dto)
        {
            var apiResource = await ApiResourceRepository.FindAsync(dto.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            var entity = dto.MapTo<ApiScope>();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.UpdateApiResourceScopeAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        public async Task DeleteApiScopeAsync(int scopeId)
        {
            await ApiResourceRepository.DeleteApiResourceScopeAsync(scopeId);
            await UnitOfWork.CommitAsync();
        }

        #endregion

        #region 密钥

        /// <summary>
        /// 哈希Api密钥
        /// </summary>
        /// <param name="request">密钥</param>
        private void HashApiSharedSecret(ApiSecretCreateRequest request)
        {
            if (request.Type != IdentityServerConstants.SecretTypes.SharedSecret)
            {
                return;
            }

            if (request.HashType == HashType.Sha256)
            {
                request.Value = request.Value.Sha256();
            }
            else if (request.HashType == HashType.Sha512)
            {
                request.Value = request.Value.Sha512();
            }
        }

        /// <summary>
        /// Api获取密钥
        /// </summary>
        /// <param name="apiResourceId">资源编号</param>
        /// <returns>Task&lt;List&lt;ApiSecretDto&gt;&gt;.</returns>
        public async Task<List<ApiSecretDto>> GetApiSecretsAsync(int apiResourceId)
        {
            var entities = await ApiResourceRepository.GetApiResourceSecretsAsync(apiResourceId);
            return entities?.MapToList<ApiSecretDto>();
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns>Task&lt;ApiSecretDto&gt;.</returns>
        public async Task<ApiSecretDto> GetApiSecretAsync(int secretId)
        {
            var entity = await ApiResourceRepository.GetApiResourceSecretAsync(secretId);
            return entity?.MapTo<ApiSecretDto>();
        }

        /// <summary>
        /// 添加Api密钥
        /// </summary>
        /// <param name="request">密钥</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CreateApiSecretAsync(ApiSecretCreateRequest request)
        {
            var apiResource = await ApiResourceRepository.FindAsync(request.ApiResourceId);
            apiResource.CheckNull(nameof(apiResource));
            HashApiSharedSecret(request);
            var entity = request.MapTo<ApiSecret>();
            entity.ApiResource = apiResource;
            await ApiResourceRepository.CreateApiResourceSecretAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity.Id;
        }

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        public async Task DeleteApiSecretAsync(int secretId)
        {
            await ApiResourceRepository.DeleteApiResourceSecretAsync(secretId);
            await UnitOfWork.CommitAsync();
        }

        #endregion
    }
}