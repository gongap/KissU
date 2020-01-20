using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 身份资源用户声明
    /// </summary>
    public class IdentityResourceClaim : UserClaim
    {
        /// <summary>
        /// 身份资源
        /// </summary>
        public IdentityResource IdentityResource { get; set; }
    }
}