using System.Threading.Tasks;
using KissU.Caching.Configurations;
using KissU.CPlatform;
using KissU.CPlatform.Configurations;
using KissU.Extensions;
using KissU.Helpers;
using KissU.Modularity;
using KissU.ServiceProxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp.Modularity.PlugIns;

namespace KissU.Services
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(configure => configure.ClearProviders())
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCPlatformFile("servicesettings.json", false, true);
                    builder.AddCacheFile("cachesettings.json", false, true);
                })
                .ConfigureContainer(builder =>
                {
                    builder.AddMicroService(option =>
                    {
                        option.AddServiceRuntime()
                            .AddRelateService()
                            .AddConfigurationWatch()
                            .AddServiceEngine();
                    });
                })
                .UseAbp()
                .UseServer()
                .UseAutofac();

    }
}