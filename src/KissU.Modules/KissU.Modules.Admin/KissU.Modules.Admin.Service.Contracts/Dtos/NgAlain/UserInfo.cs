﻿// <copyright file="UserInfo.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Admin.Service.Contracts.Dtos.NgAlain
{
    /// <summary>
    /// NgAlain用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }
    }
}