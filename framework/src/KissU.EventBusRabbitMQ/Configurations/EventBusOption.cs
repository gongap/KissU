namespace KissU.EventBusRabbitMQ.Configurations
{
    /// <summary>
    /// EventBusOption.
    /// </summary>
    public class EventBusOption
    {
        /// <summary>
        /// Gets or sets the event bus connection.
        /// </summary>
        public string EventBusConnection { get; set; } = "";

        /// <summary>
        /// Gets or sets the name of the event bus user.
        /// </summary>
        public string EventBusUserName { get; set; } = "guest";

        /// <summary>
        /// Gets or sets the event bus password.
        /// </summary>
        public string EventBusPassword { get; set; } = "guest";

        /// <summary>
        /// Gets or sets the virtual host.
        /// </summary>
        public string VirtualHost { get; set; } = "/";

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public string Port { get; set; } = "5672";

        /// <summary>
        /// Gets or sets the name of the broker.
        /// </summary>
        public string BrokerName { get; set; } = "kissu";

        /// <summary>
        /// Gets or sets the retry count.
        /// </summary>
        public int RetryCount { get; set; } = 3;

        /// <summary>
        /// Gets or sets the fail count.
        /// </summary>
        public int FailCount { get; set; } = 3;

        /// <summary>
        /// Gets or sets the prefetch count.
        /// </summary>
        public ushort PrefetchCount { get; set; }

        /// <summary>
        /// Gets or sets the message TTL.
        /// </summary>
        public int MessageTTL { get; set; } = 30 * 1000;
    }
}