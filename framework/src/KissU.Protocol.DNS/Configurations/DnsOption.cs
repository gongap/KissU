namespace KissU.Protocol.DNS.Configurations
{
    /// <summary>
    /// DnsOption.
    /// </summary>
    public class DnsOption
    {
        /// <summary>
        /// Gets or sets the root DNS address.
        /// </summary>
        public string RootDnsAddress { get; set; }

        /// <summary>
        /// Gets or sets the query timeout.
        /// </summary>
        public int QueryTimeout { get; set; } = 1000;
    }
}