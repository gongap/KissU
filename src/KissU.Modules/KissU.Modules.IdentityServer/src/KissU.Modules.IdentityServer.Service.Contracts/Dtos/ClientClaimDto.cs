﻿using System;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;

namespace KissU.Modules.IdentityServer.Service.Contracts.Dtos
{
    /// <summary>
    /// 应用程序声明数据传输对象
    /// </summary>
    public class ClientClaimDto : DtoBase
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        
        [Required]
        public Guid ClientId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        
        [Display(Name = "类型")]
        public string Type { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [Required]
        
        [Display(Name = "值")]
        public string Value { get; set; }
    }
}