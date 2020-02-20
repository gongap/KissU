using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IDnsService
    /// Implements the <see cref="KissU.Core.CPlatform.Ioc.IServiceKey" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Ioc.IServiceKey" />
    [ServiceBundle("Dns/{Service}")]
    public interface IDnsService : IServiceKey
    {
    }
}