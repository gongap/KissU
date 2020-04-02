using System.ComponentModel.DataAnnotations;
using KissU.Core.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 应用跨域源
    /// </summary>
    public class ClientCorsOrigin : ValueObjectBase<ClientCorsOrigin>
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 源
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Origin { get; set; }

        public override string ToString()
        {
            return Origin;
        }
    }
}