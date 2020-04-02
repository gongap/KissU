using System.ComponentModel.DataAnnotations;
using KissU.Core.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 外部IdP
    /// </summary>
    public class ClientIdPRestriction : ValueObjectBase<ClientIdPRestriction>
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 提供程序
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Provider { get; set; }

        public override string ToString()
        {
            return Provider;
        }
    }
}