using System;
using System.IO;
using KissU.Util.Dependency;
using KissU.Util.Logs;
using KissU.Util.Logs.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace KissU.SecurityTokenService
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
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                ex.Log(Log.GetLog().Caption("应用程序启动失败"));
            }
        }

        /// <summary>
        /// 创建主机生成器
        /// </summary>
        /// <param name="args">入口点参数</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()
                        .UseStartup<Startup>();
                })
                .UseAutofac();
        }
    }
}