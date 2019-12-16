// <copyright file="UserDto.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.GreatWall.Service.Contracts.Dtos
{
    /// <summary>
    /// 用户参数
    /// </summary>
    public class UserDto : DtoBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(256)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [StringLength(256)]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// 邮箱已确认
        /// </summary>
        [Display(Name = "邮箱已确认")]
        public bool? EmailConfirmed { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(64)]
        [Display(Name = "手机号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 手机已确认
        /// </summary>
        [Display(Name = "手机已确认")]
        public bool? PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 启用两步认证
        /// </summary>
        [Display(Name = "启用两步认证")]
        public bool? TwoFactorEnabled { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 冻结时间
        /// </summary>
        [Display(Name = "冻结时间")]
        public DateTime? DisabledTime { get; set; }

        /// <summary>
        /// 启用锁定
        /// </summary>
        [Display(Name = "启用锁定")]
        public bool? LockoutEnabled { get; set; }

        /// <summary>
        /// 锁定截止
        /// </summary>
        [Display(Name = "锁定截止")]
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// 登录失败次数
        /// </summary>
        [Display(Name = "登录失败次数")]
        public int? AccessFailedCount { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        [Display(Name = "登录次数")]
        public int? LoginCount { get; set; }

        /// <summary>
        /// 注册Ip
        /// </summary>
        [StringLength(30)]
        [Display(Name = "注册Ip")]
        public string RegisterIp { get; set; }

        /// <summary>
        /// 上次登陆时间
        /// </summary>
        [Display(Name = "上次登陆时间")]
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        [StringLength(30)]
        [Display(Name = "上次登陆Ip")]
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 本次登陆时间
        /// </summary>
        [Display(Name = "本次登陆时间")]
        public DateTime? CurrentLoginTime { get; set; }

        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        [StringLength(30)]
        [Display(Name = "本次登陆Ip")]
        public string CurrentLoginIp { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public byte[] Version { get; set; }
    }
}
