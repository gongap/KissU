﻿// <copyright file="ClientClaimCreateRequest.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Util.Applications.Dtos;

    /// <summary>
    /// 创建应用程序声明请求参数
    /// </summary>
    public class ClientClaimCreateRequest : RequestBase
    {
        /// <summary>
        /// 应用程序
        /// </summary>

        [Required]
        public Guid ClientId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        [Display(Name = "类型")]
        public string Type { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Required]
        [Display(Name = "值")]
        public string Value { get; set; }
    }
}
