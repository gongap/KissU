using System;
using System.Collections.Generic;
using System.Linq;
using KissU.Core.CPlatform.Address;

namespace KissU.Core.Consul.Configurations
{
    /// <summary>
    /// ConfigInfo.
    /// </summary>
    public class ConfigInfo
    {
        /// <summary>
        /// 初始化会话超时为20秒的consul配置信息。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        /// <param name="routePath">路由路径配置路径</param>
        /// <param name="subscriberPath">订阅者配置路径</param>
        /// <param name="commandPath">服务命令配置路径</param>
        /// <param name="cachePath">缓存中心配置路径</param>
        /// <param name="mqttRoutePath">The MQTT route path.</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <param name="enableChildrenMonitor">if set to <c>true</c> [enable children monitor].</param>
        public ConfigInfo(string connectionString, string routePath = "services/serviceRoutes/",
            string subscriberPath = "services/serviceSubscribers/",
            string commandPath = "services/serviceCommands/",
            string cachePath = "services/serviceCaches/",
            string mqttRoutePath = "services/mqttServiceRoutes/",
            bool reloadOnChange = false, bool enableChildrenMonitor = false) :
            this(connectionString, TimeSpan.FromSeconds(20), 0, routePath, subscriberPath, commandPath, cachePath,
                mqttRoutePath, reloadOnChange, enableChildrenMonitor)
        {
        }

        /// <summary>
        /// 初始化consul配置信息。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        /// <param name="sessionTimeout">会话超时时间。</param>
        /// <param name="lockDelay">The lock delay.</param>
        /// <param name="routePath">路由路径配置路径</param>
        /// <param name="subscriberPath">订阅者配置命令。</param>
        /// <param name="commandPath">服务命令配置命令。</param>
        /// <param name="cachePath">缓存中心配置路径</param>
        /// <param name="mqttRoutePath">Mqtt路由路径配置路径</param>
        /// <param name="reloadOnChange">if set to <c>true</c> [reload on change].</param>
        /// <param name="enableChildrenMonitor">if set to <c>true</c> [enable children monitor].</param>
        public ConfigInfo(string connectionString, TimeSpan sessionTimeout, int lockDelay,
            string routePath = "services/serviceRoutes/",
            string subscriberPath = "services/serviceSubscribers/",
            string commandPath = "services/serviceCommands/",
            string cachePath = "services/serviceCaches/",
            string mqttRoutePath = "services/mqttServiceRoutes/",
            bool reloadOnChange = false, bool enableChildrenMonitor = false)
        {
            CachePath = cachePath;
            ReloadOnChange = reloadOnChange;
            SessionTimeout = sessionTimeout;
            RoutePath = routePath;
            LockDelay = lockDelay;
            SubscriberPath = subscriberPath;
            CommandPath = commandPath;
            MqttRoutePath = mqttRoutePath;
            EnableChildrenMonitor = enableChildrenMonitor;
            if (!string.IsNullOrEmpty(connectionString))
            {
                var addresses = connectionString.Split(",");
                if (addresses.Length > 1)
                {
                    Addresses = addresses.Select(p => ConvertAddressModel(p));
                }
                else
                {
                    var address = ConvertAddressModel(connectionString);
                    if (address != null)
                    {
                        var ipAddress = address as IpAddressModel;
                        Host = ipAddress.Ip;
                        Port = ipAddress.Port;
                    }

                    Addresses = new[]
                    {
                        new IpAddressModel(Host, Port)
                    };
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigInfo" /> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        public ConfigInfo(string host, int port) : this(host, port, TimeSpan.FromSeconds(20))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigInfo" /> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="sessionTimeout">The session timeout.</param>
        public ConfigInfo(string host, int port, TimeSpan sessionTimeout)
        {
            SessionTimeout = sessionTimeout;
            Host = host;
            Port = port;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [reload on change].
        /// </summary>
        public bool ReloadOnChange { get; set; }

        /// <summary>
        /// watch 时间间隔
        /// </summary>
        public int WatchInterval { get; set; } = 60;

        /// <summary>
        /// Gets or sets the lock delay.
        /// </summary>
        public int LockDelay { get; set; } = 600;

        /// <summary>
        /// Gets or sets a value indicating whether [enable children monitor].
        /// </summary>
        public bool EnableChildrenMonitor { get; set; }

        /// <summary>
        /// 命令配置路径
        /// </summary>
        public string CommandPath { get; set; }

        /// <summary>
        /// 订阅者配置路径
        /// </summary>
        public string SubscriberPath { get; set; }

        /// <summary>
        /// 路由配置路径。
        /// </summary>
        public string RoutePath { get; set; }


        /// <summary>
        /// Mqtt路由配置路径。
        /// </summary>
        public string MqttRoutePath { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        public IEnumerable<AddressModel> Addresses { get; set; }

        /// <summary>
        /// 缓存中心配置中心
        /// </summary>
        public string CachePath { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 会话超时时间。
        /// </summary>
        public TimeSpan SessionTimeout { get; set; }

        /// <summary>
        /// Converts the address model.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns>AddressModel.</returns>
        public AddressModel ConvertAddressModel(string connection)
        {
            var address = connection.Split(":");
            if (address.Length > 1)
            {
                int port;
                int.TryParse(address[1], out port);
                return new IpAddressModel(address[0], port);
            }

            return null;
        }
    }
}