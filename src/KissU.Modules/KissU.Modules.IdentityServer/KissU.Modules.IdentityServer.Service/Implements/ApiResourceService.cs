using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Abstractions;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Modules.IdentityServer.Service.Contracts;
using KissU.Util;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// 资源服务
    /// </summary>
    public class ApiResourceService : IApiResourceService
    {
        private readonly IApiResourceAppService _appService;

        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="appService">应用服务</param>
        public ApiResourceService(IApiResourceAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
            await _appService.DeleteAsync(ids);
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;ApiResourceDto&gt;.</returns>
        public Task<ApiResourceDto> GetByIdAsync(int id)
        {
            return _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;ApiResourceDto&gt;&gt;.</returns>
        public async Task<List<ApiResourceDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;ApiResourceDto&gt;&gt;.</returns>
        public async Task<List<ApiResourceDto>> QueryAsync(ApiResourceQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;ApiResourceDto&gt;&gt;.</returns>
        public async Task<PagerList<ApiResourceDto>> PagerQueryAsync(ApiResourceQuery parameter)
        {
            return await _appService.PagerQueryAsync(parameter);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> CreateAsync(ApiResourceCreateRequest request)
        {
            return await _appService.CreateAsync(request);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public async Task UpdateAsync(ApiResourceDto request)
        {
            await _appService.UpdateAsync(request);
        }

        #region 许可范围

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns>Task&lt;List&lt;ApiScopeDto&gt;&gt;.</returns>
        public async Task<List<ApiScopeDto>> GetScopesAsync(string id)
        {
            return await _appService.GetApiScopesAsync(id.ToInt());
        }

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns>Task&lt;ApiScopeDto&gt;.</returns>
        public async Task<ApiScopeDto> GetScopeAsync(string scopeId)
        {
            return await _appService.GetApiScopeAsync(scopeId.ToInt());
        }

        /// <summary>
        /// 添加许可范围
        /// </summary>
        /// <param name="request">许可范围</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CreateScopeAsync(ApiScopeCreateRequest request)
        {
            return await _appService.CreateApiScopeAsync(request);
        }

        /// <summary>
        /// 更新许可范围
        /// </summary>
        /// <param name="dto">许可范围</param>
        public async Task UpdateScopeAsync(ApiScopeDto dto)
        {
            await _appService.UpdateApiScopeAsync(dto);
        }

        /// <summary>
        /// 删除许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        public async Task DeleteScopeAsync(string scopeId)
        {
            await _appService.DeleteApiScopeAsync(scopeId.ToInt());
        }

        #endregion

        #region 密钥

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns>Task&lt;List&lt;ApiSecretDto&gt;&gt;.</returns>
        public async Task<List<ApiSecretDto>> GetSecretsAsync(string id)
        {
            return await _appService.GetApiSecretsAsync(id.ToInt());
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns>Task&lt;ApiSecretDto&gt;.</returns>
        public async Task<ApiSecretDto> GetSecretAsync(string secretId)
        {
            return await _appService.GetApiSecretAsync(secretId.ToInt());
        }

        /// <summary>
        /// 添加密钥
        /// </summary>
        /// <param name="request">密钥</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CreateSecretAsync(ApiSecretCreateRequest request)
        {
            return await _appService.CreateApiSecretAsync(request);
        }

        /// <summary>
        /// 删除密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        public async Task DeleteSecretAsync(string secretId)
        {
            await _appService.DeleteApiSecretAsync(secretId.ToInt());
        }

        #endregion
    }
}