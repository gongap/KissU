using Autofac;
using KissU.Core.Caching.Configurations;
using KissU.Core.CPlatform.Configurations;
using KissU.Core.CPlatform.Utilities;
using KissU.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Services.Host
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// 初始化启动配置
        /// </summary>
        public Startup(IConfigurationBuilder build)
        {
            //build.AddConsulFile("${consulpath}|consul.json", false, true);
            //build.AddZookeeperFile("${zookeeperpath}|zookeeper.json", false, true); 
            //build.AddEventBusFile("{eventbuspath}|eventbussettings.json", false, true);
            build.AddCacheFile("${cachepath}|cachesettings.json", false, true);
            build.AddCPlatformFile("${servicepath}|servicesettings.json", false, true);
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public IContainer ConfigureServices(ContainerBuilder builder)
        {
            var serivces = new ServiceCollection();
            ServiceLocator.Current = builder.AddUtil(serivces);
            return ServiceLocator.Current;
        }

        /// <summary>
        /// 配置应用
        /// </summary>
        public void Configure(IContainer app)
        {
        }
    }
}