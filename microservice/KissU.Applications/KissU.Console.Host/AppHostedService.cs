using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Abp.Autofac;
using KissU.Abp.Autofac.Extensions.DependencyInjection;
using KissU.Core.Dependency;
using KissU.Surging.Caching;
using KissU.Surging.CPlatform;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace KissU.Console.Host
{
    public class AppHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<AppModule>(options =>
            {
                options.UseAutofac();
                var containerBuilder = options.Services.GetContainerBuilder();
                containerBuilder.AddMicroService(service => { service.AddClient().AddCache(); });
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
