using System;
using System.Threading.Tasks;
using Autofac;
using KissU.Dependency;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform.Configurations;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using KissU.Extensions;
using KissU.Surging.Caching;
using KissU.Surging.CPlatform;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.ConsoleClient.Host
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureLogging(configure => configure.ClearProviders())
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCPlatformFile("servicesettings.json", false, true);
                    builder.AddCacheFile("cachesettings.json", false, true);
                })
                .ConfigureContainer(builder =>
                {
                    builder.AddMicroService(service => { service.AddClient().AddCache(); });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ConsoleClientDemoHostedService>();
                })
                .UseClient();
    }
}