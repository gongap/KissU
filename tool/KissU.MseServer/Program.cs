using KissU.CPlatform;
using KissU.ServiceProxy;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace KissU.MicroService
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
                .AddMicroService(builder =>
                {
                    builder.AddServiceRuntime()
                        .AddRelateService()
                        .AddConfigurationWatch()
                        .AddServiceEngine();
                })
                .UseServer()
                .UseAutofac()
                .UseWindowsService();
    }
}
