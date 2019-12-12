// <copyright file="IClientService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.IdentityServer.Service.Contracts.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
    using KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests;
    using KissU.Modules.IdentityServer.Service.Contracts.Queries;
    using Util.Applications;
    using Util.Applications.Aspects;
    using Util.Domains.Repositories;
    using Util.Validations.Aspects;

    /// <summary>
    /// 应用程序服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IClientService : IService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<ClientDto> GetByIdAsync(object id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<ClientDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<ClientDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<ClientDto>> QueryAsync(ClientQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<ClientDto>> PagerQueryAsync(ClientQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost(true)]
        [UnitOfWork]
        Task<string> CreateAsync([Valid] ClientCreateRequest request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut(true)]
        [UnitOfWork]
        Task UpdateAsync([Valid] ClientDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        /// 克隆应用程序
        /// </summary>
        /// <param name="request">克隆请求参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<Guid> CloneAsync(ClientCloneRequest request);

        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        Task<ClientDto> FindEnabledByCodeAsync(string clientCode);

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        Task<List<ClientClaimDto>> GetClaimsAsync(Guid clientId);

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        Task<ClientClaimDto> GetClientAsync(Guid id);

        /// <summary>
        /// 创建应用程序声明
        /// </summary>
        /// <param name="request">创建应用程序声明参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<Guid> CreateClaimAsync([Valid] ClientClaimCreateRequest request);

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="dto">应用程序声明</param>
        /// <returns></returns>
        [UnitOfWork]
        Task UpdateClaimAsync([Valid] ClientClaimDto dto);

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteClaimAsync(Guid id);

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        Task<List<ClientSecretDto>> GetSecretsAsync(Guid clientId);

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        Task<ClientSecretDto> GetSecretAsync(Guid id);

        /// <summary>
        /// 创建应用程序密钥
        /// </summary>
        /// <param name="request">创建应用程序密钥参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<Guid> CreateSecretAsync([Valid] ClientSecretCreateRequest request);

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteSecretAsync(Guid id);

        #endregion
    }
}
