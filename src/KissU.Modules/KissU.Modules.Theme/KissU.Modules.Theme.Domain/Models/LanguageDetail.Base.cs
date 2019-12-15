// <copyright file="LanguageDetail.Base.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Domain.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using KissU.Modules.Theme.Domain.Base;

    /// <summary>
    /// 语言国际化配置
    /// </summary>
    [DisplayName("语言国际化配置")]
    public partial class LanguageDetail : DetailEntity
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public LanguageDetail() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public LanguageDetail(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 键
        /// </summary>
        [DisplayName("键")]
        [Required(ErrorMessage = "键不能为空")]
        [StringLength(256)]
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DisplayName("值")]
        [Required(ErrorMessage = "值不能为空")]
        public string Value { get; set; }
    }
}
