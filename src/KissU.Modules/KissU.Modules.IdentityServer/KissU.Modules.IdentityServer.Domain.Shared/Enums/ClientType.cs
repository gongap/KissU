namespace KissU.Modules.IdentityServer.Domain.Shared.Enums
{
    /// <summary>
    /// 客户端类型
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// 空
        /// </summary>
        Empty = 0,

        /// <summary>
        /// Web简单模式
        /// </summary>
        WebImplicit = 1,

        /// <summary>
        /// Web混合模式
        /// </summary>
        WebHybrid = 2,

        /// <summary>
        /// 单页Web应用
        /// </summary>
        Spa = 3,

        /// <summary>
        /// 原生APP模式
        /// </summary>
        Native = 4,

        /// <summary>
        /// 机器
        /// </summary>
        Machine = 5
    }
}