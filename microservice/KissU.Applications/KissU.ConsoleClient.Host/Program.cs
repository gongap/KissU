using System.Threading.Tasks;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace KissU.ConsoleClient.Host
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/logs.txt")
                .CreateLogger();

            Log.Information("Starting ConsoleClientDemo...");

            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCPlatformFile("servicesettings.json", false, true);
                    builder.AddCacheFile("cachesettings.json", false, true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ConsoleClientDemoHostedService>();
                });
    }
}
