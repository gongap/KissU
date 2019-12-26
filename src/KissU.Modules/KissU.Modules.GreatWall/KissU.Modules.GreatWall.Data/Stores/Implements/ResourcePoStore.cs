using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Shared.Enums;
using KissU.Util.Datas.Ef.Core;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.GreatWall.Data.Stores.Implements {
    /// <summary>
    /// 资源存储器
    /// </summary>
    public class ResourcePoStore : StoreBase<ResourcePo>, IResourcePoStore {
        /// <summary>
        /// 初始化资源存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourcePoStore( IGreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleIds">角色标识列表</param>
        public async Task<List<ResourcePo>> GetModulesAsync( Guid applicationId, List<Guid> roleIds ) {
            if( applicationId == Guid.Empty || roleIds == null || roleIds.Count == 0 )
                return new List<ResourcePo>();
            var result = await ( from module in Set
                                 join permission in UnitOfWork.Set<Permission>() on module.Id equals permission.ResourceId
                                 where module.Type == ResourceType.Module &&
                                       module.ApplicationId == applicationId &&
                                       module.Enabled &&
                                       roleIds.Contains( permission.RoleId ) &&
                                       permission.IsDeny == false
                                 select module ).ToListAsync();
            return result.Distinct().OrderBy( t => t.SortId ).ToList();
        }
    }
}