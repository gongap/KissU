using System.Net;
using DotNetty.Codecs.DNS.Messages;
using DotNetty.Codecs.DNS.Records;

namespace KissU.Surging.DNS
{
    /// <summary>
    /// DnsTransportMessage.
    /// </summary>
    public class DnsTransportMessage
    {
        /// <summary>
        /// Gets or sets the DNS response.
        /// </summary>
        public IDnsResponse DnsResponse { get; set; }

        /// <summary>
        /// Gets or sets the DNS question.
        /// </summary>
        public IDnsQuestion DnsQuestion { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public IPAddress Address { get; set; }
    }
}