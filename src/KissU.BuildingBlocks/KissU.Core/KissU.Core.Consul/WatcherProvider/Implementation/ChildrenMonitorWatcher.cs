using System;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using KissU.Core.Consul.Utilitys;

namespace KissU.Core.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// ChildrenMonitorWatcher.
    /// Implements the <see cref="KissU.Core.Consul.WatcherProvider.Implementation.WatcherBase" />
    /// </summary>
    /// <seealso cref="KissU.Core.Consul.WatcherProvider.Implementation.WatcherBase" />
    public class ChildrenMonitorWatcher : WatcherBase
    {
        private readonly Action<string[], string[]> _action;
        private readonly IClientWatchManager _manager; 
        private readonly string _path;
        private readonly Func<string[], string[]> _func;
        private string[] _currentData = new string[0];
        private readonly Func<ValueTask<ConsulClient>> _clientCall;
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrenMonitorWatcher"/> class.
        /// </summary>
        /// <param name="clientCall">The client call.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="path">The path.</param>
        /// <param name="action">The action.</param>
        /// <param name="func">The function.</param>
        public ChildrenMonitorWatcher(Func<ValueTask<ConsulClient>> clientCall, IClientWatchManager manager, string path,
            Action<string[], string[]> action, Func<string[], string[]> func)
        {
            this._action = action;
            _manager = manager;
            _clientCall = clientCall;
            _path = path;
            _func = func;
            RegisterWatch();
        }

        /// <summary>
        /// Sets the current data.
        /// </summary>
        /// <param name="currentData">The current data.</param>
        /// <returns>ChildrenMonitorWatcher.</returns>
        public ChildrenMonitorWatcher SetCurrentData(string[] currentData)
        {
            _currentData = currentData ?? new string[0];
            return this;
        }

        /// <summary>
        /// Processes the implementation.
        /// </summary>
        protected override async Task ProcessImpl()
        {
            RegisterWatch(this);
            var client =await _clientCall();
            var result = await client.GetChildrenAsync(_path);
            if (result != null)
            {
                var convertResult = _func.Invoke(result).Select(key => $"{_path}{key}").ToArray();
                _action(_currentData, convertResult);
                this.SetCurrentData(convertResult);
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