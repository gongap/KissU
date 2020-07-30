using KissU.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Services.SampleA.Contract
{
    /// <summary>
    /// Interface IDnsService
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("Dns/{Service}")]
    public interface IDnsService : IServiceKey
    {
    }
}