using System.Threading;
using System.Threading.Tasks;
using KissU.Abp.Autofac;
using KissU.Modules.BookStore.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;

namespace KissU.Modules.BookStore.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<BookStoreDbMigratorModule>(options =>
            {
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
            }))
            {
                application.Initialize();

                await application
                    .ServiceProvider
                    .GetRequiredService<BookStoreDbMigrationService>()
                    .MigrateAsync();

                application.Shutdown();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
