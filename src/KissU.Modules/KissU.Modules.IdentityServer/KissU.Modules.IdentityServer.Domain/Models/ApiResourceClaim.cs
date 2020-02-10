namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// Api资源用户声明
    /// </summary>
    public class ApiResourceClaim : UserClaim
    {
        /// <summary>
        /// Api资源
        /// </summary>
        public ApiResource ApiResource { get; set; }
    }
}