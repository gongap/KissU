using System.ComponentModel.DataAnnotations;

namespace KissU.Modules.Account.Application.Contracts.Models
{
    /// <summary>
    /// 登录请求参数
    /// </summary>
    public class SignInDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Passowrd { get; set; }
    }
}
