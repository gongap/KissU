using System;
using System.Collections.Generic;
using Xunit;
using Util;
using KissU.Service.Dtos.Systems;
using KissU.Service.Dtos.Systems.Extensions;
using KissU.IntegrationTest.Tests.Models.Systems;

namespace KissU.IntegrationTest.Tests.Dtos.Systems 
{
    /// <summary>
    /// 用户数据传输对象测试
    /// </summary>
    public class UserDtoTest 
	{
        /// <summary>
        /// 创建用户数据传输对象
        /// </summary>
        public static UserDto Create(string id = "") 
		{
            return UserTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建用户数据传输对象2
        /// </summary>
        /// <param name="id">用户编号</param>
        public static UserDto Create2( string id = "" ) 
		{
            return UserTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建用户数据传输对象列表
        /// </summary>
        public static List<UserDto> CreateList() 
		{
            return new List<UserDto>() {
                Create(),
                Create2()
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [Fact]
        public void TestToDto() 
		{
            var dto = Create();
            Assert.Equal( UserTest.Id.ToString(),dto.Id );
            Assert.Equal( UserTest.UserName,dto.UserName );
            Assert.Equal( UserTest.RealName,dto.RealName );
            Assert.Equal( UserTest.NickName,dto.NickName );
            Assert.Equal( UserTest.Email,dto.Email );
            Assert.Equal( UserTest.EmailConfirmed,dto.EmailConfirmed );
            Assert.Equal( UserTest.PhoneNumber,dto.PhoneNumber );
            Assert.Equal( UserTest.PhoneNumberConfirmed,dto.PhoneNumberConfirmed );
            Assert.Equal( UserTest.Password,dto.Password );
            Assert.Equal( UserTest.PasswordHash,dto.PasswordHash );
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
        public void TestToEntity() 
		{
            var entity = Create().ToEntity();
            Assert.Equal( UserTest.Id,entity.Id );
            Assert.Equal( UserTest.UserName,entity.UserName );
            Assert.Equal( UserTest.RealName,entity.RealName );
            Assert.Equal( UserTest.NickName,entity.NickName );
            Assert.Equal( UserTest.Email,entity.Email );
            Assert.Equal( UserTest.EmailConfirmed,entity.EmailConfirmed );
            Assert.Equal( UserTest.PhoneNumber,entity.PhoneNumber );
            Assert.Equal( UserTest.PhoneNumberConfirmed,entity.PhoneNumberConfirmed );
            Assert.Equal( UserTest.Password,entity.Password );
            Assert.Equal( UserTest.PasswordHash,entity.PasswordHash );
            Assert.Equal( UserTest.CreationTime,entity.CreationTime );
            Assert.Equal( UserTest.CreatorId,entity.CreatorId );
            Assert.Equal( UserTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( UserTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( UserTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( UserTest.Version,entity.Version );
        }
    }
}