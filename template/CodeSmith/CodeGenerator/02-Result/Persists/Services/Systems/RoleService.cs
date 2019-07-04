using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using GreatWall.Data;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;
using GreatWall.Service.Abstractions.Systems;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;

namespace GreatWall.Service.Implements.Systems {
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : TreeServiceBase<RolePo, RoleDto, RoleQuery>, IRoleService {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleStore">角色存储器</param>
        public RoleService( IKissU.GreatWallUnitOfWork unitOfWork, IRolePoStore roleStore )
            : base( unitOfWork, roleStore ) {
            RoleStore = roleStore;
        }
        
        /// <summary>
        /// 角色存储器
        /// </summary>
        public IRolePoStore RoleStore { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<RolePo> CreateQuery( RoleQuery param ) {
            return new Query<RolePo>( param );
        }
    }
}