using System;
using KissU.Core.CPlatform.Configurations;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.CPlatform
{
   public class AppConfig
    {
        #region 字段
        private static AddressSelectorMode _loadBalanceMode=AddressSelectorMode.Polling;
        private static KissUServerOptions _serverOptions=new KissUServerOptions();
        #endregion

        public static IConfigurationRoot Configuration { get; internal set; }

        /// <summary>
        /// 负载均衡模式
        /// </summary>
        public static AddressSelectorMode LoadBalanceMode
        {
            get
            {
                AddressSelectorMode mode = _loadBalanceMode; ;
                if(Configuration !=null 
                    && Configuration["AccessTokenExpireTimeSpan"]!=null
                    && !Enum.TryParse(Configuration["AccessTokenExpireTimeSpan"], out mode))
                {
                    mode = _loadBalanceMode;
                }
                return mode;
            }
            internal set
            {
                _loadBalanceMode = value;
            }
        }

        public static IConfigurationSection GetSection(string name)
        {
            return Configuration?.GetSection(name);
        }

        public static KissUServerOptions ServerOptions
        {
            get
            {
                return _serverOptions;
            }
            internal set
            {
                _serverOptions = value;
            }
        }
    }
}
