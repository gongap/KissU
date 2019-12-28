﻿// <copyright file="IClientRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain.Models;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IClientRepository : IRepository<Client, int>
    {
        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientId">应用编号</param>
        /// <returns></returns>
        Task<Client> FindEnabledClientByIdAsync(string clientId);

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        Task<List<ClientClaim>> GetClientClaimsAsync(int clientId);

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        Task<ClientClaim> GetClientClaimAsync(int id);

        /// <summary>
        /// 创建应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        /// <returns></returns>
        Task CreateClientClaimAsync([Valid] ClientClaim entity);

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        /// <returns></returns>
        Task UpdateClientClaimAsync([Valid] ClientClaim entity);

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明</param>
        /// <returns></returns>
        Task DeleteClientClaimAsync(int id);

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        Task<List<ClientSecret>> GetClientSecretsAsync(int clientId);

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        Task<ClientSecret> GetClientSecretAsync(int id);

        /// <summary>
        /// 创建应用程序密钥
        /// </summary>
        /// <param name="entity">应用程序密钥</param>
        /// <returns></returns>
        Task CreateClientSecretAsync([Valid] ClientSecret entity);

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥</param>
        /// <returns></returns>
        Task DeleteClientSecretAsync(int id);

        #endregion
    }
}