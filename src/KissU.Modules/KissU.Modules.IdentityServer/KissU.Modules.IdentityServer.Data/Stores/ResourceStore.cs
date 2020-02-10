using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Util.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.IdentityServer.Data.Stores
{
    /// <summary>
    /// 资源存储
    /// </summary>
    public class ResourceStore : IResourceStore
    {
        private readonly IApiResourceRepository _apiResourcePoStore;
        private readonly IIdentityResourceRepository _identityResourcesPoStore;
        private readonly ILogger<ResourceStore> _logger;

        /// <summary>
        /// 初始化资源存储
        /// </summary>
        /// <param name="apiResourceRepository">Api资源仓储</param>
        /// <param name="identityResourceRepository">身份资源仓储</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">apiResourceRepository</exception>
        /// <exception cref="ArgumentNullException">identityResourceRepository</exception>
        public ResourceStore(IApiResourceRepository apiResourceRepository,
            IIdentityResourceRepository identityResourceRepository, ILogger<ResourceStore> logger)
        {
            _apiResourcePoStore =
                apiResourceRepository ?? throw new ArgumentNullException(nameof(apiResourceRepository));
            _identityResourcesPoStore = identityResourceRepository ??
                                        throw new ArgumentNullException(nameof(identityResourceRepository));
            _logger = logger;
        }

        /// <summary>
        /// 获取Api资源
        /// </summary>
        /// <param name="name">api名称</param>
        /// <returns>Task&lt;ApiResource&gt;.</returns>
        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var api = await _apiResourcePoStore.Find(p => p.Name == name)
                .Include(x => x.Scopes)
                .Include(x => x.ApiSecrets).ToListAsync();

            if (api != null)
            {
                _logger.LogDebug("Found {api} API resource in database", name);
            }
            else
            {
                _logger.LogDebug("Did not find {api} API resource in database", name);
            }

            return api?.MapTo<ApiResource>();
        }

        /// <summary>
        /// 获取Api资源
        /// </summary>
        /// <param name="scopeNames">授权许可名称</param>
        /// <returns>Task&lt;IEnumerable&lt;ApiResource&gt;&gt;.</returns>
        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var names = scopeNames.ToArray();

            var queryable = _apiResourcePoStore.Find(x => x.Scopes.Any(p => names.Contains(p.Name)))
                .Include(x => x.Scopes)
                .Include(x => x.ApiSecrets);

            var apiResources = await queryable.ToListAsync();

            var models = apiResources?.MapToList<ApiResource>().AsEnumerable();

            _logger.LogDebug("Found {scopes} API scopes in database", models.SelectMany(x => x.Scopes).Select(x => x.Name));

            return models;
        }

        /// <summary>
        /// 获取身份资源
        /// </summary>
        /// <param name="scopeNames">授权许可名称</param>
        /// <returns>Task&lt;IEnumerable&lt;IdentityResource&gt;&gt;.</returns>
        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(
            IEnumerable<string> scopeNames)
        {
            var scopes = scopeNames.ToArray();

            var identityResources = await _identityResourcesPoStore.Find(x => scopes.Contains(x.Name)).ToListAsync();

            var models = identityResources?.MapToList<IdentityResource>().AsEnumerable();

            _logger.LogDebug("Found {scopes} identity scopes in database", models.Select(x => x.Name));

            return models;
        }

        /// <summary>
        /// 获取所有Api/身份资源
        /// </summary>
        /// <returns>Task&lt;Resources&gt;.</returns>
        public async Task<Resources> GetAllResourcesAsync()
        {
            var identitys = await _identityResourcesPoStore.FindAllAsync();
            var apis = await _apiResourcePoStore.Find()
                .Include(x => x.Scopes)
                .Include(x => x.ApiSecrets).ToListAsync();
            var result = new Resources(identitys?.MapToList<IdentityResource>(), apis?.MapToList<ApiResource>());

            _logger.LogDebug("Found {scopes} as all scopes in database", result.IdentityResources.Select(x => x.Name).Union(result.ApiResources.SelectMany(x => x.Scopes).Select(x => x.Name)));

            return result;
        }
    }
}