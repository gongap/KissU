// <copyright file="ApiResourceSecret.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Util.Domains;
    using Util.Domains.Auditing;

    /// <summary>
    /// Api资源密钥
    /// </summary>
    [Description("Api资源密钥")]
    public class ApiResourceSecret : EntityBase<ApiResourceSecret, Guid>, IAudited
    {
        /// <summary>
        /// 初始化Api资源密钥
        /// </summary>
        public ApiResourceSecret() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化Api资源密钥
        /// </summary>
        /// <param name="id">应用程序标识</param>
        public ApiResourceSecret(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Api资源
        /// </summary>
        public ApiResource ApiResource { get; set; }

        /// <summary>
        /// 密钥类型
        /// </summary>
        [Required]
        [StringLength(250, ErrorMessage = "密钥类型输入过长，不能超过250位")]
        [DisplayName("密钥类型")]
        public string Type { get; set; }

        /// <summary>
        /// 密钥值
        /// </summary>
        [Required]
        [StringLength(2000, ErrorMessage = "密钥值输入过长，不能超过2000位")]
        [DisplayName("密钥值")]
        public string Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(1000, ErrorMessage = "描述输入过长，不能超过1000位")]
        [DisplayName("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [DisplayName("过期时间")]
        public DateTime? Expiration { get; set; }

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
