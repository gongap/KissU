using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    public class ClientPostLogoutRedirectUri : ValueObjectBase<ClientPostLogoutRedirectUri>
    {
        public string PostLogoutRedirectUri { get; set; }
    }
}
