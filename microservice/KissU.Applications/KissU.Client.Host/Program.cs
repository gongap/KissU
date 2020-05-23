using System;
using System.Text;
using Autofac;
using KissU.Core.Dependency;
using KissU.Surging.Caching;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using KissU.Surging.ServiceHosting;
using KissU.Surging.ServiceHosting.Internal.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Client.Host
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var host = new ServiceHostBuilder()
                .RegisterServices(builder =>
                {
                    builder.AddMicroService(option =>
                    {
                        option.AddClient()
                            .AddCache();
                        builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                    });
                })
                .ConfigureLogging(logger =>
                {
                    logger.AddConfiguration(
                        KissU.Surging.CPlatform.AppConfig.GetSection("Logging"));
                })
                .Configure(build => build.AddCacheFile("cacheSettings.json", false, true))
                .Configure(build => build.AddCPlatformFile("servicesettings.json", false, true))
                .UseClient()
                .UseProxy()
                .UseStartup<Startup>()
                .Build();

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
    }
}