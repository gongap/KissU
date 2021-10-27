using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;

namespace KissU.Modules.Test.Service.Contracts
{
    [ServiceBundle("Dns/{Service}")]
     public interface IDnsService : IServiceKey
    {
    }
}
