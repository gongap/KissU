using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Abp.Autofac.Extensions;
using KissU.Dependency;
using KissU.Surging.Caching;
using KissU.Surging.CPlatform;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;

namespace KissU.ConsoleClient.Host
{
    public class ConsoleClientDemoHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<ConsoleClientDemoModule>(options =>
            {
                options.UseAutofac(builder => {
                    builder.AddMicroService(service => { service.AddClient().AddCache(); });
                    builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                }, ServiceLocator.Register);

                options.Services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddSerilog(dispose: true);
                });

            }))
            {
                application.Initialize();

                var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();
                await demo.RunAsync();

                application.Shutdown();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
