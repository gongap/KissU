using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 注销重定向Uri
    /// </summary>
    public class ClientPostLogoutRedirectUri : ValueObjectBase<ClientPostLogoutRedirectUri>
    {
        /// <summary>
        /// 注销重定向Uri
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string PostLogoutRedirectUri { get; set; }
    }
}
