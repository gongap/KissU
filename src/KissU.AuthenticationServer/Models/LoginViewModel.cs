using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KissU.IModuleServices.GreatWall.Dtos.Requests;
using Util;

namespace KissU.AuthenticationServer.Models {
    /// <summary>
    /// 登录参数
    /// </summary>
    public class LoginViewModel {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 记住密码
        /// </summary>
        [Display( Name = "记住密码" )]
        public bool Remember { get; set; }
        /// <summary>
        /// 允许记住密码
        /// </summary>
        public bool AllowRemember { get; set; } = true;
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 启用本地登录
        /// </summary>
        public bool EnableLocalLogin { get; set; } = true;
        /// <summary>
        /// 外部认证提供器列表
        /// </summary>
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        /// <summary>
        /// 是否仅支持外部登录
        /// </summary>
        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        /// <summary>
        /// 外部认证方案
        /// </summary>
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
        /// <summary>
        /// 可显示的外部认证提供器列表
        /// </summary>
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where( x => x.DisplayName.IsEmpty() == false );
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 转换为登录请求
        /// </summary>
        public LoginRequest ToLoginRequest() {
            var result = new LoginRequest {
                UserName = UserName,
                Password = Password,
                Remember = Remember
            };
            return result;
        }
    }
}