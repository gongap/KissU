using KissU.AspNetCore.Internal;
using KissU.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.AspNetCore
{
    public static class AppInitializationContextExtensions
    {
        public static IApplicationBuilder GetApplicationBuilder(this AppInitializationContext context)
        {
            return context.ServiceProvider.GetRequiredService<IObjectAccessor<IApplicationBuilder>>().Value;
        }

        public static IWebHostEnvironment GetEnvironment(this AppInitializationContext context)
        {
            return context.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        }

        public static IConfiguration GetConfiguration(this AppInitializationContext context)
        {
            return context.ServiceProvider.GetRequiredService<IConfiguration>();
        }

        public static ILoggerFactory GetLoggerFactory(this AppInitializationContext context)
        {
            return context.ServiceProvider.GetRequiredService<ILoggerFactory>();
        }
    }
}
