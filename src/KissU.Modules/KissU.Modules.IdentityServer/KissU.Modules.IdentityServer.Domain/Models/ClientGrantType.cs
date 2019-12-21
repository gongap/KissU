using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 授权类型
    /// </summary>
    public class ClientGrantType : ValueObjectBase<ClientGrantType>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="grantType"></param>
        public ClientGrantType(string grantType)
        {
            GrantType = grantType;
        }

        /// <summary>
        /// 授权类型
        /// </summary>
        [Required]
        [StringLength(250)]
        public string GrantType { get; set; }
    }
}
