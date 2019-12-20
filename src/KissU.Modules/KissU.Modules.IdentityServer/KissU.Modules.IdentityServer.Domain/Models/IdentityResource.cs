// <copyright file="IdentityResource.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KissU.Util;
using KissU.Util.Domains;
using KissU.Util.Domains.Auditing;
using Convert = KissU.Util.Helpers.Convert;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 身份资源
    /// </summary>
    [Description("身份资源")]
    public class IdentityResource : AggregateRoot<IdentityResource, Guid>, IDelete, IAudited
    {
        /// <summary>
        /// 初始化身份资源
        /// </summary>
        public IdentityResource() : base(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化身份资源
        /// </summary>
        public IdentityResource(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 指定用户是否可以在同意屏幕上取消选择范围（如果同意屏幕要实现此类功能）。默认为false。
        /// </summary>
        [Required]
        [DisplayName("是否可以在同意屏幕上取消选择范围")]
        public bool Required { get; set; }

        /// <summary>
        /// 指定同意屏幕是否会强调此范围（如果同意屏幕要实现此类功能）。将此设置用于敏感或重要范围。默认为false。
        /// </summary>
        [Required]
        [DisplayName("是否会强调此范围")]
        public bool Emphasize { get; set; }

        /// <summary>
        /// 指定此范围是否显示在发现文档中。默认为true。
        /// </summary>
        [Required]
        [DisplayName("是否显示在发现文档中")]
        public bool ShowInDiscoveryDocument { get; set; } = true;

        /// <summary>
        /// 应包含在身份资源中的关联用户声明类型的列表。
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
