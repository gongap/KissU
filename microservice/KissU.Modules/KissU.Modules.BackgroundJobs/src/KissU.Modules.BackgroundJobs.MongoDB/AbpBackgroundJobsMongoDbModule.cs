using KissU.Modules.BackgroundJobs.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace KissU.Modules.BackgroundJobs.MongoDB
{
    [DependsOn(
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AbpBackgroundJobsMongoDbModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<BackgroundJobsMongoDbContext>(options =>
            {
                 options.AddRepository<BackgroundJobRecord, MongoBackgroundJobRepository>();
            });
        }
    }
}
