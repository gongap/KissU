using System;
using System.Linq;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : IRepository<User> {
        /// <summary>
        /// 过滤角色
        /// </summary>
        /// <param name="queryable">查询对象</param>
        /// <param name="roleId">角色标识</param>
        /// <param name="except">是否排除该角色的用户列表</param>
        IQueryable<User> FilterByRole( IQueryable<User> queryable, Guid roleId, bool except = false );
    }
}