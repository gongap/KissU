using System.Collections.Generic;

namespace KissU.EventBusKafka.Configurations
{
    /// <summary>
    /// KafkaOptions.
    /// </summary>
    public class KafkaOptions
    {
        /// <summary>
        /// Gets or sets the servers.
        /// </summary>
        public string Servers { get; set; } = "localhost:9092";

        /// <summary>
        /// Gets or sets the maximum queue buffering.
        /// </summary>
        public int MaxQueueBuffering { get; set; } = 10;

        /// <summary>
        /// Gets or sets the maximum socket blocking.
        /// </summary>
        public int MaxSocketBlocking { get; set; } = 10;

        /// <summary>
        /// Gets or sets a value indicating whether [enable automatic commit].
        /// </summary>
        public bool EnableAutoCommit { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether [log connection close].
        /// </summary>
        public bool LogConnectionClose { get; set; } = false;

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        public int Timeout { get; set; } = 100;

        /// <summary>
        /// Gets or sets the commit interval.
        /// </summary>
        public int CommitInterval { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the offset reset.
        /// </summary>
        public OffsetResetMode OffsetReset { get; set; } = OffsetResetMode.Earliest;

        /// <summary>
        /// Gets or sets the session timeout.
        /// </summary>
        public int SessionTimeout { get; set; } = 36000;

        /// <summary>
        /// Gets or sets the acks.
        /// </summary>
        public string Acks { get; set; } = "all";

        /// <summary>
        /// Gets or sets the retries.
        /// </summary>
        public int Retries { get; set; }

        /// <summary>
        /// Gets or sets the linger.
        /// </summary>
        public int Linger { get; set; } = 1;

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        public string GroupID { get; set; } = "suringdemo";

        /// <summary>
        /// Gets the value.
        /// </summary>
        public KafkaOptions Value => this;

        /// <summary>
        /// Gets the consumer configuration.
        /// </summary>
        /// <returns>IEnumerable&lt;KeyValuePair&lt;System.String, System.Object&gt;&gt;.</returns>
        public IEnumerable<KeyValuePair<string, object>> GetConsumerConfig()
        {
            var configs = new List<KeyValuePair<string, object>>();
            configs.Add(new KeyValuePair<string, object>("bootstrap.servers", Servers));
            configs.Add(new KeyValuePair<string, object>("queue.buffering.max.ms", MaxQueueBuffering.ToString()));
            configs.Add(new KeyValuePair<string, object>("socket.blocking.max.ms", MaxSocketBlocking.ToString()));
            configs.Add(new KeyValuePair<string, object>("enable.auto.commit", EnableAutoCommit.ToString()));
            configs.Add(new KeyValuePair<string, object>("log.connection.close", LogConnectionClose.ToString()));
            configs.Add(new KeyValuePair<string, object>("auto.commit.interval.ms", CommitInterval));
            configs.Add(new KeyValuePair<string, object>("auto.offset.reset", OffsetReset.ToString().ToLower()));
            configs.Add(new KeyValuePair<string, object>("session.timeout.ms", SessionTimeout));
            configs.Add(new KeyValuePair<string, object>("group.id", GroupID));
            return configs;
        }

        /// <summary>
        /// Gets the producer configuration.
        /// </summary>
        /// <returns>IEnumerable&lt;KeyValuePair&lt;System.String, System.Object&gt;&gt;.</returns>
        public IEnumerable<KeyValuePair<string, object>> GetProducerConfig()
        {
            var configs = new List<KeyValuePair<string, object>>();
            configs.Add(new KeyValuePair<string, object>("bootstrap.servers", Servers));
            configs.Add(new KeyValuePair<string, object>("acks", Acks));
            configs.Add(new KeyValuePair<string, object>("retries", Retries));
            configs.Add(new KeyValuePair<string, object>("linger.ms", Linger));
            return configs;
        }
    }
}