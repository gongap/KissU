using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("Tcp/{Service}/{Async}")]
    public interface ITcpService : IServiceKey
    {
    }
}
