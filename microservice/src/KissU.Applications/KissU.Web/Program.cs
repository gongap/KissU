using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using KissU.Abp.Autofac;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform.Configurations;

namespace KissU.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => builder.AddCPlatformFile("servicesettings.json", false, true))
                .ConfigureAppConfiguration(builder => builder.AddCacheFile("cachesettings.json", false, true))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac();
    }
}