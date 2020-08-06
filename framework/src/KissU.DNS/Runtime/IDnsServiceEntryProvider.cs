namespace KissU.DNS.Runtime
{
    /// <summary>
    /// Interface IDnsServiceEntryProvider
    /// </summary>
    public interface IDnsServiceEntryProvider
    {
        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <returns>DnsServiceEntry.</returns>
        DnsServiceEntry GetEntry();
    }
}