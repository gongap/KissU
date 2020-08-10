using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using Microsoft.Extensions.Hosting;
using KissU.Extensions;

namespace KissU.ConsoleClient.Host
{
    public class ConsoleClientDemoHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var demoService = ServiceLocator.GetService<ClientDemoService>();
            await demoService.RunAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
