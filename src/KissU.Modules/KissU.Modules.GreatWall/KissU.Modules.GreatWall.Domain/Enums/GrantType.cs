using System.ComponentModel;

namespace KissU.Modules.GreatWall.Domain.Enums
{
    /// <summary>
    /// 授权类型
    /// </summary>
    public enum GrantType
    {
        /// <summary>
        /// 简单模式
        /// </summary>
        [Description("Implicit")] Implicit = 1,

        /// <summary>
        /// 授权码模式
        /// </summary>
        [Description("Authorization Code")] AuthorizationCode = 2,

        /// <summary>
        /// 混合模式
        /// </summary>
        [Description("Hybrid")] Hybrid = 3,

        /// <summary>
        /// 客户端凭据模式
        /// </summary>
        [Description("Client Credentials")] ClientCredentials = 4,

        /// <summary>
        /// 密码模式
        /// </summary>
        [Description("Resource Owner Password")]
        ResourceOwnerPassword = 5
    }
}