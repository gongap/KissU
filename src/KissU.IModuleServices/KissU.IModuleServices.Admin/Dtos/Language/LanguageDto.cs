using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace KFNets.Veterinary.Service.Dtos.Systems
{
    /// <summary>
    /// 语言国际化参数
    /// </summary>
    public class LanguageDto : DtoBase
    {
        /// <summary>
        /// 语言配置
        /// </summary>
        [Display(Name = "语言配置")]
        public List<LanguageDetailDto> Details { get; set; }

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
        public Byte[] Version { get; set; }
    }
}