using System.Threading.Tasks;
using Autofac;
using KissU.Dependency;
using KissU.Caching.Configurations;
using KissU.CPlatform.Configurations;
using Microsoft.Extensions.Hosting;
using KissU.Extensions;
using KissU.Caching;
using KissU.CPlatform;
using KissU.Helpers;
using KissU.Modularity;
using KissU.ServiceProxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.Modularity.PlugIns;

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
                .ConfigureLogging(configure => configure.ClearProviders())
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCPlatformFile("servicesettings.json", false, true);
                    builder.AddCacheFile("cachesettings.json", false, true);
                })
                .ConfigureContainer(builder =>
                {
                    builder.AddMicroService(service => { service.AddClient().AddCache(); });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .UseAbp()
                .UseClient()
                .UseAutofac();
    }
}