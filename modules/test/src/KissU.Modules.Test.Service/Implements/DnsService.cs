using System.Net;
using System.Threading.Tasks;
using KissU.DotNetty.DNS.Runtime;
using KissU.Modules.Test.Service.Contracts;

namespace KissU.Modules.Test.Service.Implements
{
    public class DnsService : DnsBehavior, IDnsService
    {
        public override Task<IPAddress> Resolve(string domainName)
        {
            if (domainName == "localhost")
            {
                return Task.FromResult<IPAddress>(IPAddress.Parse("127.0.0.1"));
            }

            return Task.FromResult<IPAddress>(null);
        }
    }
}
