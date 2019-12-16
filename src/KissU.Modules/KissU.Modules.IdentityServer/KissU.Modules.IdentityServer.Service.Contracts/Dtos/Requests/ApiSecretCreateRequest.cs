// <copyright file="ApiSecretCreateRequest.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using KissU.Modules.IdentityServer.Domain.Shared.Enums;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests
{
    /// <summary>
    /// 创建Api密钥请求参数
    /// </summary>
    public class ApiResourceSecretCreateRequest : RequestBase
    {
        /// <summary>
        /// Api资源编号
        /// </summary>

        [Required]
        [Display(Name = "Api资源编号")]
        public Guid ApiResourceId { get; set; }

        /// <summary>
        /// 密钥值
        /// </summary>

        [Required]
        [StringLength(50, ErrorMessage = "密钥值输入过长，不能超过50位")]
        [Display(Name = "密钥值")]
        public string Value { get; set; }

        /// <summary>
        /// 密钥类型
        /// </summary>

        [Required]
        [StringLength(250, ErrorMessage = "密钥类型输入过长，不能超过250位")]
        [Display(Name = "密钥类型")]
        public string Type { get; set; }

        /// <summary>
        /// 哈希类型 0:Sha256,1: Sha512(HashType只适用于SharedSecret型)
        /// </summary>

        [Display(Name = "哈希类型")]
        public HashType HashType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        [StringLength(1000, ErrorMessage = "描述输入过长，不能超过1000位")]
        [Display(Name = "描述")]
        public string Description { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>

        [Display(Name = "过期时间")]
        public DateTime? Expiration { get; set; }
    }
}
