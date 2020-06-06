using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Abp.Autofac.Extensions;
using KissU.Dependency;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using KissU.Surging.Caching;
using KissU.Surging.CPlatform;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Console.Host
{
    public class Startup : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<AppModule>(options =>
            {
                options.UseAutofac(ServiceLocator.Register);
                var builder = options.Services.GetContainerBuilder();
                builder.AddMicroService(service => { service.AddClient().AddCache(); });
                builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
            }))
            {
                application.Initialize();
                var testService = application.ServiceProvider.GetService<TestService>();
                testService.Test(ServiceLocator.GetService<IServiceProxyFactory>());
                //testService.TestRabbitMq(ServiceLocator.GetService<IServiceProxyFactory>());
                //testService.TestForRoutePath(ServiceLocator.GetService<IServiceProxyProvider>());
                //testService.StartRequest(300000);
                application.Shutdown();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
