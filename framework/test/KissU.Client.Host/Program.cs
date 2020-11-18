using System.Threading.Tasks;
using Autofac;
using KissU.Dependency;
using KissU.Caching.Configurations;
using KissU.CPlatform.Configurations;
using Microsoft.Extensions.Hosting;
using KissU.Extensions;
using KissU.Caching;
using KissU.CPlatform;
using KissU.ServiceProxy;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Client.Host
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCPlatformFile("servicesettings.json", false, true);
                    builder.AddCacheFile("cachesettings.json", false, true);
                })
                .ConfigureMicroServiceHost(builder =>
                {
                    builder.AddMicroService(service => { service.AddClient().AddCache(); });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<AppHostedService>();
                })
                .UseClient();
    }
}