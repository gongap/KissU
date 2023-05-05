using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("Dns/{Service}/{Async}")]
     public interface IDnsService : IServiceKey
    {
    }
}
