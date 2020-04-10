using System.Net;
using System.Threading.Tasks;
using ARSoft.Tools.Net;
using ARSoft.Tools.Net.Dns;
using DotNetty.Codecs.DNS.Records;

namespace KissU.Surging.DNS.Utilities
{
    /// <summary>
    /// DnsClientProvider.
    /// </summary>
    public class DnsClientProvider
    {
        /// <summary>
        /// Resolves the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="recordType">Type of the record.</param>
        /// <param name="recordClass">The record class.</param>
        /// <returns>Task&lt;DnsMessage&gt;.</returns>
        public async Task<DnsMessage> Resolve(string name, DnsRecordType recordType,
            DnsRecordClass recordClass = DnsRecordClass.IN)
        {
            var dnsMessage = await GetDnsClient().ResolveAsync(DomainName.Parse(name), (RecordType) recordType.IntValue,
                (RecordClass) (int) recordClass);
            return dnsMessage;
        }

        /// <summary>
        /// Gets the DNS client.
        /// </summary>
        /// <returns>DnsClient.</returns>
        public DnsClient GetDnsClient()
        {
            var dnsOption = AppConfig.DnsOption;
            var dnsClient = new DnsClient(IPAddress.Parse(dnsOption.RootDnsAddress), dnsOption.QueryTimeout);
            return dnsClient;
        }

        /// <summary>
        /// Instances this instance.
        /// </summary>
        /// <returns>DnsClientProvider.</returns>
        public static DnsClientProvider Instance()
        {
            return new DnsClientProvider();
        }
    }
}