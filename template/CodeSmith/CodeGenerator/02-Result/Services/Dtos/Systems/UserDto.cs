using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace GreatWall.Service.Dtos.Systems {
    /// <summary>
    /// 用户参数
    /// </summary>
    public class UserDto : DtoBase {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "用户名" )]
        public string UserName { get; set; }
        /// <summary>
        /// 标准化用户名
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "标准化用户名" )]
        public string NormalizedUserName { get; set; }
        /// <summary>
        /// 安全邮箱
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "安全邮箱" )]
        public string Email { get; set; }
        /// <summary>
        /// 标准化邮箱
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "标准化邮箱" )]
        public string NormalizedEmail { get; set; }
        /// <summary>
        /// 邮箱已确认
        /// </summary>
        [Display( Name = "邮箱已确认" )]
        public bool? EmailConfirmed { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>
        [StringLength( 64 )]
        [Display( Name = "安全手机" )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机已确认
        /// </summary>
        [Display( Name = "手机已确认" )]
        public bool? PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "密码" )]
        public string Password { get; set; }
        /// <summary>
        /// 密码散列
        /// </summary>
        [StringLength( 1024 )]
        [Display( Name = "密码散列" )]
        public string PasswordHash { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "安全码" )]
        public string SafePassword { get; set; }
        /// <summary>
        /// 安全码散列
        /// </summary>
        [StringLength( 1024 )]
        [Display( Name = "安全码散列" )]
        public string SafePasswordHash { get; set; }
        /// <summary>
        /// 启用两阶段认证
        /// </summary>
        [Display( Name = "启用两阶段认证" )]
        public bool? TwoFactorEnabled { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 冻结时间
        /// </summary>
        [Display( Name = "冻结时间" )]
        public DateTime? DisabledTime { get; set; }
        /// <summary>
        /// 启用锁定
        /// </summary>
        [Display( Name = "启用锁定" )]
        public bool? LockoutEnabled { get; set; }
        /// <summary>
        /// 锁定截止
        /// </summary>
        [Display( Name = "锁定截止" )]
        public DateTimeOffset? LockoutEnd { get; set; }
        /// <summary>
        /// 登录失败次数
        /// </summary>
        [Display( Name = "登录失败次数" )]
        public int? AccessFailedCount { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        [Display( Name = "登录次数" )]
        public int? LoginCount { get; set; }
        /// <summary>
        /// 注册Ip
        /// </summary>
        [StringLength( 30 )]
        [Display( Name = "注册Ip" )]
        public string RegisterIp { get; set; }
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        [Display( Name = "上次登陆时间" )]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        [StringLength( 30 )]
        [Display( Name = "上次登陆Ip" )]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        [Display( Name = "本次登陆时间" )]
        public DateTime? CurrentLoginTime { get; set; }
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        [StringLength( 30 )]
        [Display( Name = "本次登陆Ip" )]
        public string CurrentLoginIp { get; set; }
        /// <summary>
        /// 安全戳
        /// </summary>
        [StringLength( 1024 )]
        [Display( Name = "安全戳" )]
        public string SecurityStamp { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display( Name = "创建人" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display( Name = "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Display( Name = "最后修改人" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display( Name = "版本号" )]
        public Byte[] Version { get; set; }
    }
}