using System;
using System.Threading;
using System.Threading.Tasks;
using org.apache.zookeeper;

namespace KissU.Surging.Zookeeper.WatcherProvider
{
    /// <summary>
    /// NodeMonitorWatcher.
    /// Implements the <see cref="KissU.Surging.Zookeeper.WatcherProvider.WatcherBase" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Zookeeper.WatcherProvider.WatcherBase" />
    internal class NodeMonitorWatcher : WatcherBase
    {
        private readonly Action<byte[], byte[]> _action;
        private readonly Func<ValueTask<(ManualResetEvent, ZooKeeper)>> _zooKeeperCall;
        private byte[] _currentData;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeMonitorWatcher" /> class.
        /// </summary>
        /// <param name="zooKeeperCall">The zoo keeper call.</param>
        /// <param name="path">The path.</param>
        /// <param name="action">The action.</param>
        public NodeMonitorWatcher(Func<ValueTask<(ManualResetEvent, ZooKeeper)>> zooKeeperCall, string path,
            Action<byte[], byte[]> action) : base(path)
        {
            _zooKeeperCall = zooKeeperCall;
            _action = action;
        }

        /// <summary>
        /// Sets the current data.
        /// </summary>
        /// <param name="currentData">The current data.</param>
        /// <returns>NodeMonitorWatcher.</returns>
        public NodeMonitorWatcher SetCurrentData(byte[] currentData)
        {
            _currentData = currentData;

            return this;
        }

        #region Overrides of WatcherBase

        /// <summary>
        /// Processes the implementation.
        /// </summary>
        /// <param name="watchedEvent">The watched event.</param>
        protected override async Task ProcessImpl(WatchedEvent watchedEvent)
        {
            var path = Path;
            switch (watchedEvent.get_Type())
            {
                case Event.EventType.NodeDataChanged:
                    var zooKeeper = await _zooKeeperCall();
                    var watcher = new NodeMonitorWatcher(_zooKeeperCall, path, _action);
                    var data = await zooKeeper.Item2.getDataAsync(path, watcher);
                    var newData = data.Data;
                    _action(_currentData, newData);
                    watcher.SetCurrentData(newData);
                    break;
            }
        }

        #endregion Overrides of WatcherBase
    }
}