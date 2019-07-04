using System;
using KissU.GreatWall.Systems.Domains.Models;

namespace KissU.GreatWall.Systems.Domains.Factories {
    /// <summary>
    /// 用户工厂
    /// </summary>
    public static class UserFactory {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="userName">用户名</param>
        /// <param name="normalizedUserName">标准化用户名</param>
        /// <param name="email">安全邮箱</param>
        /// <param name="normalizedEmail">标准化邮箱</param>
        /// <param name="emailConfirmed">邮箱已确认</param>
        /// <param name="phoneNumber">安全手机</param>
        /// <param name="phoneNumberConfirmed">手机已确认</param>
        /// <param name="password">密码</param>
        /// <param name="passwordHash">密码散列</param>
        /// <param name="safePassword">安全码</param>
        /// <param name="safePasswordHash">安全码散列</param>
        /// <param name="twoFactorEnabled">启用两阶段认证</param>
        /// <param name="enabled">启用</param>
        /// <param name="disabledTime">冻结时间</param>
        /// <param name="lockoutEnabled">启用锁定</param>
        /// <param name="lockoutEnd">锁定截止</param>
        /// <param name="accessFailedCount">登录失败次数</param>
        /// <param name="loginCount">登录次数</param>
        /// <param name="registerIp">注册Ip</param>
        /// <param name="lastLoginTime">上次登陆时间</param>
        /// <param name="lastLoginIp">上次登陆Ip</param>
        /// <param name="currentLoginTime">本次登陆时间</param>
        /// <param name="currentLoginIp">本次登陆Ip</param>
        /// <param name="securityStamp">安全戳</param>
        /// <param name="remark">备注</param>
        /// <param name="creationTime">创建时间</param>
        /// <param name="creatorId">创建人</param>
        /// <param name="lastModificationTime">最后修改时间</param>
        /// <param name="lastModifierId">最后修改人</param>
        /// <param name="isDeleted">是否删除</param>
        /// <param name="version">版本号</param>
        public static User Create( 
            Guid userId,
            string userName,
            string normalizedUserName,
            string email,
            string normalizedEmail,
            bool emailConfirmed,
            string phoneNumber,
            bool phoneNumberConfirmed,
            string password,
            string passwordHash,
            string safePassword,
            string safePasswordHash,
            bool twoFactorEnabled,
            bool enabled,
            DateTime? disabledTime,
            bool lockoutEnabled,
            DateTimeOffset? lockoutEnd,
            int? accessFailedCount,
            int? loginCount,
            string registerIp,
            DateTime? lastLoginTime,
            string lastLoginIp,
            DateTime? currentLoginTime,
            string currentLoginIp,
            string securityStamp,
            string remark,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            User result;
            result = new User( userId );
            result.UserName = userName;
            result.NormalizedUserName = normalizedUserName;
            result.Email = email;
            result.NormalizedEmail = normalizedEmail;
            result.EmailConfirmed = emailConfirmed;
            result.PhoneNumber = phoneNumber;
            result.PhoneNumberConfirmed = phoneNumberConfirmed;
            result.Password = password;
            result.PasswordHash = passwordHash;
            result.SafePassword = safePassword;
            result.SafePasswordHash = safePasswordHash;
            result.TwoFactorEnabled = twoFactorEnabled;
            result.Enabled = enabled;
            result.DisabledTime = disabledTime;
            result.LockoutEnabled = lockoutEnabled;
            result.LockoutEnd = lockoutEnd;
            result.AccessFailedCount = accessFailedCount;
            result.LoginCount = loginCount;
            result.RegisterIp = registerIp;
            result.LastLoginTime = lastLoginTime;
            result.LastLoginIp = lastLoginIp;
            result.CurrentLoginTime = currentLoginTime;
            result.CurrentLoginIp = currentLoginIp;
            result.SecurityStamp = securityStamp;
            result.Remark = remark;
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