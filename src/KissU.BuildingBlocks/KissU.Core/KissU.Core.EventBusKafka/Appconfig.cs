using System.Collections.Generic;
using KissU.Core.EventBusKafka.Configurations;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.EventBusKafka
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
        public static KafkaOptions  Options { get; internal set; }

        private static IEnumerable<KeyValuePair<string, object>> _kafkaConsumerConfig;


        private static IEnumerable<KeyValuePair<string, object>> _kafkaProducerConfig;

        /// <summary>
        /// Gets the kafka consumer configuration.
        /// </summary>
        public static IEnumerable<KeyValuePair<string, object>> KafkaConsumerConfig
        {
            get
            {
                return _kafkaConsumerConfig;
            }
            internal set
            {
                _kafkaConsumerConfig = value;
            }
        }

        /// <summary>
        /// Gets the kafka producer configuration.
        /// </summary>
        public static IEnumerable<KeyValuePair<string, object>> KafkaProducerConfig
        {
            get
            {
                return _kafkaProducerConfig;
            }
            internal set
            {
                _kafkaProducerConfig = value;
            }
        }
    }
}
