using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using Microsoft.Extensions.Hosting;

namespace KissU.Client.Host
{
    public class AppHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var demoService = ServiceLocator.GetService<AppService>();
            await demoService.RunAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}