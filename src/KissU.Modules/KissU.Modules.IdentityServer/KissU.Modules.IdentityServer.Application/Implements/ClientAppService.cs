﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using KissU.Core;
using KissU.Core.Exceptions;
using KissU.Core.Maps;
using KissU.Modules.IdentityServer.Application.Contracts.Abstractions;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.Shared;
using KissU.Modules.IdentityServer.Domain.Shared.Enums;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Ddd.Application;
using KissU.Util.Ddd.Domain.Datas.Queries;
using KissU.Util.Ddd.Domain.Domains.Repositories;
using Ids4 = IdentityServer4.Models;

namespace KissU.Modules.IdentityServer.Application.Implements
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ClientAppService :
        CrudServiceBase<Client, ClientDto, ClientDto, ClientCreateRequest, ClientDto, ClientQuery, int>,
        IClientAppService
    {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="clientRepository">应用程序仓储</param>
        public ClientAppService(IIdentityServerUnitOfWork unitOfWork, IClientRepository clientRepository)
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
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CloneAsync(ClientCloneRequest request)
        {
            var client = await ClientRepository.FindEnabledClientByIdAsync(request.ClientId);
            client.CheckNull(nameof(client));

            var exist = await ClientRepository.ExistsAsync(x => x.ClientId == request.ClientIdOriginal);
            if (exist)
            {
                ThrowDuplicateCodeException(request.ClientIdOriginal);
            }

            var clientDto = client.MapTo<ClientDto>();
            var clientToClone = clientDto.MapTo<Client>();

            clientToClone.ClientId = request.ClientIdOriginal;
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
        /// <param name="clientId">应用编码</param>
        /// <returns>Task&lt;ClientDto&gt;.</returns>
        public async Task<ClientDto> FindEnabledByIdAsync(string clientId)
        {
            var client = await ClientRepository.FindEnabledClientByIdAsync(clientId);
            return client.MapTo<ClientDto>();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        public override async Task UpdateAsync(ClientDto request)
        {
            await base.UpdateAsync(request);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        /// <returns>IQueryBase&lt;Client&gt;.</returns>
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
                query.OrderBy(x => x.Id, true);
            }

            return query;
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void CreateBefore(Client entity)
        {
            if (ClientRepository.Exists(t => t.ClientId == entity.ClientId))
            {
                ThrowDuplicateCodeException(entity.ClientId);
            }
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        protected override async Task CreateAfterAsync(Client entity)
        {
            await base.CreateAfterAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建参数转换为实体
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>结果</returns>
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
                    client.AllowedGrantTypes = Ids4.GrantTypes.Implicit.Select(x => new ClientGrantType(x)).ToList();
                    client.AllowAccessTokensViaBrowser = true;
                    break;
                case ClientType.WebHybrid:
                    client.AllowedGrantTypes = Ids4.GrantTypes.Hybrid.Select(x => new ClientGrantType(x)).ToList();
                    break;
                case ClientType.Spa:
                    client.AllowedGrantTypes = Ids4.GrantTypes.Implicit.Select(x => new ClientGrantType(x)).ToList();
                    client.AllowAccessTokensViaBrowser = true;
                    break;
                case ClientType.Native:
                    client.AllowedGrantTypes = Ids4.GrantTypes.Hybrid.Select(x => new ClientGrantType(x)).ToList();
                    break;
                case ClientType.Machine:
                    client.AllowedGrantTypes = Ids4.GrantTypes.ResourceOwnerPasswordAndClientCredentials
                        .Select(x => new ClientGrantType(x)).ToList();
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
        /// 修改前操作
        /// </summary>
        /// <param name="entity">实体</param>
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
        /// <returns>Task&lt;List&lt;ClientClaimDto&gt;&gt;.</returns>
        public async Task<List<ClientClaimDto>> GetClaimsAsync(int clientId)
        {
            var entities = await ClientRepository.GetClientClaimsAsync(clientId);
            return entities?.MapToList<ClientClaimDto>();
        }

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="dto">应用程序声明</param>
        /// <returns>Task.</returns>
        public async Task UpdateClaimAsync(int clientId, ClientClaimDto dto)
        {
            var client = await ClientRepository.FindAsync(clientId);
            client.CheckNull(nameof(client));
            var entity = dto.MapTo<ClientClaim>();
            entity.Client = client;
            await ClientRepository.UpdateClientClaimAsync(entity);
        }

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns>Task&lt;ClientClaimDto&gt;.</returns>
        public async Task<ClientClaimDto> GetClaimAsync(int id)
        {
            var entity = await ClientRepository.GetClientClaimAsync(id);
            return entity?.MapTo<ClientClaimDto>();
        }

        /// <summary>
        /// 添加应用程序声明
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="request">应用程序声明</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CreateClaimAsync(int clientId, ClientClaimCreateRequest request)
        {
            var client = await ClientRepository.FindAsync(clientId);
            client.CheckNull(nameof(client));
            var entity = request.MapTo<ClientClaim>();
            entity.Client = client;
            await ClientRepository.CreateClientClaimAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns>Task.</returns>
        public async Task DeleteClaimAsync(int id)
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
                request.Value = request.Value.Sha256();
            }
            else if (request.HashType == HashType.Sha512)
            {
                request.Value = request.Value.Sha512();
            }
        }

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns>Task&lt;List&lt;ClientSecretDto&gt;&gt;.</returns>
        public async Task<List<ClientSecretDto>> GetSecretsAsync(int clientId)
        {
            var entities = await ClientRepository.GetClientSecretsAsync(clientId);
            return entities?.MapToList<ClientSecretDto>();
        }

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns>Task&lt;ClientSecretDto&gt;.</returns>
        public async Task<ClientSecretDto> GetSecretAsync(int id)
        {
            var entity = await ClientRepository.GetClientSecretAsync(id);
            return entity?.MapTo<ClientSecretDto>();
        }

        /// <summary>
        /// 添加应用程序密钥
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="request">应用程序密钥</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CreateSecretAsync(int clientId, ClientSecretCreateRequest request)
        {
            var client = await ClientRepository.FindAsync(clientId);
            client.CheckNull(nameof(client));
            HashApiSharedSecret(request);
            var entity = request.MapTo<ClientSecret>();
            entity.Client = client;
            await ClientRepository.CreateClientSecretAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        public async Task DeleteSecretAsync(int id)
        {
            await ClientRepository.DeleteClientSecretAsync(id);
        }

        #endregion
    }
}