using System;
using System.Threading.Tasks;
using Consul;
using KissU.Core.Consul.Utilitys;

namespace KissU.Core.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// NodeMonitorWatcher.
    /// Implements the <see cref="KissU.Core.Consul.WatcherProvider.Implementation.WatcherBase" />
    /// </summary>
    /// <seealso cref="KissU.Core.Consul.WatcherProvider.Implementation.WatcherBase" />
    class NodeMonitorWatcher : WatcherBase
    {
        private readonly Action<byte[], byte[]> _action;
        private readonly IClientWatchManager _manager;
        private readonly Func<ValueTask<ConsulClient>> _clientCall;
        private readonly string _path;
        private byte[] _currentData = new byte[0];
        Func<string,bool> _allowChange;
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeMonitorWatcher"/> class.
        /// </summary>
        /// <param name="clientCall">The client call.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="path">The path.</param>
        /// <param name="action">The action.</param>
        /// <param name="allowChange">The allow change.</param>
        public NodeMonitorWatcher(Func<ValueTask<ConsulClient>> clientCall, IClientWatchManager manager, string path,
            Action<byte[], byte[]> action,Func<string,bool> allowChange)
        {
            this._action = action;
            _manager = manager;
            _clientCall = clientCall;
            _path = path;
            _allowChange = allowChange;
            RegisterWatch();
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

        /// <summary>
        /// Processes the implementation.
        /// </summary>
        protected override async Task ProcessImpl()
        {
            RegisterWatch(this);
            if (_allowChange!=null&&! _allowChange(_path)) return;
            var client = await _clientCall();
            var result =await client.GetDataAsync(_path);
            if (result != null)
            {
                _action(_currentData, result);
                this.SetCurrentData(result);
            }
        }

        private void RegisterWatch(Watcher watcher = null)
        {
            ChildWatchRegistration wcb = null;
            if (watcher != null)
            {
                wcb = new ChildWatchRegistration(_manager, watcher, _path);
            }
            else
            {
                wcb = new ChildWatchRegistration(_manager, this, _path);
            }
            wcb.Register();
        }
    }
}