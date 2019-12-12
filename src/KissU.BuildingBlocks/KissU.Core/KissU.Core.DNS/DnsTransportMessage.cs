using System.Net;
using DotNetty.Codecs.DNS.Messages;
using DotNetty.Codecs.DNS.Records;

namespace KissU.Core.DNS
{
   public class DnsTransportMessage
    {
        public IDnsResponse DnsResponse { get; set; }

        public IDnsQuestion DnsQuestion { get; set; }

        public IPAddress Address { get; set; }
    }
}
