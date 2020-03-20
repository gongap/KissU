﻿using System.Threading.Tasks;

namespace KissU.Surging.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// WatcherBase.
    /// Implements the <see cref="KissU.Surging.Consul.WatcherProvider.Implementation.Watcher" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Consul.WatcherProvider.Implementation.Watcher" />
    public abstract class WatcherBase : Watcher
    {
        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public override async Task Process()
        {
            await ProcessImpl();
        }

        /// <summary>
        /// Processes the implementation.
        /// </summary>
        /// <returns>Task.</returns>
        protected abstract Task ProcessImpl();
    }
}