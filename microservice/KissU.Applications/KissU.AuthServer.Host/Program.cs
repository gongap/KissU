using Autofac;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.ServiceHosting;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.Hosting;

namespace KissU.AuthServer.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            ServiceHost.CreateDefaultBuilder(hostBuilder =>
                {
                    hostBuilder.ConfigureHostConfiguration(builder =>
                    {
                        builder.AddCPlatformFile("servicesettings.json", false, true);
                        builder.AddCacheFile("cachesettings.json", false, true);
                    });
                })
                .ConfigureContainer(containerBuilder =>
                {
                    containerBuilder.AddMicroService(option =>
                    {
                        option.AddServiceRuntime()
                            .AddRelateService()
                            .AddConfigurationWatch()
                            .AddServiceEngine(typeof(ServiceEngine));
                    });
                    containerBuilder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .Configure(ServiceLocator.Register)
                .UseServer(options => { });

    }
}