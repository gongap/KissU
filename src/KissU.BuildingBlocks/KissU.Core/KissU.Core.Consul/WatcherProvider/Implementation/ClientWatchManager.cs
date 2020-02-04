using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KissU.Core.Consul.Configurations;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Consul.WatcherProvider.Implementation
{
    /// <summary>
    /// ClientWatchManager.
    /// Implements the <see cref="KissU.Core.Consul.WatcherProvider.IClientWatchManager" />
    /// </summary>
    /// <seealso cref="KissU.Core.Consul.WatcherProvider.IClientWatchManager" />
    public class ClientWatchManager : IClientWatchManager
    {
        private readonly ILogger<ClientWatchManager> _logger;
        private readonly Timer _timer;

        /// <summary>
        /// The data watches
        /// </summary>
        internal Dictionary<string, HashSet<Watcher>> dataWatches =
            new Dictionary<string, HashSet<Watcher>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientWatchManager" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="config">The configuration.</param>
        public ClientWatchManager(ILogger<ClientWatchManager> logger, ConfigInfo config)
        {
            var timeSpan = TimeSpan.FromSeconds(config.WatchInterval);
            _logger = logger;
            _timer = new Timer(async s => { await Watching(); }, null, timeSpan, timeSpan);
        }

        /// <summary>
        /// Gets or sets the data watches.
        /// </summary>
        public Dictionary<string, HashSet<Watcher>> DataWatches
        {
            get => dataWatches;
            set => dataWatches = value;
        }

        private HashSet<Watcher> Materialize()
        {
            var result = new HashSet<Watcher>();
            lock (dataWatches)
            {
                foreach (var ws in dataWatches.Values)
                {
                    result.UnionWith(ws);
                }
            }

            return result;
        }

        private async Task Watching()
        {
            try
            {
                var watches = Materialize();
                foreach (var watch in watches)
                {
                    await watch.Process();
                }
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError($"message:{ex.Message},Source:{ex.Source},Trace:{ex.StackTrace}");
            }
        }
    }
}