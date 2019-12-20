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
        public string RedirectUri { get; set; }
    }
}
