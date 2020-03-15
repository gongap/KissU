using System;
using KissU.Util.Sessions;

namespace KissU.Util.Datas.Tests.Integration.Commons
{
    /// <summary>
    /// 用户会话
    /// </summary>
    public class Session : ISession
    {
        /// <summary>
        /// 初始化用户会话
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public Session(string userId)
        {
            UserId = userId;
        }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// 是否认证
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsAuthenticated => throw new NotImplementedException();
    }
}