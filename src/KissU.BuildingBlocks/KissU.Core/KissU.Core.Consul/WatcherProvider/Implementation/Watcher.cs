using System.Threading.Tasks;

namespace KissU.Core.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// Watcher.
    /// </summary>
    public abstract class Watcher
    {
        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public abstract Task Process();

        /// <summary>
        /// Event.
        /// </summary>
        public static class Event
        {
            /// <summary>
            /// Enum KeeperState
            /// </summary>
            public enum KeeperState
            {
                /// <summary>
                /// The disconnected
                /// </summary>
                Disconnected = 0,

                /// <summary>
                /// The synchronize connected
                /// </summary>
                SyncConnected = 3
            }
        }
    }
}