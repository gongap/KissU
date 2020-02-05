using System.Security.Claims;
using IdentityModel;
using KissU.Util.AspNetCore.Helpers;
using KissU.Util.Sessions;

namespace KissU.Util.AspNetCore.Sessions
{
    /// <summary>
    /// 用户会话
    /// </summary>
    public class Session : ISession
    {
        /// <summary>
        /// 空用户会话
        /// </summary>
        public static readonly ISession Null = NullSession.Instance;

        /// <summary>
        /// 用户会话
        /// </summary>
        public static readonly ISession Instance = new Session();

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated => Web.Identity.IsAuthenticated;

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId
        {
            get
            {
                var result = Web.Identity.GetValue(JwtClaimTypes.Subject);
                return string.IsNullOrWhiteSpace(result) ? Web.Identity.GetValue(ClaimTypes.NameIdentifier) : result;
            }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName => Web.Identity.GetValue(ClaimTypes.NameIdentifier);
    }
}