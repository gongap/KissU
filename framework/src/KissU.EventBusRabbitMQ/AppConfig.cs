using Microsoft.Extensions.Configuration;

namespace KissU.EventBusRabbitMQ
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public static IConfigurationRoot Configuration { get; set; }


        /// <summary>
        /// Gets the name of the broker.
        /// </summary>
        public static string BrokerName { get; internal set; }

        /// <summary>
        /// Gets or sets the prefetch count.
        /// </summary>
        public static ushort PrefetchCount { get; set; }

        /// <summary>
        /// Gets the retry count.
        /// </summary>
        public static int RetryCount { get; internal set; } = 3;

        /// <summary>
        /// Gets the fail count.
        /// </summary>
        public static int FailCount { get; internal set; } = 3;

        /// <summary>
        /// Gets the message TTL.
        /// </summary>
        public static int MessageTTL { get; internal set; } = 30 * 1000;
    }
}