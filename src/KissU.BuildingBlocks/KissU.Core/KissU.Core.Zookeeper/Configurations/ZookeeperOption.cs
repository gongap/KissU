namespace KissU.Core.Zookeeper.Configurations
{
    /// <summary>
    /// ZookeeperOption.
    /// </summary>
    public class ZookeeperOption
    {
        /// <summary>
        /// Gets or sets the session timeout.
        /// </summary>
        public string SessionTimeout { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the route path.
        /// </summary>
        public string RoutePath { get; set; }

        /// <summary>
        /// Gets or sets the subscriber path.
        /// </summary>
        public string SubscriberPath { get; set; }

        /// <summary>
        /// Gets or sets the command path.
        /// </summary>
        public string CommandPath { get; set; }

        /// <summary>
        /// Gets or sets the ch root.
        /// </summary>
        public string ChRoot { get; set; }

        /// <summary>
        /// Gets or sets the cache path.
        /// </summary>
        public string CachePath { get; set; }

        /// <summary>
        /// Gets or sets the MQTT route path.
        /// </summary>
        public string MqttRoutePath { get; set; }

        /// <summary>
        /// Gets or sets the reload on change.
        /// </summary>
        public string ReloadOnChange { get; set; }

        /// <summary>
        /// Gets or sets the enable children monitor.
        /// </summary>
        public string EnableChildrenMonitor { get; set; }
    }
}