using System;
using System.Text;
using Autofac;
using KissU.Dependency;
using KissU.ServiceHosting;
using KissU.ServiceHosting.Extensions;
using KissU.ServiceHosting.Internal;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.Logging;

namespace KissU.AuthServer.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var host = CreateHostBuilder(args).Build();
            using (host.Run())
            {
                Console.WriteLine($@"{AppConfig.ServerOptions.Ip}:{AppConfig.ServerOptions.Port}， {DateTime.Now}。");
            }
        }

        internal static IServiceHostBuilder CreateHostBuilder(string[] args) =>
            new ServiceHostBuilder()
                .ConfigureConfiguration(builder => { builder.AddCacheFile("${cachepath}|cachesettings.json", false, true); })
                .ConfigureConfiguration(builder => { builder.AddCPlatformFile("${servicepath}|servicesettings.json", false, true); })
                .ConfigureLogging(logger => { logger.AddConfiguration(AppConfig.GetSection("Logging")); })
                .ConfigureContainer(builder =>
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
                .Configure(ServiceLocator.Register)
                .UseServer(options => { })
                .UseConsoleLifetime()
                .UseStartup<Startup>();
    }
}