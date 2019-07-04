using System;
using KissU.GreatWall.Systems.Domains.Models;

namespace KissU.GreatWall.Systems.Domains.Factories {
    /// <summary>
    /// Api许可范围工厂
    /// </summary>
    public static class ApiScopeFactory {
        /// <summary>
        /// 创建Api许可范围
        /// </summary>
        /// <param name="apiScopeId"></param>
        /// <param name="apiId">Api资源标识</param>
        /// <param name="name">名称</param>
        /// <param name="displayName">显示名</param>
        /// <param name="description">描述</param>
        /// <param name="claimTypes">声明类型</param>
        /// <param name="required">是否必选</param>
        /// <param name="emphasize">是否强调</param>
        /// <param name="showInDiscoveryDocument">是否显示在发现文档中</param>
        /// <param name="creationTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="lastModificationTime"></param>
        /// <param name="lastModifierId"></param>
        /// <param name="isDeleted"></param>
        public static ApiScope Create( 
            Guid apiScopeId,
            Guid apiId,
            string name,
            string displayName,
            string description,
            string claimTypes,
            bool required,
            bool emphasize,
            bool showInDiscoveryDocument,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted
        ) {
            ApiScope result;
            result = new ApiScope( apiScopeId );
            result.ApiId = apiId;
            result.Name = name;
            result.DisplayName = displayName;
            result.Description = description;
            result.ClaimTypes = claimTypes;
            result.Required = required;
            result.Emphasize = emphasize;
            result.ShowInDiscoveryDocument = showInDiscoveryDocument;
            result.CreationTime = creationTime;
            result.CreatorId = creatorId;
            result.LastModificationTime = lastModificationTime;
            result.LastModifierId = lastModifierId;
            result.IsDeleted = isDeleted;
            return result;
        }
    }
}