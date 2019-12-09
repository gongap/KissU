// <copyright file="ResourceStore.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Stores
{
    using System.Linq;
    using IdentityServer4.Models;
    using IdentityServer4.Stores;
    using KissU.Modules.IdentityServer.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Util.Maps;

    /// <summary>
    /// 资源存储
    /// </summary>
    public class ResourceStore : IResourceStore
    {
        private readonly IApiResourceRepository _apiResourcePoStore;
        private readonly IIdentityResourceRepository _identityResourcesPoStore;

        /// <summary>
        /// 初始化资源存储
        /// </summary>
        /// <param name="apiResourceRepository">Api资源仓储</param>
        /// <param name="identityResourceRepository">身份资源仓储</param>
        public ResourceStore(IApiResourceRepository apiResourceRepository,
            IIdentityResourceRepository identityResourceRepository)
        {
            _apiResourcePoStore =
                apiResourceRepository ?? throw new ArgumentNullException(nameof(apiResourceRepository));
            _identityResourcesPoStore = identityResourceRepository ??
                                        throw new ArgumentNullException(nameof(identityResourceRepository));
        }

        /// <summary>
        /// 获取Api资源
        /// </summary>
        /// <param name="name">api名称</param>
        /// <returns></returns>
        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var apiResource = await _apiResourcePoStore.Find(p => p.Name == name)
                .Include(x => x.Scopes)
                .Include(x => x.Secrets).ToListAsync();

            var model = apiResource?.MapTo<ApiResource>();

            return model;
        }

        /// <summary>
        /// 获取Api资源
        /// </summary>
        /// <param name="scopeNames">授权许可名称</param>
        /// <returns></returns>
        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var names = Enumerable.ToArray<string>(scopeNames);

            var queryable = _apiResourcePoStore.Find(x => x.Scopes.Any(p => names.Contains(p.Name)))
                .Include(x => x.Scopes)
                .Include(x => x.Secrets);

            var apiResources = await queryable.ToListAsync();

            var models = apiResources?.MapToList<ApiResource>().AsEnumerable();

            return models;
        }

        /// <summary>
        /// 获取身份资源
        /// </summary>
        /// <param name="scopeNames">授权许可名称</param>
        /// <returns></returns>
        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(
            IEnumerable<string> scopeNames)
        {
            var scopes = Enumerable.ToArray<string>(scopeNames);

            var identityResources = await _identityResourcesPoStore.Find(x => scopes.Contains(x.Name)).ToListAsync();

            var models = identityResources?.MapToList<IdentityResource>().AsEnumerable();

            return models;
        }

        /// <summary>
        /// 获取所有Api/身份资源
        /// </summary>
        /// <returns></returns>
        public async Task<Resources> GetAllResourcesAsync()
        {
            var identitys = await _identityResourcesPoStore.FindAllAsync();
            var apis = await _apiResourcePoStore.Find()
                .Include(x => x.Scopes)
                .Include(x => x.Secrets).ToListAsync();
            var result = new Resources(identitys?.MapToList<IdentityResource>(), apis?.MapToList<ApiResource>());
            return result;
        }
    }
}
