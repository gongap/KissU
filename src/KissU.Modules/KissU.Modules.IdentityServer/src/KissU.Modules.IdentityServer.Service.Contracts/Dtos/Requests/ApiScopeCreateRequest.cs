// <copyright file="ApiScopeCreateRequest.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests
{
    using System.Collections.Generic;
    using Util.Applications.Dtos;

    /// <summary>
    ///     创建Api许可范围请求参数
    /// </summary>
    public class ApiResourceScopeCreateRequest : RequestBase
    {
        /// <summary>
        ///     Api资源编号
        /// </summary>

        [Required]
        [Display(Name = "Api资源编号")]
        public Guid ApiResourceId { get; set; }

        /// <summary>
        ///     名称
        /// </summary>

        [Required]
        [StringLength(200, ErrorMessage = "名称输入过长，不能超过200位")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        ///     显示名称
        /// </summary>

        [Display(Name = "显示名称")]
        [StringLength(200, ErrorMessage = "显示名称输入过长，不能超过200位")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     描述
        /// </summary>

        [Display(Name = "描述")]
        [StringLength(1000, ErrorMessage = "描述输入过长，不能超过1000位")]
        public string Description { get; set; }

        /// <summary>
        ///     指定用户是否可以在同意屏幕上取消选择范围（如果同意屏幕要实现此类功能）。默认为false。
        /// </summary>

        [Required]
        [Display(Name = "是否可以在同意屏幕上取消选择范围")]
        public bool Required { get; set; }

        /// <summary>
        ///     指定同意屏幕是否会强调此范围（如果同意屏幕要实现此类功能）。将此设置用于敏感或重要范围。默认为false。
        /// </summary>

        [Required]
        [Display(Name = "是否会强调此范围")]
        public bool Emphasize { get; set; }

        /// <summary>
        ///     指定此范围是否显示在发现文档中。默认为true。
        /// </summary>

        [Required]
        [Display(Name = "是否显示在发现文档中")]
        public bool ShowInDiscoveryDocument { get; set; } = true;

        /// <summary>
        ///     应包含在访问令牌中的关联用户声明类型列表
        /// </summary>

        [Display(Name = "用户声明类型列表")]
        public List<string> UserClaims { get; set; }
    }
}
