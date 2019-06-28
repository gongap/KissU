using System;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Factories {
    /// <summary>
    /// 链接工厂
    /// </summary>
    public static class LinkFactory {
        /// <summary>
        /// 创建链接
        /// </summary>
        /// <param name="linkId"></param>
        /// <param name="code">编码</param>
        /// <param name="title">标题</param>
        /// <param name="address">地址</param>
        /// <param name="image">图片</param>
        /// <param name="comment">备注</param>
        /// <param name="enabled">是否启用</param>
        /// <param name="status">状态</param>
        /// <param name="creationTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="lastModificationTime"></param>
        /// <param name="lastModifierId"></param>
        /// <param name="isDeleted"></param>
        /// <param name="version"></param>
        public static Link Create( 
            Guid linkId,
            string code,
            string title,
            string address,
            string image,
            string comment,
            bool? enabled,
            int? status,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            Link result;
            result = new Link( linkId );
            result.Code = code;
            result.Title = title;
            result.Address = address;
            result.Image = image;
            result.Comment = comment;
            result.Status = status;
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