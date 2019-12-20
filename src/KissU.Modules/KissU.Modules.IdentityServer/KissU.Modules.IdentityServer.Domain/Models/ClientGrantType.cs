using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 授权类型
    /// </summary>
    public class ClientGrantType : ValueObjectBase<ClientGrantType>
    {
        public ClientGrantType(string grantType)
        {
            GrantType = grantType;
        }

        /// <summary>
        /// 授权类型
        /// </summary>
        public string GrantType { get; set; }
    }
}
