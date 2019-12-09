// <copyright file="PermissionQuery.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Contracts.Queries
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Util.Datas.Queries;

    /// <summary>
    /// 权限查询参数
    /// </summary>
    public class PermissionQuery : QueryParameter
    {
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// 权限标识
        /// </summary>
        public Guid? PermissionId { get; set; }

        /// <summary>
        /// 角色标识
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// 资源标识
        /// </summary>
        public Guid? ResourceId { get; set; }

        /// <summary>
        /// 拒绝
        /// </summary>
        [Display(Name = "拒绝")]
        public bool? IsDeny { get; set; }
    }
}
