using System;
using Autofac;
using KissU.Abp.Autofac.DependencyInjection;
using KissU.Dependency;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KissU.Abp.Autofac.Extensions
{
    /// <summary>
    /// 系统扩展 - IHostBuilder
    /// </summary>
    public static partial class Extensions
    {
        public static IHostBuilder UseAutofac(this IHostBuilder hostBuilder)
        {
            var containerBuilder = new ContainerBuilder();

            return hostBuilder.ConfigureServices((_, services) =>
                {
                    services.AddObjectAccessor(containerBuilder);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder));
        }
    }
}
