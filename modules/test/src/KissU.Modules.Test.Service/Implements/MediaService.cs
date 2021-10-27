using KissU.Modules.Test.Service.Contracts;
using KissU.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissU.Modules.Test.Service.Implements
{
    public class MediaService : WSBehavior, IMediaService
    {
        public   Task Push(IEnumerable<byte> data)
        {
              this.GetClient().Broadcast(data.ToArray());
            return Task.CompletedTask;
        }
    }
}