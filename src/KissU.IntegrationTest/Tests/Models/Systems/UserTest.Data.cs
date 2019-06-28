using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 用户测试数据
    /// </summary>
    public partial class UserTest 
	{
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "f3357d55-fc63-4d8f-8997-6ccff1b16af5".ToGuid();
        /// <summary>
        /// 用户名
        /// </summary>
        public static readonly string UserName = "UserName";
        /// <summary>
        /// 真实姓名
        /// </summary>
        public static readonly string RealName = "RealName";
        /// <summary>
        /// 昵称
        /// </summary>
        public static readonly string NickName = "NickName";
        /// <summary>
        /// 邮箱
        /// </summary>
        public static readonly string Email = "Email";
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        public static readonly bool EmailConfirmed = true;
        /// <summary>
        /// 手机号码
        /// </summary>
        public static readonly string PhoneNumber = "PhoneNumber";
        /// <summary>
        /// 手机号码是否验证
        /// </summary>
        public static readonly bool PhoneNumberConfirmed = true;
        /// <summary>
        /// 密码
        /// </summary>
        public static readonly string Password = "Password";
        /// <summary>
        /// 密码哈希值
        /// </summary>
        public static readonly string PasswordHash = "PasswordHash";
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "0e9e1518-68ef-4445-972b-80bb38bdf967".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "6754d709-2389-42c1-b7a9-42724a93ded9".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version = Util.Helpers.Convert.ToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id2 = "5453565f-e6b8-4c99-be5b-7df6606385af".ToGuid();
        /// <summary>
        /// 用户名
        /// </summary>
        public static readonly string UserName2 = "UserName2";
        /// <summary>
        /// 真实姓名
        /// </summary>
        public static readonly string RealName2 = "RealName2";
        /// <summary>
        /// 昵称
        /// </summary>
        public static readonly string NickName2 = "NickName2";
        /// <summary>
        /// 邮箱
        /// </summary>
        public static readonly string Email2 = "Email2";
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        public static readonly bool EmailConfirmed2 = true;
        /// <summary>
        /// 手机号码
        /// </summary>
        public static readonly string PhoneNumber2 = "PhoneNumber2";
        /// <summary>
        /// 手机号码是否验证
        /// </summary>
        public static readonly bool PhoneNumberConfirmed2 = true;
        /// <summary>
        /// 密码
        /// </summary>
        public static readonly string Password2 = "Password2";
        /// <summary>
        /// 密码哈希值
        /// </summary>
        public static readonly string PasswordHash2 = "PasswordHash2";
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "7a9de835-d44b-4e44-b7d0-cf372659cccd".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "11ddea71-270f-459c-bc4a-e5c2072e42d0".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted2 = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建用户实体
        /// </summary>
        public static User Create(string id = "") 
		{
            return 
			new User( id.ToGuid() ) {
                UserName = UserName,
                RealName = RealName,
                NickName = NickName,
                Email = Email,
                EmailConfirmed = EmailConfirmed,
                PhoneNumber = PhoneNumber,
                PhoneNumberConfirmed = PhoneNumberConfirmed,
                Password = Password,
                PasswordHash = PasswordHash,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建用户实体2
        /// </summary>
        /// <param name="id">用户编号</param>
        public static User Create2( string id = "" ) 
		{
            return 
			new User( id.ToGuid() ) {
                UserName = UserName2,
                RealName = RealName2,
                NickName = NickName2,
                Email = Email2,
                EmailConfirmed = EmailConfirmed2,
                PhoneNumber = PhoneNumber2,
                PhoneNumberConfirmed = PhoneNumberConfirmed2,
                Password = Password2,
                PasswordHash = PasswordHash2,
                CreationTime = CreationTime2,
                CreatorId = CreatorId2,
                LastModificationTime = LastModificationTime2,
                LastModifierId = LastModifierId2,
                IsDeleted = IsDeleted2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<User> CreateList() 
		{
            return new List<User>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}