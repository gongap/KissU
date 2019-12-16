// <copyright file="PersistedGrantDto.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.IdentityServer.Service.Contracts.Dtos
{
    /// <summary>
    /// 认证操作数据的数据传输对象
    /// </summary>
    public class PersistedGrantDto : DtoBase
    {
        /// <summary>
        /// 标识
        /// </summary>

        [Display(Name = "标识")]
        public string Key { get; set; }

        /// <summary>
        /// 主体
        /// </summary>

        [Display(Name = "主体")]
        public string SubjectId { get; set; }

        /// <summary>
        /// 主体名称
        /// </summary>

        [Display(Name = "主体名称")]
        public string SubjectName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>

        [Display(Name = "类型")]
        public string Type { get; set; }

        /// <summary>
        /// 应用程序编号
        /// </summary>

        [Display(Name = "应用程序编号")]
        public string ClientId { get; set; }

        /// <summary>
        /// 应用程序名称
        /// </summary>

        [Display(Name = "应用程序名称")]
        public string ClientName { get; set; }

        /// <summary>
        /// 值
        /// </summary>

        [Display(Name = "值")]
        public string Data { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        [Display(Name = "创建时间")]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>

        [Display(Name = "到期时间")]
        public DateTime? Expiration { get; set; }
    }
}
