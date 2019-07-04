using Util;
using Util.Maps;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Service.Dtos.Systems.Extensions {
    /// <summary>
    /// 用户参数扩展
    /// </summary>
    public static class UserDtoExtension {
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="dto">用户参数</param>
        public static User ToEntity( this UserDto dto ) {
            if ( dto == null )
                return new User();
            return dto.MapTo( new User( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="dto">用户参数</param>
        public static User ToEntity2( this UserDto dto ) {
            if( dto == null )
                return new User();
            return new User( dto.Id.ToGuid() ) {
                UserName = dto.UserName,
                NormalizedUserName = dto.NormalizedUserName,
                Email = dto.Email,
                NormalizedEmail = dto.NormalizedEmail,
                EmailConfirmed = dto.EmailConfirmed.SafeValue(),
                PhoneNumber = dto.PhoneNumber,
                PhoneNumberConfirmed = dto.PhoneNumberConfirmed.SafeValue(),
                Password = dto.Password,
                PasswordHash = dto.PasswordHash,
                SafePassword = dto.SafePassword,
                SafePasswordHash = dto.SafePasswordHash,
                TwoFactorEnabled = dto.TwoFactorEnabled.SafeValue(),
                Enabled = dto.Enabled.SafeValue(),
                DisabledTime = dto.DisabledTime,
                LockoutEnabled = dto.LockoutEnabled.SafeValue(),
                LockoutEnd = dto.LockoutEnd,
                AccessFailedCount = dto.AccessFailedCount,
                LoginCount = dto.LoginCount,
                RegisterIp = dto.RegisterIp,
                LastLoginTime = dto.LastLoginTime,
                LastLoginIp = dto.LastLoginIp,
                CurrentLoginTime = dto.CurrentLoginTime,
                CurrentLoginIp = dto.CurrentLoginIp,
                SecurityStamp = dto.SecurityStamp,
                Remark = dto.Remark,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version,
            };
        }
        
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="dto">用户参数</param>
        public static User ToEntity3( this UserDto dto ) {
            if( dto == null )
                return new User();
            return UserFactory.Create(
                userId : dto.Id.ToGuid(),
                userName : dto.UserName,
                normalizedUserName : dto.NormalizedUserName,
                email : dto.Email,
                normalizedEmail : dto.NormalizedEmail,
                emailConfirmed : dto.EmailConfirmed,
                phoneNumber : dto.PhoneNumber,
                phoneNumberConfirmed : dto.PhoneNumberConfirmed,
                password : dto.Password,
                passwordHash : dto.PasswordHash,
                safePassword : dto.SafePassword,
                safePasswordHash : dto.SafePasswordHash,
                twoFactorEnabled : dto.TwoFactorEnabled,
                enabled : dto.Enabled,
                disabledTime : dto.DisabledTime,
                lockoutEnabled : dto.LockoutEnabled,
                lockoutEnd : dto.LockoutEnd,
                accessFailedCount : dto.AccessFailedCount,
                loginCount : dto.LoginCount,
                registerIp : dto.RegisterIp,
                lastLoginTime : dto.LastLoginTime,
                lastLoginIp : dto.LastLoginIp,
                currentLoginTime : dto.CurrentLoginTime,
                currentLoginIp : dto.CurrentLoginIp,
                securityStamp : dto.SecurityStamp,
                remark : dto.Remark,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为用户参数
        /// </summary>
        /// <param name="entity">用户实体</param>
        public static UserDto ToDto(this User entity) {
            if( entity == null )
                return new UserDto();
            return entity.MapTo<UserDto>();
        }

        /// <summary>
        /// 转换为用户参数
        /// </summary>
        /// <param name="entity">用户实体</param>
        public static UserDto ToDto2( this User entity ) {
            if( entity == null )
                return new UserDto();
            return new UserDto {
                Id = entity.Id.ToString(),
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
                Version = entity.Version,
            };
        }
    }
}