using System;
using System.Collections.Generic;
using Xunit;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Test.Models.Systems;

namespace KissU.GreatWall.Test.Integration.Dtos.Systems {
    /// <summary>
    /// 用户数据传输对象测试
    /// </summary>
    public class UserDtoTest {
        /// <summary>
        /// 创建用户数据传输对象
        /// </summary>
        public static UserDto Create(string id = "") {
            return UserTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建用户数据传输对象2
        /// </summary>
        /// <param name="id">用户编号</param>
        public static UserDto Create2( string id = "" ) {
            return UserTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建用户数据传输对象列表
        /// </summary>
        public static List<UserDto> CreateList() {
            return new List<UserDto>() {
                Create(),
                Create2()
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [Fact]
        public void TestToDto() {
            var dto = Create();
            Assert.Equal( UserTest.Id.ToString(),dto.Id );
            Assert.Equal( UserTest.UserName,dto.UserName );
            Assert.Equal( UserTest.NormalizedUserName,dto.NormalizedUserName );
            Assert.Equal( UserTest.Email,dto.Email );
            Assert.Equal( UserTest.NormalizedEmail,dto.NormalizedEmail );
            Assert.Equal( UserTest.EmailConfirmed,dto.EmailConfirmed );
            Assert.Equal( UserTest.PhoneNumber,dto.PhoneNumber );
            Assert.Equal( UserTest.PhoneNumberConfirmed,dto.PhoneNumberConfirmed );
            Assert.Equal( UserTest.Password,dto.Password );
            Assert.Equal( UserTest.PasswordHash,dto.PasswordHash );
            Assert.Equal( UserTest.SafePassword,dto.SafePassword );
            Assert.Equal( UserTest.SafePasswordHash,dto.SafePasswordHash );
            Assert.Equal( UserTest.TwoFactorEnabled,dto.TwoFactorEnabled );
            Assert.Equal( UserTest.Enabled,dto.Enabled );
            Assert.Equal( UserTest.DisabledTime,dto.DisabledTime );
            Assert.Equal( UserTest.LockoutEnabled,dto.LockoutEnabled );
            Assert.Equal( UserTest.LockoutEnd,dto.LockoutEnd );
            Assert.Equal( UserTest.AccessFailedCount,dto.AccessFailedCount );
            Assert.Equal( UserTest.LoginCount,dto.LoginCount );
            Assert.Equal( UserTest.RegisterIp,dto.RegisterIp );
            Assert.Equal( UserTest.LastLoginTime,dto.LastLoginTime );
            Assert.Equal( UserTest.LastLoginIp,dto.LastLoginIp );
            Assert.Equal( UserTest.CurrentLoginTime,dto.CurrentLoginTime );
            Assert.Equal( UserTest.CurrentLoginIp,dto.CurrentLoginIp );
            Assert.Equal( UserTest.SecurityStamp,dto.SecurityStamp );
            Assert.Equal( UserTest.Remark,dto.Remark );
            Assert.Equal( UserTest.CreationTime,dto.CreationTime );
            Assert.Equal( UserTest.CreatorId,dto.CreatorId );
            Assert.Equal( UserTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( UserTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( UserTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( UserTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.Equal( UserTest.Id,entity.Id );
            Assert.Equal( UserTest.UserName,entity.UserName );
            Assert.Equal( UserTest.NormalizedUserName,entity.NormalizedUserName );
            Assert.Equal( UserTest.Email,entity.Email );
            Assert.Equal( UserTest.NormalizedEmail,entity.NormalizedEmail );
            Assert.Equal( UserTest.EmailConfirmed,entity.EmailConfirmed );
            Assert.Equal( UserTest.PhoneNumber,entity.PhoneNumber );
            Assert.Equal( UserTest.PhoneNumberConfirmed,entity.PhoneNumberConfirmed );
            Assert.Equal( UserTest.Password,entity.Password );
            Assert.Equal( UserTest.PasswordHash,entity.PasswordHash );
            Assert.Equal( UserTest.SafePassword,entity.SafePassword );
            Assert.Equal( UserTest.SafePasswordHash,entity.SafePasswordHash );
            Assert.Equal( UserTest.TwoFactorEnabled,entity.TwoFactorEnabled );
            Assert.Equal( UserTest.Enabled,entity.Enabled );
            Assert.Equal( UserTest.DisabledTime,entity.DisabledTime );
            Assert.Equal( UserTest.LockoutEnabled,entity.LockoutEnabled );
            Assert.Equal( UserTest.LockoutEnd,entity.LockoutEnd );
            Assert.Equal( UserTest.AccessFailedCount,entity.AccessFailedCount );
            Assert.Equal( UserTest.LoginCount,entity.LoginCount );
            Assert.Equal( UserTest.RegisterIp,entity.RegisterIp );
            Assert.Equal( UserTest.LastLoginTime,entity.LastLoginTime );
            Assert.Equal( UserTest.LastLoginIp,entity.LastLoginIp );
            Assert.Equal( UserTest.CurrentLoginTime,entity.CurrentLoginTime );
            Assert.Equal( UserTest.CurrentLoginIp,entity.CurrentLoginIp );
            Assert.Equal( UserTest.SecurityStamp,entity.SecurityStamp );
            Assert.Equal( UserTest.Remark,entity.Remark );
            Assert.Equal( UserTest.CreationTime,entity.CreationTime );
            Assert.Equal( UserTest.CreatorId,entity.CreatorId );
            Assert.Equal( UserTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( UserTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( UserTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( UserTest.Version,entity.Version );
        }
    }
}