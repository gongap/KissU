using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 应用跨域源
    /// </summary>
    public class ClientCorsOrigin : ValueObjectBase<ClientCorsOrigin>
    {
        /// <summary>
        /// 源
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Origin { get; set; }
    }
}
