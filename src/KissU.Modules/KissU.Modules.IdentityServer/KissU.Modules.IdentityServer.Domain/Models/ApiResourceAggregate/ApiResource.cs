// <copyright file="ApiResource.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util;
using KissU.Util.Domains;
using KissU.Util.Domains.Auditing;

namespace KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Convert = Util.Helpers.Convert;

    /// <summary>
    /// Api资源
    /// </summary>
    [Description("Api资源")]
    public class ApiResource : AggregateRoot<ApiResource, Guid>, IDelete, IAudited
    {
        /// <summary>
        /// 初始Api资源
        /// </summary>
        public ApiResource() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始Api资源
        /// </summary>
        public ApiResource(Guid id) : base(id)
        {
            Secrets = new List<ApiResourceSecret>();
            Scopes = new List<ApiResourceScope>();
        }

        /// <summary>
        /// API密钥列表
        /// </summary>
        [DisplayName("API密钥")]
        public List<ApiResourceSecret> Secrets { get; set; }

        /// <summary>
        /// API必须至少有一个范围。每个范围可以有不同的设置。
        /// </summary>
        [DisplayName("API许可范围")]
        public List<ApiResourceScope> Scopes { get; set; }

        /// <summary>
        /// 应包含在身份令牌中的关联用户声明类型的列表。
        /// </summary>
        [NotMapped]
        public List<string> UserClaims
        {
            get => Convert.ToList<string>(ClaimTypes);
            set => ClaimTypes = value.Join();
        }

        /// <summary>
        /// 应包含在身份令牌中的关联用户声明类型的列表。
        /// </summary>
        [DisplayName("用户声明类型的列表")]
        [StringLength(2000, ErrorMessage = "用户声明类型的列表输入过长，不能超过2000位")]
        public string ClaimTypes { get; set; }

        /// <summary>
        /// 指示此资源是否已启用且可以请求。默认为true。
        /// </summary>
        [Required]
        [DisplayName("是否启用")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// API的唯一名称。此值用于内省身份验证，并将添加到传出访问令牌的受众。
        /// </summary>
        [Required]
        [StringLength(200, ErrorMessage = "名称输入过长，不能超过200位")]
        [DisplayName("API的唯一名称")]
        public string Name { get; set; }

        /// <summary>
        /// 显示名称。该值可以在例如同意屏幕上使用。
        /// </summary>
        [StringLength(200, ErrorMessage = "显示名称输入过长，不能超过200位")]
        [DisplayName("显示名称")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述。该值可以在例如同意屏幕上使用。
        /// </summary>
        [StringLength(1000, ErrorMessage = "描述输入过长，不能超过1000位")]
        [DisplayName("描述")]
        public string Description { get; set; }

        #region IDelete, IAudited

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

        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }

        #endregion
    }
}
