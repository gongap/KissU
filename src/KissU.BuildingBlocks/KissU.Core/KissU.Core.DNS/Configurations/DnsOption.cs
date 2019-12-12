namespace KissU.Core.DNS.Configurations
{
    public class DnsOption
    {
        public string RootDnsAddress { get; set; }

        public int QueryTimeout { get; set; } = 1000;
    }
}
