using System.Threading.Tasks;
using KissU.Core.Domains.Services;
using KissU.Modules.GreatWall.Domain.Models;

namespace KissU.Modules.GreatWall.Domain.Services.Abstractions
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserManager : IDomainService
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        /// <returns>Task.</returns>
        Task CreateAsync(User user, string password);

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GenerateTokenAsync(string phone, string purpose, string application = "", string provider = "");

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="purpose">用途</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GenerateTokenAsync(User user, string purpose, string application = "", string provider = "");

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> VerifyTokenAsync(string phone, string purpose, string token, string application = "",
            string provider = "");

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="user">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> VerifyTokenAsync(User user, string purpose, string token, string application = "",
            string provider = "");

        /// <summary>
        /// 生成手机号注册令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="application">应用程序</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GenerateRegisterTokenAsync(string phone, string application = "");

        /// <summary>
        /// 验证手机号注册令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> VerifyRegisterTokenAsync(string phone, string token, string application = "");

        /// <summary>
        /// 生成电子邮件确认令牌
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        /// <summary>
        /// 激活电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        /// <returns>Task.</returns>
        Task ConfirmEmailAsync(User user, string token);

        /// <summary>
        /// 生成电子邮件重置密码令牌
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GenerateEmailPasswordResetTokenAsync(User user);

        /// <summary>
        /// 通过电子邮件重置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>Task.</returns>
        Task ResetPasswordByEmailAsync(User user, string token, string newPassword);

        /// <summary>
        /// 生成手机号重置密码令牌
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GeneratePhonePasswordResetTokenAsync(User user);

        /// <summary>
        /// 通过手机号重置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>Task.</returns>
        Task ResetPasswordByPhoneAsync(User user, string token, string newPassword);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="currentPassword">当前密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>Task.</returns>
        Task ChangePasswordAsync(User user, string currentPassword, string newPassword);

        /// <summary>
        /// 通过用户名查找
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>Task&lt;User&gt;.</returns>
        Task<User> FindByNameAsync(string userName);

        /// <summary>
        /// 通过电子邮件查找
        /// </summary>
        /// <param name="email">电子邮件</param>
        /// <returns>Task&lt;User&gt;.</returns>
        Task<User> FindByEmailAsync(string email);

        /// <summary>
        /// 通过手机号查找
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <returns>Task&lt;User&gt;.</returns>
        Task<User> FindByPhoneAsync(string phoneNumber);
    }
}