using System.Net;
using KissU.DotNetty.DNS.Codecs.Messages;
using KissU.DotNetty.DNS.Codecs.Records;

namespace KissU.DotNetty.DNS
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