﻿namespace KissU.ServiceDiscovery.Consul.Configurations
{
    /// <summary>
    /// ConsulOption.
    /// </summary>
    public class ConsulOption
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

        /// <summary>
        /// Gets or sets the watch interval.
        /// </summary>
        public int? WatchInterval { get; set; } 

        /// <summary>
        /// Gets or sets the lock delay.
        /// </summary>
        public int? LockDelay { get; set; }
    }
}