using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Pos.Extensions;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Enums;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Util.Datas.Ef.Core;

namespace KissU.Modules.GreatWall.Data.Repositories
{
    /// <summary>
    /// Api资源仓储
    /// </summary>
    public class ApiResourceRepository : CompactRepositoryBase<ApiResource, ResourcePo>, IApiResourceRepository
    {
        /// <summary>
        /// 资源存储器
        /// </summary>
        private readonly IResourcePoStore _store;

        /// <summary>
        /// 初始化Api资源仓储
        /// </summary>
        /// <param name="store">资源存储器</param>
        public ApiResourceRepository(IResourcePoStore store) : base(store)
        {
            _store = store;
        }

        /// <summary>
        /// 是否允许创建资源
        /// </summary>
        /// <param name="resource">资源</param>
        public async Task<bool> CanCreateAsync(ApiResource resource)
        {
            var exists = await _store.ExistsAsync(t => t.Uri == resource.Uri && t.Type == ResourceType.Api);
            return exists == false;
        }

        /// <summary>
        /// 是否允许修改资源
        /// </summary>
        /// <param name="resource">资源</param>
        public async Task<bool> CanUpdateAsync(ApiResource resource)
        {
            var exists = await _store.ExistsAsync(t =>
                t.Id != resource.Id && t.Uri == resource.Uri && t.Type == ResourceType.Api);
            return exists == false;
        }

        /// <summary>
        /// 获取已启用的Api资源列表
        /// </summary>
        public async Task<List<ApiResource>> GetEnabledResources()
        {
            var list = await _store.FindAllAsync(t => t.Type == ResourceType.Api && t.Enabled);
            return list.Select(ToEntity).ToList();
        }

        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override ApiResource ToEntity(ResourcePo po)
        {
            return po.ToApiResource();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourcePo ToPo(ApiResource entity)
        {
            return entity.ToPo();
        }
    }
}