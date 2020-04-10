using System.ComponentModel.DataAnnotations;

namespace KissU.Services.Identity.Models.AccountViewModels
{
    /// <summary>
    /// 忘记密码视图模型
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
