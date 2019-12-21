// <copyright file="ClientService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Abstractions;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Modules.IdentityServer.Service.Contracts;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Service
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IClientAppService _appService;

        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="appService">应用服务</param>
        public ClientService(IClientAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<ClientDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<ClientDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<ClientDto>> QueryAsync(ClientQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<ClientDto>> PagerQueryAsync(ClientQuery parameter)
        {
            return await _appService.PagerQueryAsync(parameter);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        public async Task<string> CreateAsync(ClientCreateRequest request)
        {
            return await _appService.CreateAsync(request);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public async Task UpdateAsync(ClientDto request)
        {
            await _appService.UpdateAsync(request);
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
        /// 克隆应用程序
        /// </summary>
        /// <param name="request">克隆请求参数</param>
        /// <returns></returns>
        public async Task<Guid> CloneAsync(ClientCloneRequest request)
        {
            return await _appService.CloneAsync(request);
        }

        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        public async Task<ClientDto> FindEnabledByCodeAsync(string clientCode)
        {
            return await _appService.FindEnabledByCodeAsync(clientCode);
        }

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        public async Task<List<ClientClaimDto>> GetClaimsAsync(Guid clientId)
        {
            return await _appService.GetClaimsAsync(clientId);
        }

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="dto">应用程序声明</param>
        /// <returns></returns>
        public async Task UpdateClaimAsync(ClientClaimDto dto)
        {
            await _appService.UpdateClaimAsync(dto);
        }

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        public async Task<ClientClaimDto> GetClaimAsync(Guid id)
        {
            return await _appService.GetClaimAsync(id);
        }

        /// <summary>
        /// 添加应用程序声明
        /// </summary>
        /// <param name="request">应用程序声明</param>
        /// <returns></returns>
        public async Task<Guid> CreateClaimAsync(ClientClaimCreateRequest request)
        {
            return await _appService.CreateClaimAsync(request);
        }

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        public async Task DeleteClaimAsync(Guid id)
        {
            await _appService.DeleteClaimAsync(id);
        }

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        public async Task<List<ClientSecretDto>> GetSecretsAsync(Guid clientId)
        {
            return await _appService.GetSecretsAsync(clientId);
        }

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        public async Task<ClientSecretDto> GetSecretAsync(Guid id)
        {
            return await _appService.GetSecretAsync(id);
        }

        /// <summary>
        /// 添加应用程序密钥
        /// </summary>
        /// <param name="request">应用程序密钥</param>
        /// <returns></returns>
        public async Task<Guid> CreateSecretAsync(ClientSecretCreateRequest request)
        {
            return await _appService.CreateSecretAsync(request);
        }

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        public async Task DeleteSecretAsync(Guid id)
        {
            await _appService.DeleteSecretAsync(id);
        }

        #endregion
    }
}
