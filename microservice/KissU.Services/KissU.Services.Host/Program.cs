using System.Threading.Tasks;
using Autofac;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KissU.Service.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCPlatformFile("servicesettings.json", false, true);
                    builder.AddCacheFile("cachesettings.json", false, true);
                })
                .ConfigureLogging(logger => { logger.AddConfiguration(AppConfig.GetSection("Logging")); })
                .ConfigureServices(services => { })
                .UseServiceHostBuilder()
                .ConfigureContainer(builder =>
                {
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                    builder.AddMicroService(option =>
                    {
                        option.AddServiceRuntime()
                            .AddRelateService()
                            .AddConfigurationWatch()
                            .AddServiceEngine(typeof(ServiceEngine));
                    });
                })
                .Configure(ServiceLocator.Register)
                .UseServer(options => { });

    }
}