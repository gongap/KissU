using System.ComponentModel.DataAnnotations;
using KissU.Util.Ddd.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 令牌或授权码的URI
    /// </summary>
    public class ClientRedirectUri : ValueObjectBase<ClientRedirectUri>
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 令牌或授权码的URI
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string RedirectUri { get; set; }

        public override string ToString()
        {
            return RedirectUri;
        }
    }
}