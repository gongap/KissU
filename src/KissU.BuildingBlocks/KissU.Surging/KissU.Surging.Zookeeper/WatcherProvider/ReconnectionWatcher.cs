using System;
using System.Threading.Tasks;
using org.apache.zookeeper;

namespace KissU.Surging.Zookeeper.WatcherProvider
{
    /// <summary>
    /// ReconnectionWatcher.
    /// Implements the <see cref="org.apache.zookeeper.Watcher" />
    /// </summary>
    /// <seealso cref="org.apache.zookeeper.Watcher" />
    internal class ReconnectionWatcher : Watcher
    {
        private readonly Action _connectioned;
        private readonly Action _disconnect;
        private readonly Action _reconnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReconnectionWatcher" /> class.
        /// </summary>
        /// <param name="connectioned">The connectioned.</param>
        /// <param name="disconnect">The disconnect.</param>
        /// <param name="reconnection">The reconnection.</param>
        public ReconnectionWatcher(Action connectioned, Action disconnect, Action reconnection)
        {
            _connectioned = connectioned;
            _disconnect = disconnect;
            _reconnection = reconnection;
        }

        #region Overrides of Watcher

        /// <summary>
        /// Processes the specified event.
        /// </summary>
        /// <param name="watchedEvent">The event.</param>
        public override async Task process(WatchedEvent watchedEvent)
        {
            var state = watchedEvent.getState();
            switch (state)
            {
                case Event.KeeperState.Expired:
                {
                    _reconnection();
                    break;
                }

                case Event.KeeperState.AuthFailed:
                {
                    _disconnect();
                    break;
                }

                case Event.KeeperState.Disconnected:
                {
                    _reconnection();
                    break;
                }

                default:
                {
                    _connectioned();
                    break;
                }
            }

#if NET
                await Task.FromResult(1);
#else
            await Task.CompletedTask;
#endif
        }

        #endregion Overrides of Watcher
    }
}