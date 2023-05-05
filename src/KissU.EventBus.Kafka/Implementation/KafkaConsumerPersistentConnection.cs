using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Logging;

namespace KissU.EventBus.Kafka.Implementation
{
    /// <summary>
    /// KafkaConsumerPersistentConnection.
    /// Implements the <see cref="KafkaPersistentConnectionBase" />
    /// </summary>
    /// <seealso cref="KafkaPersistentConnectionBase" />
    public class KafkaConsumerPersistentConnection : KafkaPersistentConnectionBase
    {
        private readonly ILogger<KafkaConsumerPersistentConnection> _logger;
        private readonly IDeserializer<string> _stringDeserializer;
        private Consumer<Null, string> _consumerClient;
        private readonly ConcurrentBag<Consumer<Null, string>> _consumerClients;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="KafkaConsumerPersistentConnection" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public KafkaConsumerPersistentConnection(ILogger<KafkaConsumerPersistentConnection> logger)
            : base(logger, AppConfig.KafkaConsumerConfig)
        {
            _logger = logger;
            _stringDeserializer = new StringDeserializer(Encoding.UTF8);
            _consumerClients = new ConcurrentBag<Consumer<Null, string>>();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        public override bool IsConnected => _consumerClient != null && !_disposed;

        /// <summary>
        /// Connections the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Action.</returns>
        public override Action Connection(IEnumerable<KeyValuePair<string, object>> options)
        {
            return () =>
            {
                _consumerClient = new Consumer<Null, string>(options, null, _stringDeserializer);
                _consumerClient.OnConsumeError += OnConsumeError;
                _consumerClient.OnError += OnConnectionException;
                _consumerClients.Add(_consumerClient);
            };
        }

        /// <summary>
        /// Listenings the specified timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        public void Listening(TimeSpan timeout)
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            while (true)
            {
                foreach (var client in _consumerClients)
                {
                    client.Poll(timeout);

                    if (!client.Consume(out var msg, (int) timeout.TotalMilliseconds))
                    {
                        continue;
                    }

                    if (msg.Offset % 5 == 0)
                    {
                        var committedOffsets = client.CommitAsync(msg).Result;
                    }
                }
            }
        }

        /// <summary>
        /// Creates the connect.
        /// </summary>
        /// <returns>System.Object.</returns>
        public override object CreateConnect()
        {
            TryConnect();
            return _consumerClient;
        }

        private void OnConsumeError(object sender, Message e)
        {
            var message = e.Deserialize<Null, string>(null, _stringDeserializer);
            if (_disposed) return;

            _logger.LogWarning($"An error occurred during consume the message; Topic:'{e.Topic}'," +
                               $"Message:'{message.Value}', Reason:'{e.Error}'.");

            TryConnect();
        }

        private void OnConnectionException(object sender, Error error)
        {
            if (_disposed) return;

            _logger.LogWarning($"A Kafka connection throw exception.info:{error} ,Trying to re-connect...");

            TryConnect();
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
                _consumerClient.Dispose();
            }
            catch (IOException ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }
    }
}