// <copyright file="ApiResourceScope.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util;
using KissU.Util.Domains;
using KissU.Util.Domains.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Convert = KissU.Util.Helpers.Convert;

namespace KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate
{
    /// <summary>
    /// Api资源许可范围
    /// </summary>
    [Description("Api资源许可范围")]
    public class ApiResourceScope : EntityBase<ApiResourceScope, Guid>, IAudited
    {
        /// <summary>
        /// 初始化Api资源许可范围
        /// </summary>
        public ApiResourceScope() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化Api资源许可范围
        /// </summary>
        public ApiResourceScope(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Api资源
        /// </summary>
        public ApiResource ApiResource { get; set; }

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
