using System;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Microsoft.Extensions.Configuration;

namespace KissU.Surging.CPlatform
{
    /// <summary>
    /// 应用配置.
    /// </summary>
    public class AppConfig
    {
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
    }
}