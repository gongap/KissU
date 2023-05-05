namespace KissU.DotNetty.DNS.Codecs.Messages
{
    public class DefaultDnsQuery : AbstractDnsMessage, IDnsQuery
    {
        public DefaultDnsQuery(int id) : base(id) { }

        public DefaultDnsQuery(int id, DnsOpCode opCode) : base(id, opCode) { }
    }
}
