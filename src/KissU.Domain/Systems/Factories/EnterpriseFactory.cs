using System;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Factories {
    /// <summary>
    /// 企业工厂
    /// </summary>
    public static class EnterpriseFactory {
        /// <summary>
        /// 创建企业
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <param name="name">名称</param>
        /// <param name="enabled">是否启用</param>
        /// <param name="pinYin">拼音</param>
        /// <param name="wcfAddress">Wcf地址</param>
        /// <param name="note">备注</param>
        /// <param name="creationTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="lastModificationTime"></param>
        /// <param name="lastModifierId"></param>
        /// <param name="isDeleted"></param>
        /// <param name="version"></param>
        public static Enterprise Create( 
            Guid enterpriseId,
            string name,
            bool enabled,
            string pinYin,
            string wcfAddress,
            string note,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            Enterprise result;
            result = new Enterprise( enterpriseId );
            result.Name = name;
            result.PinYin = pinYin;
            result.WcfAddress = wcfAddress;
            result.Note = note;
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