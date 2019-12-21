// <copyright file="IClientService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Applications;
using KissU.Util.Applications.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.IdentityServer.Application.Abstractions
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IClientAppService : ICrudService<ClientDto, ClientDto, ClientCreateRequest, ClientDto, ClientQuery>
    {
        /// <summary>
        /// 克隆应用程序
        /// </summary>
        /// <param name="request">克隆请求参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<int> CloneAsync(ClientCloneRequest request);

        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientId">应用编码</param>
        /// <returns></returns>
        Task<ClientDto> FindEnabledByIdAsync(string clientId);

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        Task<List<ClientClaimDto>> GetClaimsAsync(int clientId);

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        Task<ClientClaimDto> GetClaimAsync(int id);

        /// <summary>
        /// 创建应用程序声明
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="request">创建应用程序声明参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<int> CreateClaimAsync(int clientId, [Valid] ClientClaimCreateRequest request);

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="dto">应用程序声明</param>
        /// <returns></returns>
        [UnitOfWork]
        Task UpdateClaimAsync(int clientId, [Valid] ClientClaimDto dto);

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteClaimAsync(int id);

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        Task<List<ClientSecretDto>> GetSecretsAsync(int clientId);

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        Task<ClientSecretDto> GetSecretAsync(int id);

        /// <summary>
        /// 创建应用程序密钥
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="request">创建应用程序密钥参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<int> CreateSecretAsync(int clientId, [Valid] ClientSecretCreateRequest request);

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteSecretAsync(int id);

        #endregion
    }
}
