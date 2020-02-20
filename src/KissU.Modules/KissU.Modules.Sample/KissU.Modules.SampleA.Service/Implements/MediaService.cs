using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.Protocol.WS;
using KissU.Modules.SampleA.Service.Contracts;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// MediaService.
    /// Implements the <see cref="KissU.Core.Protocol.WS.WSBehavior" />
    /// Implements the <see cref="KissU.Modules.SampleA.Service.Contracts.IMediaService" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.WS.WSBehavior" />
    /// <seealso cref="KissU.Modules.SampleA.Service.Contracts.IMediaService" />
    public class MediaService : WSBehavior, IMediaService
    {
        /// <summary>
        /// Pushes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Task.</returns>
        public Task Push(IEnumerable<byte> data)
        {
            GetClient().Broadcast(data.ToArray());
            return Task.CompletedTask;
        }
    }
}