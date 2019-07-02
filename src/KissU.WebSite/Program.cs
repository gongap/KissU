using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace KissU.WebSite
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            string ip = config["ip"];
            string port = config["port"];
            var host = WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseStartup<Startup>();

            if (!string.IsNullOrWhiteSpace(ip) && !string.IsNullOrWhiteSpace(port))
            {
                host.UseUrls($"http://{ip}:{port}");
            }

            return host;
        }
    }
}