using KissU.DotNetty.Udp.Runtime;
using KissU.Modules.Test.Service.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Modules.Test.Service.Implements
{
    public class UdpService : UdpBehavior, IUdpService
    {
        public override async Task<bool> Dispatch(IEnumerable<byte> bytes)
        {
            await GetService<IMediaService>().Push(bytes);
            return await Task.FromResult(true);
        }
    }
}
