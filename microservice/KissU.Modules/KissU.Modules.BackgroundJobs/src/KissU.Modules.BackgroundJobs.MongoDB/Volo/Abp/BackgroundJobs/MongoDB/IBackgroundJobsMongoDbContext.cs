using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace KissU.Modules.BackgroundJobs.MongoDB
{
    [ConnectionStringName(BackgroundJobsDbProperties.ConnectionStringName)]
    public interface IBackgroundJobsMongoDbContext : IAbpMongoDbContext
    {
         IMongoCollection<BackgroundJobRecord> BackgroundJobs { get; }
    }
}
