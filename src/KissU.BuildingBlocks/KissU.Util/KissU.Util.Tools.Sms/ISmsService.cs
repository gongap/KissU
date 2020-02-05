using System.Threading.Tasks;
using KissU.Util.Dependency;

namespace KissU.Util.Tools.Sms
{
    /// <summary>
    /// 短信服务
    /// </summary>
    public interface ISmsService : IScopeDependency
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="content">内容</param>
        /// <returns>Task&lt;SmsResult&gt;.</returns>
        Task<SmsResult> SendAsync(string mobile, string content);
    }
}