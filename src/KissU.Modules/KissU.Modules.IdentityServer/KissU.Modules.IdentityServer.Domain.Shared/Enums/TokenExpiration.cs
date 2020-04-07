namespace KissU.Modules.IdentityServer.Domain.Shared.Enums
{
    /// <summary>
    /// 令牌到期类型
    /// </summary>
    public enum TokenExpiration
    {
        /// <summary>
        /// 滑动令牌到期
        /// </summary>
        Sliding = 0,

        /// <summary>
        /// 绝对令牌到期
        /// </summary>
        Absolute = 1
    }
}