using System.Threading.Tasks;
using KissU.CPlatform;
using KissU.ServiceProxy;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KissU.ServiceClient
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
                .AddMicroService(builder => { builder.AddClient(); })
                .UseClient()
                .UseAutofac();
    }
}