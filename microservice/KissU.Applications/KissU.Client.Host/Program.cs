using System.Threading.Tasks;
using Autofac;
using KissU.Dependency;
using KissU.ServiceHosting;
using KissU.Surging.Caching;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KissU.Client.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
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
                .ConfigureServices((hostContext, services) => { services.AddHostedService<Startup>(); });
    }
}