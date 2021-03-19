using System.ComponentModel.DataAnnotations;

namespace KissU.Modules.Account.Service.Contracts.Models
{
    /// <summary>
    /// 授权请求参数
    /// </summary>
    public class AuthDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [Phone]
        public string Mobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Captcha { get; set; }
    }
}
