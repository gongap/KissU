using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace KissU.Core.CPlatform.Configurations.Watch
{
    /// <summary>
    /// 配置监视管理器.
    /// Implements the <see cref="IConfigurationWatchManager" />.
    /// </summary>
    /// <seealso cref="IConfigurationWatchManager" />
    public class ConfigurationWatchManager : IConfigurationWatchManager
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ConfigurationWatchManager> _logger;

        /// <summary>
        /// The timer
        /// </summary>
        private readonly Timer _timer;

        /// <summary>
        /// The data watches
        /// </summary>
        internal HashSet<ConfigurationWatch> dataWatches = new HashSet<ConfigurationWatch>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationWatchManager" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ConfigurationWatchManager(ILogger<ConfigurationWatchManager> logger)
        {
            _logger = logger;
            var timeSpan = TimeSpan.FromSeconds(AppConfig.ServerOptions.WatchInterval);
            _timer = new Timer(
                async s => { await Watching(); }, null, timeSpan, timeSpan);
        }

        /// <summary>
        /// Gets or sets the data watches.
        /// </summary>
        public HashSet<ConfigurationWatch> DataWatches
        {
            get => dataWatches;

            set => dataWatches = value;
        }

        /// <summary>
        /// Registers the watch.
        /// </summary>
        /// <param name="watch">The watch.</param>
        public void Register(ConfigurationWatch watch)
        {
            lock (dataWatches)
            {
                if (!dataWatches.Contains(watch))
                {
                    dataWatches.Add(watch);
                }
            }
        }

        /// <summary>
        /// Watchings this instance.
        /// </summary>
        private async Task Watching()
        {
            foreach (var watch in dataWatches)
            {
                try
                {
                    var task = watch.Process();
                    if (!task.IsCompletedSuccessfully)
                    {
                        await task;
                    }
                    else
                    {
                        task.GetAwaiter().GetResult();
                    }
                }
                catch (Exception ex)
                {
                    if (_logger.IsEnabled(LogLevel.Error))
                    {
                        _logger.LogError($"message:{ex.Message},Source:{ex.Source},Trace:{ex.StackTrace}");
                    }
                }
            }
        }
    }
}