// <copyright file="LanguageQuery.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Service.Contracts.Queries
{
    using Util.Datas.Queries;

    /// <summary>
    /// 语言国际化查询参数
    /// </summary>
    public class LanguageQuery : QueryParameter
    {
        private string _abbr = string.Empty;
        private string _code = string.Empty;

        private string _text = string.Empty;

        /// <summary>
        /// 编码
        /// </summary>
        [Display(Name = "编码")]
        public string Code
        {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Text
        {
            get => _text == null ? string.Empty : _text.Trim();
            set => _text = value;
        }

        /// <summary>
        /// 简称
        /// </summary>
        [Display(Name = "简称")]
        public string Abbr
        {
            get => _abbr == null ? string.Empty : _abbr.Trim();
            set => _abbr = value;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public bool? IsEnabled { get; set; }
    }
}
