namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// Api许可范围用户声明
    /// </summary>
    public class ApiScopeClaim : UserClaim
    {
        /// <summary>
        /// Api许可范围
        /// </summary>
        public ApiScope ApiScope { get; set; }
    }
}