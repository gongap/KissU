using System;
using KissU.Modules.QuickStart.Domain.Models;

namespace KissU.Modules.QuickStart.Domain.Factories {
    /// <summary>
    /// 租户工厂
    /// </summary>
    public static class TenantFactory {
        /// <summary>
        /// 创建租户
        /// </summary>
        /// <param name="clientId">租户编号</param>
        /// <param name="code">租户编码</param>
        /// <param name="name">租户名称</param>
        /// <param name="comment">备注</param>
        /// <param name="enabled">启用</param>
        /// <param name="creationTime">创建时间</param>
        /// <param name="creatorId">创建人编号</param>
        /// <param name="lastModificationTime">最后修改时间</param>
        /// <param name="lastModifierId">最后修改人编号</param>
        /// <param name="isDeleted">是否删除</param>
        /// <param name="version">版本号</param>
        public static Tenant Create( 
            Guid clientId,
            string code,
            string name,
            string comment,
            bool enabled,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            Tenant result;
            result = new Tenant( clientId );
            result.Code = code;
            result.Name = name;
            result.Comment = comment;
            result.Enabled = enabled;
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