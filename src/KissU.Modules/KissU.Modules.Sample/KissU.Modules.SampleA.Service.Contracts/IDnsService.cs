using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IDnsService
    /// Implements the <see cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
    [ServiceBundle("Dns/{Service}")]
    public interface IDnsService : IServiceKey
    {
    }
}