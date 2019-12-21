// <copyright file="ClientCreateRequest.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using KissU.Modules.IdentityServer.Domain.Shared.Enums;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.IdentityServer.Application.Dtos.Requests
{
    /// <summary>
    /// 创建应用程序参数对象
    /// </summary>
    public class ClientCreateRequest : RequestBase
    {
        /// <summary>
        /// 应用程序唯一编码
        /// </summary>

        [Required]
        [StringLength(60, ErrorMessage = "应用程序唯一编码输入过长，不能超过60位")]
        [Display(Name = "应用程序唯一编码")]
        public string ClientCode { get; set; }

        /// <summary>
        /// 应用程序显示名称
        /// </summary>

        [StringLength(200, ErrorMessage = "应用程序显示名称输入过长，不能超过200位")]
        [Display(Name = "应用程序显示名称")]
        public string ClientName { get; set; }

        /// <summary>
        /// 应用类型
        /// </summary>
        [Required(ErrorMessage = "应用类型不能为空")]
        [Display(Name = "应用类型")]

        public ClientType ClientType { get; set; }
    }
}
