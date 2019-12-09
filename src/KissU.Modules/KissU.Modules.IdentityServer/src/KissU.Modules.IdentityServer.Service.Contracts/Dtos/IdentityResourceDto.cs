// <copyright file="IdentityResourceDto.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Contracts.Dtos
{
    using System.Collections.Generic;
    using Util.Applications.Dtos;

    /// <summary>
    ///     身份资源数据传输对象
    /// </summary>
    public class IdentityResourceDto : DtoBase
    {
        /// <summary>
        ///     身份资源的唯一名称。这是应用程序将用于授权请求中的scope参数的值。
        /// </summary>

        [Required]
        [StringLength(200, ErrorMessage = "名称输入过长，不能超过200位")]
        [Display(Name = "API的唯一名称")]
        public string Name { get; set; }

        /// <summary>
        ///     显示名称。该值将用于例如同意屏幕上。
        /// </summary>

        [StringLength(200, ErrorMessage = "名称输入过长，不能超过200位")]
        [Display(Name = "显示名称")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     描述。该值将用于例如同意屏幕上。
        /// </summary>

        [StringLength(1000, ErrorMessage = "名称输入过长，不能超过1000位")]
        [Display(Name = "描述")]
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
        ///     指示此资源是否已启用且可以请求。默认为true。
        /// </summary>

        [Required]
        [Display(Name = "否已启用")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     应包含在身份令牌中的关联用户声明类型的列表。
        /// </summary>

        [Display(Name = "用户声明类型的列表")]
        public List<string> UserClaims { get; set; }

        /// <summary>
        ///     版本号
        /// </summary>

        [Display(Name = "版本号")]
        public byte[] Version { get; set; }
    }
}
