using System;
using System.Threading.Tasks;
using GreatWall.Data.Pos;
using GreatWall.Data.Pos.Extensions;
using GreatWall.Data.Stores.Abstractions;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Util;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories {
    /// <summary>
    /// 模块仓储
    /// </summary>
    public class ModuleRepository : TreeCompactRepositoryBase<Module, ResourcePo>, IModuleRepository {
        /// <summary>
        /// 资源存储器
        /// </summary>
        private readonly IResourcePoStore _store;

        /// <summary>
        /// 初始化模块仓储
        /// </summary>
        /// <param name="store">资源存储器</param>
        public ModuleRepository( IResourcePoStore store ) : base( store ) {
            _store = store;
        }

        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Module ToEntity( ResourcePo po ) {
            return po.ToModule();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourcePo ToPo( Module entity ) {
            return entity.ToPo();
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="parentId">父标识</param>
        public async Task<int> GenerateSortIdAsync( Guid applicationId, Guid? parentId ) {
            var maxSortId = await _store.Find( t => t.ApplicationId == applicationId && t.ParentId == parentId ).MaxAsync( t => t.SortId );
            return maxSortId.SafeValue() + 1;
        }
    }
}