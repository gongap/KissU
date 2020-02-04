using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace KissU.Core.EventBusKafka.Implementation
{
    /// <summary>
    /// KafkaPersistentConnectionBase.
    /// Implements the <see cref="KissU.Core.EventBusKafka.IKafkaPersisterConnection" />
    /// </summary>
    /// <seealso cref="KissU.Core.EventBusKafka.IKafkaPersisterConnection" />
    public abstract class KafkaPersistentConnectionBase : IKafkaPersisterConnection
    {
        private readonly ILogger<KafkaPersistentConnectionBase> _logger;
        private readonly IEnumerable<KeyValuePair<string, object>> _config;
        object sync_root = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="KafkaPersistentConnectionBase" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="config">The configuration.</param>
        public KafkaPersistentConnectionBase(ILogger<KafkaPersistentConnectionBase> logger,
            IEnumerable<KeyValuePair<string, object>> config)
        {
            this._logger = logger;
            _config = config;
        }


        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        public abstract bool IsConnected { get; }

        /// <summary>
        /// Tries the connect.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryConnect()
        {
            _logger.LogInformation("Kafka Client is trying to connect");

            lock (sync_root)
            {
                var policy = RetryPolicy.Handle<KafkaException>()
                    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                        _logger.LogWarning(ex.ToString());
                    }
                );

                policy.Execute(() =>
                {
                    Connection(_config).Invoke();
                });

                if (IsConnected)
                {
                    return true;
                }
                else
                {
                    _logger.LogCritical("FATAL ERROR: Kafka connections could not be created and opened");
                    return false;
                }
            }
        }

        /// <summary>
        /// Connections the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Action.</returns>
        public abstract Action Connection(IEnumerable<KeyValuePair<string, object>> options);

        /// <summary>
        /// Creates the connect.
        /// </summary>
        /// <returns>System.Object.</returns>
        public abstract object CreateConnect();
        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public abstract void Dispose();
    }
}
