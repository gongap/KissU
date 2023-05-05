using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.WebSocket;
using KissU.Msm.Sample.Service.Contracts;

namespace KissU.Msm.Sample.Service.Implements
{
    public class MediaService : WSBehavior, IMediaService
    {
        public   Task PushAsync(IEnumerable<byte> data)
        {
              this.GetClient().Broadcast(data.ToArray());
            return Task.CompletedTask;
        }
    }
}