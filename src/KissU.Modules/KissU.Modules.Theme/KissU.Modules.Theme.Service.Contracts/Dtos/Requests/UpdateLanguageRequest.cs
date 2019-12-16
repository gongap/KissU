// <copyright file="UpdateLanguageRequest.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.Theme.Service.Contracts.Dtos.Requests
{
    /// <summary>
    /// 修改语言参数
    /// </summary>
    public class UpdateLanguageRequest : RequestBase
    {
        /// <summary>
        /// 语言配置
        /// </summary>
        [Display(Name = "语言配置")]
        public List<LanguageDetailRequest> Details { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        [Required(ErrorMessage = "标识不能为空")]
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        [StringLength(10)]
        [Display(Name = "编码")]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength(64)]
        [Display(Name = "名称")]
        public string Text { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [StringLength(128)]
        [Display(Name = "简称")]
        public string Abbr { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        [DataMember]
        public byte[] Version { get; set; }

        /// <summary>
        /// 语言国际化配置参数
        /// </summary>
        public class LanguageDetailRequest : RequestBase
        {
            /// <summary>
            /// 标识
            /// </summary>
            [Required(ErrorMessage = "标识不能为空")]
            [DataMember]
            public string Id { get; set; }

            /// <summary>
            /// 键
            /// </summary>
            [Required(ErrorMessage = "键不能为空")]
            [StringLength(256)]
            [Display(Name = "键")]
            public string Key { get; set; }

            /// <summary>
            /// 值
            /// </summary>
            [Required(ErrorMessage = "值不能为空")]
            [Display(Name = "值")]
            public string Value { get; set; }
        }
    }
}
