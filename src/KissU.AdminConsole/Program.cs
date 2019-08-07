using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Util.Logs;
using Util.Logs.Extensions;

namespace KissU.AdminConsole
{
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                ex.Log(Log.GetLog().Caption("应用程序启动失败"));
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var ip = config["ip"];
            var port = config["port"];
            var host = WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseStartup<Startup>();

            if (!string.IsNullOrWhiteSpace(ip) && !string.IsNullOrWhiteSpace(port)) host.UseUrls($"http://{ip}:{port}");

            return host;
        }
    }
}