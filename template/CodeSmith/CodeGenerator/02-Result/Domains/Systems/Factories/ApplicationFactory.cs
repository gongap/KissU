using System;
using GreatWall.Systems.Domains.Models;

namespace GreatWall.Systems.Domains.Factories {
    /// <summary>
    /// 应用程序工厂
    /// </summary>
    public static class ApplicationFactory {
        /// <summary>
        /// 创建应用程序
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="code">应用程序编码</param>
        /// <param name="name">应用程序名称</param>
        /// <param name="enabled">启用</param>
        /// <param name="registerEnabled">启用注册</param>
        /// <param name="remark">备注</param>
        /// <param name="extend">扩展</param>
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
            bool enabled,
            bool registerEnabled,
            string remark,
            string extend,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            Application result;
            result = new Application( applicationId );
            result.Code = code;
            result.Name = name;
            result.Enabled = enabled;
            result.RegisterEnabled = registerEnabled;
            result.Remark = remark;
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