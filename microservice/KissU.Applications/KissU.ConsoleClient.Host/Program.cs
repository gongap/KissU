using System;
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
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .CreateLogger();

            try
            {
                Log.Information("Starting ConsoleClient.");
                await CreateHostBuilder(args).RunConsoleAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ConsoleClient terminated unexpectedly!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
                }).UseSerilog();
    }
}
