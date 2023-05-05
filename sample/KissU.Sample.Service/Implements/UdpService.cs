using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.DotNetty.Udp.Runtime;
using KissU.Msm.Sample.Service.Contracts;

namespace KissU.Msm.Sample.Service.Implements
{
    public class UdpService : UdpBehavior, IUdpService
    {
        public override async Task<bool> Dispatch(IEnumerable<byte> bytes)
        {
            await GetService<IMediaService>().PushAsync(bytes);
            return await Task.FromResult(true);
        }
    }
}
