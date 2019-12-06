using System;
using System.Text;
using Autofac;
using Microsoft.Extensions.Logging;
using Surging.Core.Caching.Configurations;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.ProxyGenerator;
using Surging.Core.ServiceHosting;
using Surging.Core.ServiceHosting.Internal.Implementation;

//using Surging.Core.EventBusKafka;
//using Surging.Core.Zookeeper;
//using Surging.Core.Zookeeper.Configurations;

namespace KissU.Hosts.Default
{
    /// <summary>
    ///  应用程序
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        private static void Main(string[] args)
        {
            //注册编码提供程序
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //构建服务主机
            var host = new ServiceHostBuilder()
                //注册服务
                .RegisterServices(builder =>
                {
                    //配置微服务
                    builder.AddMicroService(option =>
                    {
                        //添加服务运行时服务
                        option.AddServiceRuntime()
                            //添加关联服务
                            .AddRelateService()
                            //添加配置观察
                            .AddConfigurationWatch()
                            //添加ZooKeeper服务命令管理者
                            //option.UseZooKeeperManager(new ConfigInfo("127.0.0.1:2181")); 
                            //添加服务引擎
                            .AddServiceEngine(typeof(SurgingServiceEngine));
                        //注册平台容器
                        builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                    });
                })
                //配置日志
                .ConfigureLogging(logger => { logger.AddConfiguration(AppConfig.GetSection("Logging")); })
                //启用服务端
                .UseServer(options => { })
                //启用控制台生命周期
                .UseConsoleLifetime()
                //设置缓存配置文件
                .Configure(build => build.AddCacheFile("${cachepath}|cacheSettings.json", AppContext.BaseDirectory, false, true))
                //设置引擎配置文件
                .Configure(build => build.AddCPlatformFile("${surgingpath}|surgingSettings.json", false, true))
                //使用Startup启动
                .UseStartup<Startup>()
                //构建主机
                .Build();

            using (host.Run())
            {
                Console.WriteLine($"服务端启动成功，{DateTime.Now}。");
            }
        }
    }
}
