using System.Collections.Generic;
using KissU.Consul.WatcherProvider.Implementation;

namespace KissU.Consul.WatcherProvider
{
    /// <summary>
    /// Interface IClientWatchManager
    /// </summary>
    public interface IClientWatchManager
    {
        /// <summary>
        /// Gets or sets the data watches.
        /// </summary>
        Dictionary<string, HashSet<Watcher>> DataWatches { get; set; }
    }
}