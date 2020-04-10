using System.Collections.Generic;
using KissU.Surging.Consul.WatcherProvider.Implementation;

namespace KissU.Surging.Consul.WatcherProvider
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