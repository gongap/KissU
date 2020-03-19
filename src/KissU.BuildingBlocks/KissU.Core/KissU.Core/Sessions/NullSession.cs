namespace KissU.Util.Sessions
{
    /// <summary>
    /// 空用户会话
    /// </summary>
    public class NullSession : ISession
    {
        /// <summary>
        /// 空用户会话实例
        /// </summary>
        public static readonly ISession Instance = new NullSession();

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated => false;

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId => string.Empty;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName => string.Empty;
    }
}