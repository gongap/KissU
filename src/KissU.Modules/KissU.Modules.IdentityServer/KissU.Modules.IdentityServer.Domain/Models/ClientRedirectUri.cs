using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 令牌或授权码的URI
    /// </summary>
    public class ClientRedirectUri : ValueObjectBase<ClientRedirectUri>
    {
        /// <summary>
        /// 令牌或授权码的URI
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string RedirectUri { get; set; }
    }
}