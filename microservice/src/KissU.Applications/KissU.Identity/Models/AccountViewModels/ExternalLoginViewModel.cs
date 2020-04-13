using System.ComponentModel.DataAnnotations;

namespace KissU.Identity.Models.AccountViewModels
{
    /// <summary>
    /// 外部登录视图模型
    /// </summary>
    public class ExternalLoginViewModel
    {
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
