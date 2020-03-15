using System.ComponentModel.DataAnnotations;

namespace KissU.IdentityServer.Models.AccountViewModels
{
    /// <summary>
    /// 使用恢复码登录视图模型
    /// </summary>
    public class LoginWithRecoveryCodeViewModel
    {
        /// <summary>
        /// 恢复码
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; }
    }
}
