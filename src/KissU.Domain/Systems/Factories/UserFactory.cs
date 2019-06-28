using System;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Factories {
    /// <summary>
    /// 用户工厂
    /// </summary>
    public static class UserFactory {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName">用户名</param>
        /// <param name="realName">真实姓名</param>
        /// <param name="nickName">昵称</param>
        /// <param name="email">邮箱</param>
        /// <param name="emailConfirmed">邮箱是否验证</param>
        /// <param name="phoneNumber">手机号码</param>
        /// <param name="phoneNumberConfirmed">手机号码是否验证</param>
        /// <param name="password">密码</param>
        /// <param name="passwordHash">密码哈希值</param>
        /// <param name="creationTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="lastModificationTime"></param>
        /// <param name="lastModifierId"></param>
        /// <param name="isDeleted"></param>
        /// <param name="version"></param>
        public static User Create( 
            Guid userId,
            string userName,
            string realName,
            string nickName,
            string email,
            bool emailConfirmed,
            string phoneNumber,
            bool phoneNumberConfirmed,
            string password,
            string passwordHash,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            Byte[] version
        ) {
            User result;
            result = new User( userId );
            result.UserName = userName;
            result.RealName = realName;
            result.NickName = nickName;
            result.Email = email;
            result.EmailConfirmed = emailConfirmed;
            result.PhoneNumber = phoneNumber;
            result.PhoneNumberConfirmed = phoneNumberConfirmed;
            result.Password = password;
            result.PasswordHash = passwordHash;
            result.CreationTime = creationTime;
            result.CreatorId = creatorId;
            result.LastModificationTime = lastModificationTime;
            result.LastModifierId = lastModifierId;
            result.Version = version;
            return result;
        }
    }
}