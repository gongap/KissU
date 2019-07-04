using System;
using GreatWall.Systems.Domains.Models;

namespace GreatWall.Systems.Domains.Factories {
    /// <summary>
    /// 角色工厂
    /// </summary>
    public static class RoleFactory {
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="code">角色编码</param>
        /// <param name="name">角色名称</param>
        /// <param name="normalizedName">标准化角色名称</param>
        /// <param name="type">角色类型</param>
        /// <param name="isAdmin">管理员</param>
        /// <param name="parentId">父标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        /// <param name="sortId">排序号</param>
        /// <param name="enabled">启用</param>
        /// <param name="remark">备注</param>
        /// <param name="pinYin">拼音简码</param>
        /// <param name="sign">签名</param>
        /// <param name="creationTime">创建时间</param>
        /// <param name="creatorId">创建人编号</param>
        /// <param name="lastModificationTime">最后修改时间</param>
        /// <param name="lastModifierId">最后修改人编号</param>
        /// <param name="isDeleted">是否删除</param>
        /// <param name="version">版本号</param>
        public static Role Create( 
            Guid roleId,
            string code,
            string name,
            string normalizedName,
            string type,
            bool isAdmin,
            Guid? parentId,
            string path,
            int level,
            int? sortId,
            bool enabled,
            string remark,
            string pinYin,
            string sign,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            Role result;
            result = new Role( roleId );
            result.Code = code;
            result.Name = name;
            result.NormalizedName = normalizedName;
            result.Type = type;
            result.IsAdmin = isAdmin;
            result.ParentId = parentId;
            result.Path = path;
            result.Level = level;
            result.SortId = sortId;
            result.Enabled = enabled;
            result.Remark = remark;
            result.PinYin = pinYin;
            result.Sign = sign;
            result.CreationTime = creationTime;
            result.CreatorId = creatorId;
            result.LastModificationTime = lastModificationTime;
            result.LastModifierId = lastModifierId;
            result.IsDeleted = isDeleted;
            result.Version = version;
            return result;
        }
    }
}