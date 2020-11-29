﻿using System.Threading.Tasks;
using KissU.Caching.Configurations;
using KissU.CPlatform.Configurations;
using Microsoft.Extensions.Hosting;
using KissU.Caching;
using KissU.CPlatform;
using KissU.ServiceProxy;
using Microsoft.Extensions.Logging;

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
                .AddMicroService(builder =>
                {
                    builder.AddClient().AddCache();
                })
                .AddAbp()
                .UseClient()
                .UseAbp
                .UseAutofac();
    }
}