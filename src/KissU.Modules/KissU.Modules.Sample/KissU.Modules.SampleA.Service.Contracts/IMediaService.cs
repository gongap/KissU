using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Core.Protocol.WS.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IMediaService
    /// Implements the <see cref="KissU.Core.CPlatform.Ioc.IServiceKey" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Ioc.IServiceKey" />
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