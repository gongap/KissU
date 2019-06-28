using System;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Factories {
    /// <summary>
    /// Api资源工厂
    /// </summary>
    public static class ApiFactory {
        /// <summary>
        /// 创建Api资源
        /// </summary>
        /// <param name="apiId"></param>
        /// <param name="name">名称</param>
        /// <param name="displayName">显示名</param>
        /// <param name="description">描述</param>
        /// <param name="claimTypes">声明类型</param>
        /// <param name="enabled">是否启用</param>
        /// <param name="creationTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="lastModificationTime"></param>
        /// <param name="lastModifierId"></param>
        /// <param name="isDeleted"></param>
        /// <param name="version"></param>
        public static Api Create( 
            Guid apiId,
            string name,
            string displayName,
            string description,
            string claimTypes,
            bool enabled,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            Byte[] version
        ) {
            Api result;
            result = new Api( apiId );
            result.Name = name;
            result.DisplayName = displayName;
            result.Description = description;
            result.ClaimTypes = claimTypes;
            result.CreationTime = creationTime;
            result.CreatorId = creatorId;
            result.LastModificationTime = lastModificationTime;
            result.LastModifierId = lastModifierId;
            result.Version = version;
            return result;
        }
    }
}