using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Pos.Extensions;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Shared.Enums;
using KissU.Util.Datas.Ef.Core;

namespace KissU.Modules.GreatWall.Data.Repositories {
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public class IdentityResourceRepository : CompactRepositoryBase<IdentityResource, ResourcePo>, IIdentityResourceRepository {
        /// <summary>
        /// 资源存储器
        /// </summary>
        private readonly IResourcePoStore _store;

        /// <summary>
        /// 初始化身份资源仓储
        /// </summary>
        /// <param name="store">资源存储器</param>
        public IdentityResourceRepository( IResourcePoStore store ) : base( store ) {
            _store = store;
        }

        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override IdentityResource ToEntity( ResourcePo po ) {
            return po.ToIdentityResource();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourcePo ToPo( IdentityResource entity ) {
            return entity.ToPo();
        }

        /// <summary>
        /// 是否允许创建身份资源
        /// </summary>
        /// <param name="identityResource">身份资源</param>
        public async Task<bool> CanCreateAsync( IdentityResource identityResource ) {
            var exists = await _store.ExistsAsync( t => t.Uri == identityResource.Uri && t.Type == ResourceType.Identity );
            return exists == false;
        }

        /// <summary>
        /// 是否允许修改身份资源
        /// </summary>
        /// <param name="identityResource">身份资源</param>
        public async Task<bool> CanUpdateAsync( IdentityResource identityResource ) {
            var exists = await _store.ExistsAsync( t => t.Id != identityResource.Id && t.Uri == identityResource.Uri && t.Type == ResourceType.Identity );
            return exists == false;
        }

        /// <summary>
        /// 获取已启用的身份资源列表
        /// </summary>
        public async Task<List<IdentityResource>> GetEnabledResources() {
            var list = await _store.FindAllAsync( t => t.Type == ResourceType.Identity && t.Enabled );
            return list.Select( ToEntity ).ToList();
        }
    }
}