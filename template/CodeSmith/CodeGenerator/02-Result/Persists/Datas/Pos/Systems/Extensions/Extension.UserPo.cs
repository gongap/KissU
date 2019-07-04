using Util;
using KissU.GreatWall.Systems.Domain.Models;
using Util.Maps;

namespace KissU.GreatWall.Data.Pos.Systems.Extensions {
    /// <summary>
    /// 用户持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="po">用户持久化对象</param>
        public static User ToEntity( this UserPo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new User( po.Id ) );
        }
        
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="po">用户持久化对象</param>
        private static User ToEntity2( this UserPo po ) {
            if( po == null )
                return null;
            return new User( po.Id ) {
                UserName = po.UserName,
                NormalizedUserName = po.NormalizedUserName,
                Email = po.Email,
                NormalizedEmail = po.NormalizedEmail,
                EmailConfirmed = po.EmailConfirmed,
                PhoneNumber = po.PhoneNumber,
                PhoneNumberConfirmed = po.PhoneNumberConfirmed,
                Password = po.Password,
                PasswordHash = po.PasswordHash,
                SafePassword = po.SafePassword,
                SafePasswordHash = po.SafePasswordHash,
                TwoFactorEnabled = po.TwoFactorEnabled,
                Enabled = po.Enabled,
                DisabledTime = po.DisabledTime,
                LockoutEnabled = po.LockoutEnabled,
                LockoutEnd = po.LockoutEnd,
                AccessFailedCount = po.AccessFailedCount,
                LoginCount = po.LoginCount,
                RegisterIp = po.RegisterIp,
                LastLoginTime = po.LastLoginTime,
                LastLoginIp = po.LastLoginIp,
                CurrentLoginTime = po.CurrentLoginTime,
                CurrentLoginIp = po.CurrentLoginIp,
                SecurityStamp = po.SecurityStamp,
                Remark = po.Remark,
                CreationTime = po.CreationTime,
                CreatorId = po.CreatorId,
                LastModificationTime = po.LastModificationTime,
                LastModifierId = po.LastModifierId,
                IsDeleted = po.IsDeleted,
                Version = po.Version,
            };
        }
        
        /// <summary>
        /// 转换为用户持久化对象
        /// </summary>
        /// <param name="entity">用户实体</param>
        public static UserPo ToPo(this User entity) {
            if( entity == null )
                return null;
            return entity.MapTo<UserPo>();
        }

        /// <summary>
        /// 转换为用户持久化对象
        /// </summary>
        /// <param name="entity">用户实体</param>
        private static UserPo ToPo2( this User entity ) {
            if( entity == null )
                return null;
            return new UserPo {
                Id = entity.Id,
                UserName = entity.UserName,
                NormalizedUserName = entity.NormalizedUserName,
                Email = entity.Email,
                NormalizedEmail = entity.NormalizedEmail,
                EmailConfirmed = entity.EmailConfirmed,
                PhoneNumber = entity.PhoneNumber,
                PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                Password = entity.Password,
                PasswordHash = entity.PasswordHash,
                SafePassword = entity.SafePassword,
                SafePasswordHash = entity.SafePasswordHash,
                TwoFactorEnabled = entity.TwoFactorEnabled,
                Enabled = entity.Enabled,
                DisabledTime = entity.DisabledTime,
                LockoutEnabled = entity.LockoutEnabled,
                LockoutEnd = entity.LockoutEnd,
                AccessFailedCount = entity.AccessFailedCount,
                LoginCount = entity.LoginCount,
                RegisterIp = entity.RegisterIp,
                LastLoginTime = entity.LastLoginTime,
                LastLoginIp = entity.LastLoginIp,
                CurrentLoginTime = entity.CurrentLoginTime,
                CurrentLoginIp = entity.CurrentLoginIp,
                SecurityStamp = entity.SecurityStamp,
                Remark = entity.Remark,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                IsDeleted = entity.IsDeleted,
                Version = entity.Version,
            };
        }
    }
}
