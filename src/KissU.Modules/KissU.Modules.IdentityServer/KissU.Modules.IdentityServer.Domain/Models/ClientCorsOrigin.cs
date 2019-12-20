using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    public class ClientCorsOrigin : ValueObjectBase<ClientCorsOrigin>
    {
        public string Origin { get; set; }
    }
}
