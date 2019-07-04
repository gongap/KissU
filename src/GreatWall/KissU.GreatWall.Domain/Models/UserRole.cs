using System;

namespace GreatWall.Domain.Models {
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRole {
        /// <summary>
        /// 初始化用户角色
        /// </summary>
        public UserRole() {
        }

        /// <summary>
        /// 初始化用户角色
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="roleId">角色标识</param>
        public UserRole( Guid userId, Guid roleId ) {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// 用户标识
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色标识
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
