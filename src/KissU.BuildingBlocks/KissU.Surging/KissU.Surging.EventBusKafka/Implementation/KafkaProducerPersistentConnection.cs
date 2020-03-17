using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.EventBusKafka.Implementation
{
    /// <summary>
    /// KafkaProducerPersistentConnection.
    /// Implements the <see cref="KissU.Surging.EventBusKafka.Implementation.KafkaPersistentConnectionBase" />
    /// </summary>
    /// <seealso cref="KissU.Surging.EventBusKafka.Implementation.KafkaPersistentConnectionBase" />
    public class KafkaProducerPersistentConnection : KafkaPersistentConnectionBase
    {
        private readonly ILogger<KafkaProducerPersistentConnection> _logger;
        private readonly ISerializer<string> _stringSerializer;
        private Producer<Null, string> _connection;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="KafkaProducerPersistentConnection" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public KafkaProducerPersistentConnection(ILogger<KafkaProducerPersistentConnection> logger)
            : base(logger, AppConfig.KafkaProducerConfig)
        {
            _logger = logger;
            _stringSerializer = new StringSerializer(Encoding.UTF8);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        public override bool IsConnected => _connection != null && !_disposed;


        /// <summary>
        /// Connections the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Action.</returns>
        public override Action Connection(IEnumerable<KeyValuePair<string, object>> options)
        {
            return () =>
            {
                _connection = new Producer<Null, string>(options, null, _stringSerializer);
                _connection.OnError += OnConnectionException;
            };
        }

        /// <summary>
        /// Creates the connect.
        /// </summary>
        /// <returns>System.Object.</returns>
        public override object CreateConnect()
        {
            TryConnect();
            return _connection;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            try
            {
                _connection.Dispose();
            }
            catch (IOException ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }

        private void OnConnectionException(object sender, Error error)
        {
            if (_disposed) return;

            _logger.LogWarning($"A Kafka connection throw exception.info:{error} ,Trying to re-connect...");

            TryConnect();
        }
    }
}