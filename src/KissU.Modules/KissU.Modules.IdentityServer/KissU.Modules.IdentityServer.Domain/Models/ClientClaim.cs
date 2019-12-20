// <copyright file="ClientClaim.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;
using KissU.Util.Domains.Auditing;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 应用程序声明
    /// </summary>
    [Description("应用程序声明")]
    public class ClientClaim : EntityBase<ClientClaim>, IAudited
    {
        /// <summary>
        /// 初始化应用程序声明
        /// </summary>
        public ClientClaim() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化应用程序声明
        /// </summary>
        public ClientClaim(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 声明的类型
        /// </summary>
        [Required]
        [StringLength(250, ErrorMessage = "声明的类型输入过长，不能超过250位")]
        [DisplayName("声明的类型")]
        public string Type { get; set; }

        /// <summary>
        /// 声明的值
        /// </summary>
        [Required]
        [StringLength(2000, ErrorMessage = "声明的值输入过长，不能超过2000位")]
        [DisplayName("声明的值")]
        public string Value { get; set; }

        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }

        #region IAudited

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DisplayName("创建人")]
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        [DisplayName("最后修改人")]
        public Guid? LastModifierId { get; set; }

        #endregion
    }
}
