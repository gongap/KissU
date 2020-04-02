using System.ComponentModel.DataAnnotations;
using KissU.Core.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 注销重定向Uri
    /// </summary>
    public class ClientPostLogoutRedirectUri : ValueObjectBase<ClientPostLogoutRedirectUri>
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 注销重定向Uri
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string PostLogoutRedirectUri { get; set; }

        public override string ToString()
        {
            return PostLogoutRedirectUri;
        }
    }
}