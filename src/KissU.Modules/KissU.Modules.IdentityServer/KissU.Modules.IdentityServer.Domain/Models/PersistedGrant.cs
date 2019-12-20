// <copyright file="PersistedGrant.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate
{
    /// <summary>
    /// 认证操作数据（令牌，代码和同意书）
    /// </summary>
    public class PersistedGrant : AggregateRoot<PersistedGrant>
    {
        /// <summary>
        /// 初始化认证操作数据
        /// </summary>
        public PersistedGrant() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化认证操作数据
        /// </summary>
        public PersistedGrant(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 标识
        /// </summary>
        [DisplayName("标识")]
        [StringLength(200, ErrorMessage = "标识输入过长，不能超过200位")]
        public string Key { get; set; }

        /// <summary>
        /// 主体
        /// </summary>
        [DisplayName("主体")]
        [StringLength(200, ErrorMessage = "主体输入过长，不能超过200位")]
        public string SubjectId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        [StringLength(50, ErrorMessage = "类型输入过长，不能超过50位")]
        public string Type { get; set; }

        /// <summary>
        /// 应用程序编号
        /// </summary>
        [DisplayName("应用程序编号")]
        [StringLength(200, ErrorMessage = "应用程序编号输入过长，不能超过200位")]
        public string ClientId { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DisplayName("值")]
        public string Data { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        [DisplayName("到期时间")]
        public DateTime? Expiration { get; set; }

        [NotMapped] public string SubjectName { get; set; }

        [NotMapped] public string ClientName { get; set; }
    }
}
