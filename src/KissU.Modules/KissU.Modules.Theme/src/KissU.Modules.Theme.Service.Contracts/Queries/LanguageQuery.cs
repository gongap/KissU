using System.ComponentModel.DataAnnotations;
using Util.Datas.Queries;

namespace KissU.Modules.Theme.Service.Contracts.Queries
{
    /// <summary>
    /// 语言国际化查询参数
    /// </summary>
    public class LanguageQuery : QueryParameter
    {
        private string _code = string.Empty;

        /// <summary>
        /// 编码
        /// </summary>
        [Display(Name = "编码")]
        public string Code
        {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }

        private string _text = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Text
        {
            get => _text == null ? string.Empty : _text.Trim();
            set => _text = value;
        }

        private string _abbr = string.Empty;

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