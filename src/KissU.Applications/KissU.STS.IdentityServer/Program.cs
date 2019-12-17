// <copyright file="Program.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace KissU.STS.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
