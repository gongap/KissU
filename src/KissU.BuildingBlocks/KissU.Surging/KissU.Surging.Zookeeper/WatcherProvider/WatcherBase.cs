using System.Threading.Tasks;
using org.apache.zookeeper;

namespace KissU.Surging.Zookeeper.WatcherProvider
{
    /// <summary>
    /// WatcherBase.
    /// Implements the <see cref="org.apache.zookeeper.Watcher" />
    /// </summary>
    /// <seealso cref="org.apache.zookeeper.Watcher" />
    public abstract class WatcherBase : Watcher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WatcherBase" /> class.
        /// </summary>
        /// <param name="path">The path.</param>
        protected WatcherBase(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        protected string Path { get; }

        /// <summary>
        /// Processes the specified watched event.
        /// </summary>
        /// <param name="watchedEvent">The watched event.</param>
        public override async Task process(WatchedEvent watchedEvent)
        {
            if (watchedEvent.getState() != Event.KeeperState.SyncConnected || watchedEvent.getPath() != Path)
                return;
            await ProcessImpl(watchedEvent);
        }

        /// <summary>
        /// Processes the implementation.
        /// </summary>
        /// <param name="watchedEvent">The watched event.</param>
        /// <returns>Task.</returns>
        protected abstract Task ProcessImpl(WatchedEvent watchedEvent);
    }
}