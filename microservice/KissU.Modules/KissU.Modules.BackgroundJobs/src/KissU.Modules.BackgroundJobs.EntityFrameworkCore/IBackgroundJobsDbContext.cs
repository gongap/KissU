using KissU.Modules.BackgroundJobs.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.BackgroundJobs.EntityFrameworkCore
{
    [ConnectionStringName(BackgroundJobsDbProperties.ConnectionStringName)]
    public interface IBackgroundJobsDbContext : IEfCoreDbContext
    {
        DbSet<BackgroundJobRecord> BackgroundJobs { get; }
    }
}