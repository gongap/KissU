using System;
using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using Microsoft.Extensions.Hosting;
using KissU.Surging.ProxyGenerator;

namespace KissU.Client.Host
{
    public class Startup : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var testService = ServiceLocator.GetService<TestService>();
            testService.Test(ServiceLocator.GetService<IServiceProxyFactory>());
            //testService.TestThriftInvoker(ServiceLocator.GetService<IServiceProxyFactory>());
            //testService.TestRabbitMq(ServiceLocator.GetService<IServiceProxyFactory>());
            //testService.TestForRoutePath(ServiceLocator.GetService<IServiceProxyProvider>());
            //testService.StartRequest(300000);
            Console.ReadLine();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
