using System.Threading.Tasks;
using Autofac;
using KissU.Caching.Configurations;
using KissU.CPlatform;
using KissU.CPlatform.Configurations;
using KissU.Dependency;
using KissU.Extensions;
using KissU.ServiceProxy;
using Microsoft.Extensions.Hosting;

namespace KissU.Services.Host
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
                .UseServiceHostBuilder(builder =>
                {
                    builder.AddMicroService(option =>
                    {
                        option.AddServiceRuntime()
                            .AddRelateService()
                            .AddConfigurationWatch()
                            .AddServiceEngine();
                    });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .UseServer();

    }
}