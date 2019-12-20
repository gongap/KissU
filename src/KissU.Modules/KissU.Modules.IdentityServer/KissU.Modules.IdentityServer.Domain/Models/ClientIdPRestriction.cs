using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    public class ClientIdPRestriction : ValueObjectBase<ClientIdPRestriction>
    {
        public string Provider { get; set; }
    }
}
