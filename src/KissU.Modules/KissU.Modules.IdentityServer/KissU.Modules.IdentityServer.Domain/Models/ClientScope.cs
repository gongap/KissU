using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 应用许可范围
    /// </summary>
    public class ClientScope : ValueObjectBase<ClientScope>
    {
        /// <summary>
        /// 范围
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Scope { get; set; }
    }
}
