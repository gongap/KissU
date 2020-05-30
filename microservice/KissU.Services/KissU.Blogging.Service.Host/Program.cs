using System;
using System.Text;
using Autofac;
using KissU.Core.Dependency;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using KissU.Surging.ServiceHosting;
using KissU.Surging.ServiceHosting.Internal.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Service.Host
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
                .Configure(build => { build.AddCacheFile("${cachepath}|cachesettings.json", false, true); })
                .Configure(build => { build.AddCPlatformFile("${servicepath}|servicesettings.json", false, true); })
                .UseServer(options => { })
                .UseConsoleLifetime()
                .UseStartup<Startup>()
                .Build();

            using (host.Run())
            {
                Console.WriteLine($"{AppConfig.ServerOptions.Ip}:{AppConfig.ServerOptions.Port}， {DateTime.Now}。");
            }
        }
    }
}