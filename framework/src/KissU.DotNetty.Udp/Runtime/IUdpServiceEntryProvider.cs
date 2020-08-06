namespace KissU.DotNetty.Udp.Runtime
{
    /// <summary>
    /// Interface IUdpServiceEntryProvider
    /// </summary>
    public interface IUdpServiceEntryProvider
    {
        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <returns>UdpServiceEntry.</returns>
        UdpServiceEntry GetEntry();
    }
}