using System.Threading.Tasks;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform.Configurations;
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
                .ConfigureAppConfiguration(builder => builder.AddCacheFile("cachesettings.json", false, true))
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<AppHostedService>();
                });
    }
}