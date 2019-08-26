using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KissU.Modules.Admin.Domain.Base;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace KissU.Modules.Admin.Domain.Models
{
    /// <summary>
    /// 语言国际化
    /// </summary>
    [DisplayName("语言国际化")]
    public partial class Language: MasterEntity<LanguageDetail>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public Language() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public Language(Guid id) : base(id)
        {
            this.Details = new List<LanguageDetail>();
        }

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
    }
}