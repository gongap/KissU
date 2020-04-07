namespace KissU.Modules.IdentityServer.Domain.Shared.Enums
{
    /// <summary>
    /// 令牌使用类型
    /// </summary>
    public enum TokenUsage
    {
        /// <summary>
        /// 重新使用刷新令牌句柄
        /// </summary>
        ReUse = 0,

        /// <summary>
        /// 每次发出新的刷新令牌句柄
        /// </summary>
        OneTimeOnly = 1
    }
}