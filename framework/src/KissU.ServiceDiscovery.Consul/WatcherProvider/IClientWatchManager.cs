using System.Collections.Generic;
using KissU.ServiceDiscovery.Consul.WatcherProvider.Implementation;

namespace KissU.ServiceDiscovery.Consul.WatcherProvider
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