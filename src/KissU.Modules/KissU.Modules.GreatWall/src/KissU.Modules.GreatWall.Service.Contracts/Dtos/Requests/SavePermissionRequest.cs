// <copyright file="SavePermissionRequest.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Util.Applications.Dtos;

    /// <summary>
    /// 保存权限参数
    /// </summary>
    public class SavePermissionRequest : RequestBase
    {
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// 角色标识
        /// </summary>
        [Required(ErrorMessage = "角色不能为空")]
        public Guid? RoleId { get; set; }

        /// <summary>
        /// 资源标识
        /// </summary>
        public string ResourceIds { get; set; }

        /// <summary>
        /// 拒绝
        /// </summary>
        public bool? IsDeny { get; set; }
    }
}
