using System;
using System.Collections.Generic;
using Util;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Test.Models.Systems {
    /// <summary>
    /// 用户测试数据
    /// </summary>
    public partial class UserTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 用户标识
        /// </summary>
        public static readonly Guid Id = "d6a149bc-b0be-4056-8df8-e14672dc1ea1".ToGuid();
        /// <summary>
        /// 用户名
        /// </summary>
        public static readonly string UserName = "UserName";
        /// <summary>
        /// 标准化用户名
        /// </summary>
        public static readonly string NormalizedUserName = "NormalizedUserName";
        /// <summary>
        /// 安全邮箱
        /// </summary>
        public static readonly string Email = "Email";
        /// <summary>
        /// 标准化邮箱
        /// </summary>
        public static readonly string NormalizedEmail = "NormalizedEmail";
        /// <summary>
        /// 邮箱已确认
        /// </summary>
        public static readonly bool EmailConfirmed = true;
        /// <summary>
        /// 安全手机
        /// </summary>
        public static readonly string PhoneNumber = "PhoneNumber";
        /// <summary>
        /// 手机已确认
        /// </summary>
        public static readonly bool PhoneNumberConfirmed = true;
        /// <summary>
        /// 密码
        /// </summary>
        public static readonly string Password = "Password";
        /// <summary>
        /// 密码散列
        /// </summary>
        public static readonly string PasswordHash = "PasswordHash";
        /// <summary>
        /// 安全码
        /// </summary>
        public static readonly string SafePassword = "SafePassword";
        /// <summary>
        /// 安全码散列
        /// </summary>
        public static readonly string SafePasswordHash = "SafePasswordHash";
        /// <summary>
        /// 启用两阶段认证
        /// </summary>
        public static readonly bool TwoFactorEnabled = true;
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 冻结时间
        /// </summary>
        public static readonly DateTime? DisabledTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 启用锁定
        /// </summary>
        public static readonly bool LockoutEnabled = true;
        /// <summary>
        /// 锁定截止
        /// </summary>
        public static readonly DateTimeOffset? LockoutEnd = "LockoutEnd";
        /// <summary>
        /// 登录失败次数
        /// </summary>
        public static readonly int? AccessFailedCount = 1;
        /// <summary>
        /// 登录次数
        /// </summary>
        public static readonly int? LoginCount = 1;
        /// <summary>
        /// 注册Ip
        /// </summary>
        public static readonly string RegisterIp = "RegisterIp";
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public static readonly DateTime? LastLoginTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        public static readonly string LastLoginIp = "LastLoginIp";
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        public static readonly DateTime? CurrentLoginTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        public static readonly string CurrentLoginIp = "CurrentLoginIp";
        /// <summary>
        /// 安全戳
        /// </summary>
        public static readonly string SecurityStamp = "SecurityStamp";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Remark = "Remark";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 创建人
        /// </summary>
        public static readonly Guid? CreatorId = "d05c4437-25bb-4e72-952a-5382af5f6da2".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人
        /// </summary>
        public static readonly Guid? LastModifierId = "6b8c86b7-babf-4c67-b440-4846a8c8d39c".ToGuid();
        /// <summary>
        /// 是否删除
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = Util.Helpers.Convert.ToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 用户标识
        /// </summary>
        public static readonly Guid Id2 = "a9bcbdb1-75ed-4742-b80f-cbb188254c60".ToGuid();
        /// <summary>
        /// 用户名
        /// </summary>
        public static readonly string UserName2 = "UserName2";
        /// <summary>
        /// 标准化用户名
        /// </summary>
        public static readonly string NormalizedUserName2 = "NormalizedUserName2";
        /// <summary>
        /// 安全邮箱
        /// </summary>
        public static readonly string Email2 = "Email2";
        /// <summary>
        /// 标准化邮箱
        /// </summary>
        public static readonly string NormalizedEmail2 = "NormalizedEmail2";
        /// <summary>
        /// 邮箱已确认
        /// </summary>
        public static readonly bool EmailConfirmed2 = true;
        /// <summary>
        /// 安全手机
        /// </summary>
        public static readonly string PhoneNumber2 = "PhoneNumber2";
        /// <summary>
        /// 手机已确认
        /// </summary>
        public static readonly bool PhoneNumberConfirmed2 = true;
        /// <summary>
        /// 密码
        /// </summary>
        public static readonly string Password2 = "Password2";
        /// <summary>
        /// 密码散列
        /// </summary>
        public static readonly string PasswordHash2 = "PasswordHash2";
        /// <summary>
        /// 安全码
        /// </summary>
        public static readonly string SafePassword2 = "SafePassword2";
        /// <summary>
        /// 安全码散列
        /// </summary>
        public static readonly string SafePasswordHash2 = "SafePasswordHash2";
        /// <summary>
        /// 启用两阶段认证
        /// </summary>
        public static readonly bool TwoFactorEnabled2 = true;
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 冻结时间
        /// </summary>
        public static readonly DateTime? DisabledTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 启用锁定
        /// </summary>
        public static readonly bool LockoutEnabled2 = true;
        /// <summary>
        /// 锁定截止
        /// </summary>
        public static readonly DateTimeOffset? LockoutEnd2 = "LockoutEnd2";
        /// <summary>
        /// 登录失败次数
        /// </summary>
        public static readonly int? AccessFailedCount2 = 2;
        /// <summary>
        /// 登录次数
        /// </summary>
        public static readonly int? LoginCount2 = 2;
        /// <summary>
        /// 注册Ip
        /// </summary>
        public static readonly string RegisterIp2 = "RegisterIp2";
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public static readonly DateTime? LastLoginTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        public static readonly string LastLoginIp2 = "LastLoginIp2";
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        public static readonly DateTime? CurrentLoginTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        public static readonly string CurrentLoginIp2 = "CurrentLoginIp2";
        /// <summary>
        /// 安全戳
        /// </summary>
        public static readonly string SecurityStamp2 = "SecurityStamp2";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Remark2 = "Remark2";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 创建人
        /// </summary>
        public static readonly Guid? CreatorId2 = "5e996c76-ed1f-4fb7-9867-d74e1b94c948".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人
        /// </summary>
        public static readonly Guid? LastModifierId2 = "fb6d73b2-a753-41ce-8234-d8ab06b08c0a".ToGuid();
        /// <summary>
        /// 是否删除
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建用户实体
        /// </summary>
        public static User Create(string id = "") {
            return new User( id.ToGuid() ) {
                UserName = UserName,
                NormalizedUserName = NormalizedUserName,
                Email = Email,
                NormalizedEmail = NormalizedEmail,
                EmailConfirmed = EmailConfirmed,
                PhoneNumber = PhoneNumber,
                PhoneNumberConfirmed = PhoneNumberConfirmed,
                Password = Password,
                PasswordHash = PasswordHash,
                SafePassword = SafePassword,
                SafePasswordHash = SafePasswordHash,
                TwoFactorEnabled = TwoFactorEnabled,
                Enabled = Enabled,
                DisabledTime = DisabledTime,
                LockoutEnabled = LockoutEnabled,
                LockoutEnd = LockoutEnd,
                AccessFailedCount = AccessFailedCount,
                LoginCount = LoginCount,
                RegisterIp = RegisterIp,
                LastLoginTime = LastLoginTime,
                LastLoginIp = LastLoginIp,
                CurrentLoginTime = CurrentLoginTime,
                CurrentLoginIp = CurrentLoginIp,
                SecurityStamp = SecurityStamp,
                Remark = Remark,
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
        public static User Create2( string id = "" ) {
            return new User( id.ToGuid() ) {
                UserName = UserName2,
                NormalizedUserName = NormalizedUserName2,
                Email = Email2,
                NormalizedEmail = NormalizedEmail2,
                EmailConfirmed = EmailConfirmed2,
                PhoneNumber = PhoneNumber2,
                PhoneNumberConfirmed = PhoneNumberConfirmed2,
                Password = Password2,
                PasswordHash = PasswordHash2,
                SafePassword = SafePassword2,
                SafePasswordHash = SafePasswordHash2,
                TwoFactorEnabled = TwoFactorEnabled2,
                Enabled = Enabled2,
                DisabledTime = DisabledTime2,
                LockoutEnabled = LockoutEnabled2,
                LockoutEnd = LockoutEnd2,
                AccessFailedCount = AccessFailedCount2,
                LoginCount = LoginCount2,
                RegisterIp = RegisterIp2,
                LastLoginTime = LastLoginTime2,
                LastLoginIp = LastLoginIp2,
                CurrentLoginTime = CurrentLoginTime2,
                CurrentLoginIp = CurrentLoginIp2,
                SecurityStamp = SecurityStamp2,
                Remark = Remark2,
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
        public static List<User> CreateList() {
            return new List<User>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}