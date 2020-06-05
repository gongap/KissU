using Autofac;
using KissU.ServiceHosting;
using Microsoft.Extensions.Hosting;

namespace KissU.Extensions
{
    /// <summary>
    /// 系统扩展 - IHostBuilder
    /// </summary>
    public static partial class Extensions
    {
        public static IServiceHostBuilder UseServiceHostBuilder(this IHostBuilder hostBuilder)
        {
            return new ServiceHostBuilder(hostBuilder);
        }
    }
}