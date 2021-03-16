namespace KissU.Modules.Account.Service.Contracts.Models
{
    /// <summary>
    /// 登录请求参数
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Captcha { get; set; }
    }
}