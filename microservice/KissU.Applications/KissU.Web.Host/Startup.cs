using KissU.Dependency;
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
            ServiceLocator.Register(app.ApplicationServices);
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProxyFactory = scope.ServiceProvider.GetRequiredService<IServiceProxyFactory>();
            new TestService().Test(serviceProxyFactory);
        }
    }
}
