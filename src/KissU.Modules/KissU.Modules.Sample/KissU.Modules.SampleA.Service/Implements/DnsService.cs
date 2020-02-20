using System.Net;
using System.Threading.Tasks;
using KissU.Core.DNS.Runtime;
using KissU.Modules.SampleA.Service.Contracts;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// DnsService.
    /// Implements the <see cref="KissU.Core.DNS.Runtime.DnsBehavior" />
    /// Implements the <see cref="KissU.Modules.SampleA.Service.Contracts.IDnsService" />
    /// </summary>
    /// <seealso cref="KissU.Core.DNS.Runtime.DnsBehavior" />
    /// <seealso cref="KissU.Modules.SampleA.Service.Contracts.IDnsService" />
    public class DnsService : DnsBehavior, IDnsService
    {
        /// <summary>
        /// Resolves the specified domain name.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns>Task&lt;IPAddress&gt;.</returns>
        public override Task<IPAddress> Resolve(string domainName)
        {
            if (domainName == "localhost")
            {
                return Task.FromResult(IPAddress.Parse("127.0.0.1"));
            }

            return Task.FromResult<IPAddress>(null);
        }
    }
}