using System.ComponentModel.DataAnnotations;

namespace KissU.IdentityServer.Models.AccountViewModels
{
    /// <summary>
    /// 使用双因素代码登录视图模型
    /// </summary>
    public class LoginWith2faViewModel
    {
        /// <summary>
        /// 双因素代码
        /// </summary>
        [Required]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator code")]
        public string TwoFactorCode { get; set; }

        /// <summary>
        /// 记住机器
        /// </summary>
        [Display(Name = "Remember this machine")]
        public bool RememberMachine { get; set; }

        /// <summary>
        /// 记住账号
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
