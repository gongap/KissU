using System.Collections.Generic;
using System.Linq;

namespace KissU.Surging.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// WatchRegistration.
    /// </summary>
    public abstract class WatchRegistration
    {
        private readonly string clientPath;
        private readonly Watcher watcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchRegistration" /> class.
        /// </summary>
        /// <param name="watcher">The watcher.</param>
        /// <param name="clientPath">The client path.</param>
        protected WatchRegistration(Watcher watcher, string clientPath)
        {
            this.watcher = watcher;
            this.clientPath = clientPath;
        }

        /// <summary>
        /// Gets the watches.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, HashSet&lt;Watcher&gt;&gt;.</returns>
        protected abstract Dictionary<string, HashSet<Watcher>> GetWatches();

        /// <summary>
        /// Registers this instance.
        /// </summary>
        public void Register()
        {
            var watches = GetWatches();
            lock (watches)
            {
                HashSet<Watcher> watchers;
                watches.TryGetValue(clientPath, out watchers);
                if (watchers == null)
                {
                    watchers = new HashSet<Watcher>();
                    watches[clientPath] = watchers;
                }

                if (!watchers.Any(p => p.GetType() == watcher.GetType()))
                    watchers.Add(watcher);
            }
        }
    }
}