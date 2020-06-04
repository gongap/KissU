using System;
using System.Text;
using Autofac;
using KissU.Dependency;
using KissU.ServiceHosting;
using KissU.ServiceHosting.Extensions;
using KissU.ServiceHosting.Internal;
using KissU.Surging.Caching;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.Logging;

namespace KissU.Client.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var host = CreateHostBuilder(args).Build();
            using (host.Run())
            {
                var testService = ServiceLocator.GetService<TestService>();
                testService.Test(ServiceLocator.GetService<IServiceProxyFactory>());
                //testService.TestThriftInvoker(ServiceLocator.GetService<IServiceProxyFactory>());
                //testService.TestRabbitMq(ServiceLocator.GetService<IServiceProxyFactory>());
                //testService.TestForRoutePath(ServiceLocator.GetService<IServiceProxyProvider>());
                //testService.StartRequest(300000);
                Console.ReadLine();
            }
        }

        internal static IServiceHostBuilder CreateHostBuilder(string[] args) =>
            new ServiceHostBuilder()
                .ConfigureConfiguration(builder => { builder.AddCacheFile("${cachepath}|cachesettings.json", false, true); })
                .ConfigureConfiguration(builder => { builder.AddCPlatformFile("${servicepath}|servicesettings.json", false, true); })
                .ConfigureLogging(logger => { logger.AddConfiguration(Surging.CPlatform.AppConfig.GetSection("Logging")); })
                .ConfigureContainer(builder =>
                {
                    builder.AddMicroService(option =>
                    {
                        option.AddClient().AddCache();
                    });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .Configure(ServiceLocator.Register)
                .UseClient()
                .UseProxy()
                .UseStartup<Startup>();
    }
}