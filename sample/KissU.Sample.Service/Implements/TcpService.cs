using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.DotNetty.Tcp.Runtime;
using KissU.Msm.Sample.Service.Contracts;

namespace KissU.Msm.Sample.Service.Implements
{
    public class TcpService : TcpBehavior, ITcpService
    {
        public override async Task<bool> Dispatch(IEnumerable<byte> bytes)
        {
            await Write(bytes);
            return await Task.FromResult(true);
        }
    }
}
