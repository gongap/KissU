using System.Collections.Generic;

namespace KissU.Surging.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// ChildWatchRegistration.
    /// Implements the <see cref="KissU.Surging.Consul.WatcherProvider.Implementation.WatchRegistration" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Consul.WatcherProvider.Implementation.WatchRegistration" />
    public class ChildWatchRegistration : WatchRegistration
    {
        private readonly IClientWatchManager watchManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildWatchRegistration" /> class.
        /// </summary>
        /// <param name="watchManager">The watch manager.</param>
        /// <param name="watcher">The watcher.</param>
        /// <param name="clientPath">The client path.</param>
        public ChildWatchRegistration(IClientWatchManager watchManager, Watcher watcher, string clientPath)
            : base(watcher, clientPath)
        {
            this.watchManager = watchManager;
        }

        /// <summary>
        /// Gets the watches.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, HashSet&lt;Watcher&gt;&gt;.</returns>
        protected override Dictionary<string, HashSet<Watcher>> GetWatches()
        {
            return watchManager.DataWatches;
        }
    }
}