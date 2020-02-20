using System;
using System.Text;
using Autofac;
using KissU.Core.Caching.Configurations;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Configurations;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.ProxyGenerator;
using KissU.Core.ServiceHosting;
using KissU.Core.ServiceHosting.Internal.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Services.SampleB.Host
{
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var host = new ServiceHostBuilder()
                .RegisterServices(builder =>
                {
                    builder.AddMicroService(option =>
                    {
                        option.AddServiceRuntime()
                        .AddRelateService()
                        .AddConfigurationWatch()
                        .AddServiceEngine(typeof(ServiceEngine));
                    });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .ConfigureLogging(logger => { logger.AddConfiguration(AppConfig.GetSection("Logging")); })
                .UseServer(options => { })
                .UseConsoleLifetime()
                .Configure(build => build.AddCacheFile("${cachepath}|cachesettings.json", AppContext.BaseDirectory, false, true))
                .Configure(build => build.AddCPlatformFile("${kissupath}|servicesettings.json", false, true))
                .UseStartup<Startup>()
                .Build();

            using (host.Run())
            {
                Console.WriteLine($"服务端启动成功，{DateTime.Now}。");
            }
        }
    }
}