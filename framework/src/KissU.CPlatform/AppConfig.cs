using System;
using KissU.Address;
using KissU.CPlatform.Configurations;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Helpers;
using Microsoft.Extensions.Configuration;

namespace KissU.CPlatform
{
    /// <summary>
    /// 应用配置.
    /// </summary>
    public class AppConfig
    {
        private static AddressModel _host;

        /// <summary>
        /// 负载均衡模式
        /// </summary>
        private static AddressSelectorMode _loadBalanceMode = AddressSelectorMode.Polling;

        /// <summary>
        /// 服务器选项
        /// </summary>
        private static ServerEngineOptions _serverOptions = new ServerEngineOptions();

        /// <summary>
        /// 配置
        /// </summary>
        public static IConfigurationRoot Configuration { get; internal set; }

        /// <summary>
        /// 负载均衡模式
        /// </summary>
        public static AddressSelectorMode LoadBalanceMode
        {
            get
            {
                var mode = _loadBalanceMode;
                if (Configuration?["AccessTokenExpireTimeSpan"] != null &&
                    !Enum.TryParse(Configuration["AccessTokenExpireTimeSpan"], out mode))
                {
                    mode = _loadBalanceMode;
                }

                return mode;
            }
            internal set => _loadBalanceMode = value;
        }

        /// <summary>
        /// 服务器选项.
        /// </summary>
        public static ServerEngineOptions ServerOptions
        {
            get => _serverOptions;
            internal set => _serverOptions = value;
        }

        /// <summary>
        /// 获取配置节点.
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>配置节点.</returns>
        public static IConfigurationSection GetSection(string name)
        {
            return Configuration?.GetSection(name);
        }

        /// <summary>
        /// Gets the host address.
        /// </summary>
        /// <returns>AddressModel.</returns>
        public static AddressModel GetHostAddress()
        {
            if (_host != null)
            {
                return _host;
            }

            var ports = ServerOptions.Ports;
            var address = NetUtils.GetHostAddress(ServerOptions.Ip);
            var port = ServerOptions.Port;
            var mappingIp = ServerOptions.MappingIP ?? address;
            var mappingPort = ServerOptions.MappingPort;
            if (mappingPort == 0)
            {
                mappingPort = port;
            }

            _host = new IpAddressModel
            {
                HttpPort = ports.HttpPort,
                Ip = mappingIp,
                Port = mappingPort,
                MqttPort = ports.MQTTPort,
                WanIp = ServerOptions.WanIp,
                WsPort = ports.WSPort
            };
            return _host;
        }
    }
}