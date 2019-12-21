// <copyright file="ClientService.cs" company="KissU">
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
using Client = KissU.Modules.IdentityServer.Domain.Models.Client;
using Extensions = KissU.Modules.IdentityServer.Domain.Shared.Extensions;
using GrantTypes = KissU.Modules.IdentityServer.Domain.Shared.GrantTypes;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ClientService :
        CrudServiceBase<Client, ClientDto, ClientDto, ClientCreateRequest, ClientDto, ClientQuery, Guid>, IClientService
    {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="clientRepository">应用程序仓储</param>
        public ClientService(IIdentityServerUnitOfWork unitOfWork, IClientRepository clientRepository)
            : base(unitOfWork, clientRepository)
        {
            ClientRepository = clientRepository;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IClientRepository ClientRepository { get; set; }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 克隆应用程序
        /// </summary>
        /// <param name="request">克隆请求参数</param>
        /// <returns></returns>
        public async Task<Guid> CloneAsync(ClientCloneRequest request)
        {
            var client = await ClientRepository.FindByIdNoTrackingAsync(request.ClientId);
            client.CheckNull(nameof(client));

            var exist = await ClientRepository.ExistsAsync(x => x.ClientId == request.ClientCodeOriginal);
            if (exist)
            {
                ThrowDuplicateCodeException(request.ClientCodeOriginal);
            }

            var clientDto = client.MapTo<ClientDto>();
            clientDto.Id = Guid.NewGuid().ToString();
            var clientToClone = clientDto.MapTo<Client>();

            clientToClone.ClientId = request.ClientCodeOriginal;
            clientToClone.ClientName = request.ClientNameOriginal;

            clientToClone.ClientSecrets.Clear();

            if (!request.CloneClientCorsOrigins)
            {
                clientToClone.AllowedCorsOrigins.Clear();
            }

            if (!request.CloneClientGrantTypes)
            {
                clientToClone.AllowedGrantTypes.Clear();
            }

            if (!request.CloneClientIdPRestrictions)
            {
                clientToClone.IdentityProviderRestrictions.Clear();
            }

            if (!request.CloneClientPostLogoutRedirectUris)
            {
                clientToClone.PostLogoutRedirectUris.Clear();
            }

            if (!request.CloneClientScopes)
            {
                clientToClone.AllowedScopes.Clear();
            }

            if (!request.CloneClientRedirectUris)
            {
                clientToClone.RedirectUris.Clear();
            }

            await ClientRepository.AddAsync(clientToClone);

            return clientToClone.Id;
        }

        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        public async Task<ClientDto> FindEnabledByCodeAsync(string clientCode)
        {
            var client = await ClientRepository.FindEnabledClientByCodeAsync(clientCode);
            return client.MapTo<ClientDto>();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        protected override IQueryBase<Client> CreateQuery(ClientQuery param)
        {
            var query = new Query<Client>(param).Or(t => t.ClientId.Contains(param.Keyword),
                t => t.ClientName.Contains(param.Keyword));

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
        protected override void CreateBefore(Client entity)
        {
            base.CreateBefore(entity);
            if (ClientRepository.Exists(t => t.ClientId == entity.ClientId))
            {
                ThrowDuplicateCodeException(entity.ClientId);
            }
        }

        /// <summary>
        /// 创建参数转换为实体
        /// </summary>
        /// <param name="request">创建参数</param>
        protected override Client ToEntityFromCreateRequest(ClientCreateRequest request)
        {
            var client = base.ToEntityFromCreateRequest(request);
            PrepareClientTypeForNewClient(request, client);
            return client;
        }

        /// <summary>
        /// 新增应用初始化
        /// </summary>
        /// <param name="request"></param>
        /// <param name="client"></param>
        private void PrepareClientTypeForNewClient(ClientCreateRequest request, Client client)
        {
            switch (request.ClientType)
            {
                case ClientType.Empty:
                    break;
                case ClientType.WebImplicit:
                    client.AllowedGrantTypes = GrantTypes.Implicit.Select(x => new ClientGrantType(x)).ToList();
                    client.AllowAccessTokensViaBrowser = true;
                    break;
                case ClientType.WebHybrid:
                    client.AllowedGrantTypes = GrantTypes.Hybrid.Select(x => new ClientGrantType(x)).ToList();
                    break;
                case ClientType.Spa:
                    client.AllowedGrantTypes = GrantTypes.Implicit.Select(x => new ClientGrantType(x)).ToList();
                    client.AllowAccessTokensViaBrowser = true;
                    break;
                case ClientType.Native:
                    client.AllowedGrantTypes = GrantTypes.Hybrid.Select(x => new ClientGrantType(x)).ToList();
                    break;
                case ClientType.Machine:
                    client.AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials.Select(x => new ClientGrantType(x)).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 抛出重复异常
        /// </summary>
        private void ThrowDuplicateCodeException(string code)
        {
            throw new Warning(string.Format("编码 {0} 重复", code));
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<Client> Filter(IQueryable<Client> queryable, ClientQuery parameter)
        {
            return base.Filter(queryable, parameter);
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore(Client entity)
        {
            base.UpdateBefore(entity);
            if (ClientRepository.Exists(t => t.Id != entity.Id && t.ClientId == entity.ClientId))
            {
                ThrowDuplicateCodeException(entity.ClientId);
            }
        }

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        public async Task<List<ClientClaimDto>> GetClaimsAsync(Guid clientId)
        {
            var entities = await ClientRepository.GetClientClaimsAsync(clientId);
            return entities?.MapToList<ClientClaimDto>();
        }

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="dto">应用程序声明</param>
        /// <returns></returns>
        public async Task UpdateClaimAsync(ClientClaimDto dto)
        {
            var client = await ClientRepository.FindAsync(dto.ClientId);
            client.CheckNull(nameof(client));
            var entity = dto.MapTo<ClientClaim>();
            entity.Client = client;
            await ClientRepository.UpdateClientClaimAsync(entity);
        }

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        public async Task<ClientClaimDto> GetClientAsync(Guid id)
        {
            var entity = await ClientRepository.GetClientClaimAsync(id);
            return entity?.MapTo<ClientClaimDto>();
        }

        /// <summary>
        /// 添加应用程序声明
        /// </summary>
        /// <param name="request">应用程序声明</param>
        /// <returns></returns>
        public async Task<Guid> CreateClaimAsync(ClientClaimCreateRequest request)
        {
            var client = await ClientRepository.FindAsync(request.ClientId);
            client.CheckNull(nameof(client));
            var entity = request.MapTo<ClientClaim>();
            entity.Init();
            entity.Client = client;
            await ClientRepository.CreateClientClaimAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns></returns>
        public async Task DeleteClaimAsync(Guid id)
        {
            await ClientRepository.DeleteClientClaimAsync(id);
        }

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 哈希应用程序密钥
        /// </summary>
        /// <param name="request">应用程序密钥</param>
        private void HashApiSharedSecret(ClientSecretCreateRequest request)
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
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns></returns>
        public async Task<List<ClientSecretDto>> GetSecretsAsync(Guid clientId)
        {
            var entities = await ClientRepository.GetClientSecretsAsync(clientId);
            return entities?.MapToList<ClientSecretDto>();
        }

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        public async Task<ClientSecretDto> GetSecretAsync(Guid id)
        {
            var entity = await ClientRepository.GetClientSecretAsync(id);
            return entity?.MapTo<ClientSecretDto>();
        }

        /// <summary>
        /// 添加应用程序密钥
        /// </summary>
        /// <param name="request">应用程序密钥</param>
        /// <returns></returns>
        public async Task<Guid> CreateSecretAsync(ClientSecretCreateRequest request)
        {
            var client = await ClientRepository.FindAsync(request.ClientId);
            client.CheckNull(nameof(client));
            HashApiSharedSecret(request);
            var entity = request.MapTo<ClientSecret>();
            entity.Init();
            entity.Client = client;
            await ClientRepository.CreateClientSecretAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns></returns>
        public async Task DeleteSecretAsync(Guid id)
        {
            await ClientRepository.DeleteClientSecretAsync(id);
        }

        #endregion
    }
}
