using System.Collections.Generic;
using KissU.Core.EventBusKafka.Configurations;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.EventBusKafka
{
    public  class AppConfig
    {

        public static IConfigurationRoot Configuration { get; set; }

        public static KafkaOptions  Options { get; internal set; }

        private static IEnumerable<KeyValuePair<string, object>> _kafkaConsumerConfig;


        private static IEnumerable<KeyValuePair<string, object>> _kafkaProducerConfig;

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
