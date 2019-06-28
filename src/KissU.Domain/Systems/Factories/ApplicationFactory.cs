using System;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Factories {
    /// <summary>
    /// 应用程序工厂
    /// </summary>
    public static class ApplicationFactory {
        /// <summary>
        /// 创建应用程序
        /// </summary>
        /// <param name="applicationId">应用程序编号</param>
        /// <param name="code">应用程序编码</param>
        /// <param name="name">应用程序名称</param>
        /// <param name="comment">备注</param>
        /// <param name="enabled">启用</param>
        /// <param name="registerEnabled">启用注册</param>
        /// <param name="creationTime">创建时间</param>
        /// <param name="creatorId">创建人编号</param>
        /// <param name="lastModificationTime">最后修改时间</param>
        /// <param name="lastModifierId">最后修改人编号</param>
        /// <param name="isDeleted">是否删除</param>
        /// <param name="version">版本号</param>
        public static Application Create( 
            Guid applicationId,
            string code,
            string name,
            string comment,
            bool enabled,
            bool registerEnabled,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            Byte[] version
        ) {
            Application result;
            result = new Application( applicationId );
            result.Code = code;
            result.Name = name;
            result.Comment = comment;
            result.RegisterEnabled = registerEnabled;
            result.CreationTime = creationTime;
            result.CreatorId = creatorId;
            result.LastModificationTime = lastModificationTime;
            result.LastModifierId = lastModifierId;
            result.Version = version;
            return result;
        }
    }
}