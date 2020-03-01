using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.Caching;
using KissU.Core.Caching.Configurations;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Configurations;
using KissU.Core.CPlatform.DependencyResolution;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.EventBusRabbitMQ.Configurations;
using KissU.Core.ProxyGenerator;
using KissU.Core.ServiceHosting;
using KissU.Core.ServiceHosting.Internal.Implementation;
using KissU.Modules.SampleA.Service.Contracts;
using Microsoft.Extensions.Logging;
using AppConfig = KissU.Core.CPlatform.AppConfig;

namespace KissU.Core.Services.Client
{
    public class Program
    {
        private static int _endedConnenctionCount;
        private static DateTime begintime;

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
                        AppConfig.GetSection("Logging"));
                })
                .Configure(build =>
                    build.AddEventBusFile("eventBusSettings.json", false))
                .Configure(build =>
                    build.AddCacheFile("cacheSettings.json", false, true))
                .Configure(build =>
                    build.AddCPlatformFile("${KissUpath}|servicesettings.json", false, true))
                .UseClient()
                .UseProxy()
                .UseStartup<Startup>()
                .Build();

            using (host.Run())
            {
                Startup.Test(ServiceLocator.GetService<IServiceProxyFactory>());
                //Startup.TestRabbitMq(ServiceLocator.GetService<IServiceProxyFactory>());
                //Startup.TestForRoutePath(ServiceLocator.GetService<IServiceProxyProvider>());
                //StartRequest(300000);
                Console.ReadLine();
            }
        }

        private static void StartRequest(int connectionCount)
        {
            var sw = new Stopwatch();
            sw.Start();
            var userProxy = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IAccountService>("User");
            ServiceResolver.Current.Register("User", userProxy);
            var service = ServiceLocator.GetService<IServiceProxyFactory>();
            userProxy = ServiceResolver.Current.GetService<IAccountService>("User");
            sw.Stop();
            Console.WriteLine($"代理所花{sw.ElapsedMilliseconds}ms");
            ThreadPool.SetMinThreads(100, 100);
            Parallel.For(0, connectionCount / 6000, new ParallelOptions {MaxDegreeOfParallelism = 50}, async u =>
            {
                for (var i = 0; i < 6000; i++)
                    await Test(userProxy, connectionCount);
            });
        }

        public static async Task Test(IAccountService userProxy, int connectionCount)
        {
            var a = await userProxy.GetDictionary();
            IncreaseSuccessConnection(connectionCount);
        }

        private static void IncreaseSuccessConnection(int connectionCount)
        {
            Interlocked.Increment(ref _endedConnenctionCount);
            if (_endedConnenctionCount == 1)
            {
                begintime = DateTime.Now;
            }

            if (_endedConnenctionCount >= connectionCount)
            {
                Console.WriteLine($"结束时间{(DateTime.Now - begintime).TotalMilliseconds}");
            }
        }
    }
}