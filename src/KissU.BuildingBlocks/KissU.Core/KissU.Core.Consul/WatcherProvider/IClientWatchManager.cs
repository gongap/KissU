using System.Collections.Generic;
using KissU.Core.Consul.WatcherProvider.Implementation;

namespace KissU.Core.Consul.WatcherProvider
{
    public interface IClientWatchManager
    {
        Dictionary<string, HashSet<Watcher>> DataWatches { get; set; }
    }
}
