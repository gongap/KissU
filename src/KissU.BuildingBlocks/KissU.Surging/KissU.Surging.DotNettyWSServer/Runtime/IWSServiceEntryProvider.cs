using System.Collections.Generic;

namespace KissU.Surging.DotNettyWSServer.Runtime
{
    /// <summary>
    /// Interface IWSServiceEntryProvider
    /// </summary>
    public interface IWSServiceEntryProvider
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <returns>IEnumerable&lt;WSServiceEntry&gt;.</returns>
        IEnumerable<WSServiceEntry> GetEntries();
    }
}