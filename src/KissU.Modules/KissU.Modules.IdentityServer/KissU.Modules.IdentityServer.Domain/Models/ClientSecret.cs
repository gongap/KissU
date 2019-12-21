// <copyright file="ClientSecret.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 应用程序密钥
    /// </summary>
    public class ClientSecret : EntityBase<ClientSecret>
    {
        /// <summary>
        /// 初始化应用程序密钥
        /// </summary>
        public ClientSecret() : base(Guid.Empty)
        {
        }

        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 密钥类型
        /// </summary>
        [Required]
        [StringLength(250)]
        public string Type { get; set; }

        /// <summary>
        /// 密钥值
        /// </summary>
        [Required]
        [StringLength(4000)]
        public string Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(2000)]
        public string Description { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? Expiration { get; set; }
    }
}
