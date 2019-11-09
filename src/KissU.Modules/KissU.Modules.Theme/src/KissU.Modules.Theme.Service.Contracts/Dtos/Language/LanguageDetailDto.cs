using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;

namespace KissU.Modules.Theme.Service.Contracts.Dtos.Language
{
    /// <summary>
    /// 语言国际化配置参数
    /// </summary>
    public class LanguageDetailDto : DtoBase
    {
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