using System.Net;
using System.Threading.Tasks;
using KissU.DotNetty.DNS.Runtime;
using KissU.Msm.Sample.Service.Contracts;

namespace KissU.Msm.Sample.Service.Implements
{
    public class DnsService : DnsBehavior, IDnsService
    {
        public override Task<IPAddress> ResolveAsync(string domainName)
        {
            if (domainName == "localhost")
            {
                return Task.FromResult<IPAddress>(IPAddress.Parse("127.0.0.1"));
            }

            return Task.FromResult<IPAddress>(null);
        }
    }
}
