using System.Collections.Generic;
using KissU.Surging.EventBusKafka.Configurations;
using Microsoft.Extensions.Configuration;

namespace KissU.Surging.EventBusKafka
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Gets the options.
        /// </summary>
        public static KafkaOptions Options { get; internal set; }

        /// <summary>
        /// Gets the kafka consumer configuration.
        /// </summary>
        public static IEnumerable<KeyValuePair<string, object>> KafkaConsumerConfig { get; internal set; }

        /// <summary>
        /// Gets the kafka producer configuration.
        /// </summary>
        public static IEnumerable<KeyValuePair<string, object>> KafkaProducerConfig { get; internal set; }
    }
}