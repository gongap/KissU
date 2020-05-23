using System.IO;
using System.Threading.Tasks;
using Autofac;
using KissU.Abp.Autofac.Extensions.Hosting;
using KissU.Core.Dependency;
using KissU.Surging.Caching;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KissU.Console.Host
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => builder.AddCPlatformFile("servicesettings.json", false, true))
                //.ConfigureContainer<ContainerBuilder>(builder =>
                //{
                //    builder.AddMicroService(service => { service.AddClient().AddCache(); });
                //    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                //})
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<AppHostedService>();
                });
    }
}