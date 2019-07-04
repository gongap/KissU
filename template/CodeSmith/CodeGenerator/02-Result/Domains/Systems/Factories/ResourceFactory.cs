using System;
using KissU.GreatWall.Systems.Domains.Models;

namespace KissU.GreatWall.Systems.Domains.Factories {
    /// <summary>
    /// 资源工厂
    /// </summary>
    public static class ResourceFactory {
        /// <summary>
        /// 创建资源
        /// </summary>
        /// <param name="resourceId">资源标识</param>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="uri">资源标识</param>
        /// <param name="name">资源名称</param>
        /// <param name="type">资源类型</param>
        /// <param name="parentId">父标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        /// <param name="remark">备注</param>
        /// <param name="pinYin">拼音简码</param>
        /// <param name="enabled">启用</param>
        /// <param name="sortId">排序号</param>
        /// <param name="extend">扩展</param>
        /// <param name="creationTime">创建时间</param>
        /// <param name="creatorId">创建人编号</param>
        /// <param name="lastModificationTime">最后修改时间</param>
        /// <param name="lastModifierId">最后修改人编号</param>
        /// <param name="isDeleted">是否删除</param>
        /// <param name="version">版本号</param>
        public static Resource Create( 
            Guid resourceId,
            Guid? applicationId,
            string uri,
            string name,
            int type,
            Guid? parentId,
            string path,
            int? level,
            string remark,
            string pinYin,
            bool enabled,
            int? sortId,
            string extend,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            Resource result;
            result = new Resource( resourceId );
            result.ApplicationId = applicationId;
            result.Uri = uri;
            result.Name = name;
            result.Type = type;
            result.ParentId = parentId;
            result.Path = path;
            result.Level = level;
            result.Remark = remark;
            result.PinYin = pinYin;
            result.Enabled = enabled;
            result.SortId = sortId;
            result.Extend = extend;
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