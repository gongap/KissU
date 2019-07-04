using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Util.Logs;
using Util.Logs.Extensions;

namespace KissU.JobScheduler.Admin
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
                CreateWebHostBuilder(args)
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                ex.Log(Log.GetLog().Caption("应用程序启动失败"));
            }
        }

        /// <summary>
        /// 自定义IP和端口
        /// </summary>
        /// <param name="args">入口点参数</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            string ip = config["ip"];
            string port = config["port"];
            var host = WebHost.CreateDefaultBuilder(args);

            if (!string.IsNullOrWhiteSpace(ip) && !string.IsNullOrWhiteSpace(port))
            {
                host.UseUrls($"http://{ip}:{port}");
            }

            return host;
        }
    }
}