using Autofac;
using KissU.Core.Dependency;
using KissU.Surging.Caching;
using KissU.Surging.CPlatform;
using KissU.Surging.ProxyGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Web.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AppModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddMicroService(service => { service.AddClient().AddCache(); });
        }
    }
}
