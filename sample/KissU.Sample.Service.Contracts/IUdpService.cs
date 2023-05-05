using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("Udp/{Service}/{Async}")]
    public interface IUdpService : IServiceKey
    {
    }
}
