using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.Protocol.WS.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IMediaService
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("Api/{Service}")]
    [BehaviorContract(IgnoreExtensions = true, Protocol = "media")]
    public interface IMediaService : IServiceKey
    {
        /// <summary>
        /// Pushes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Task.</returns>
        Task Push(IEnumerable<byte> data);
    }
}