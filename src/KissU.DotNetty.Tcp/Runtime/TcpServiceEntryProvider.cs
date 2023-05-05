namespace KissU.DotNetty.Tcp.Runtime
{
    /// <summary>
    /// Interface ITcpServiceEntryProvider
    /// </summary>
    public interface ITcpServiceEntryProvider
    {
        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <returns>TcpServiceEntry.</returns>
        TcpServiceEntry GetEntry();
    }
}
