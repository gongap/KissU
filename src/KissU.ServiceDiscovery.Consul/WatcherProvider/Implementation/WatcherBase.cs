using System.Threading.Tasks;

namespace KissU.ServiceDiscovery.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// WatcherBase.
    /// Implements the <see cref="Watcher" />
    /// </summary>
    /// <seealso cref="Watcher" />
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