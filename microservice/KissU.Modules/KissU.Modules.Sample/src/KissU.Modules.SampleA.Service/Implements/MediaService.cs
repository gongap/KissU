using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.WebSocket;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// MediaService.
    /// Implements the <see cref="WSBehavior" />
    /// Implements the <see cref="IMediaService" />
    /// </summary>
    /// <seealso cref="WSBehavior" />
    /// <seealso cref="IMediaService" />
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