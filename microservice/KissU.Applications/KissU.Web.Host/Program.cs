using Autofac;
using KissU.Abp.Autofac.Extensions.Hosting;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using KissU.Surging.Caching;
using KissU.Surging.CPlatform;
using KissU.Surging.ProxyGenerator;
using Microsoft.AspNetCore.Builder;
using KissU.Core.Dependency;

namespace KissU.Web.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => builder.AddCPlatformFile("servicesettings.json", false, true))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.AddMicroService(service => { service.AddClient().AddCache(); });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                })
                .UseAutofac();
    }
}