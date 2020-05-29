using KissU.Modules.AuditLogging.Domain;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace KissU.Modules.AuditLogging.MongoDB
{
    [ConnectionStringName(AbpAuditLoggingDbProperties.ConnectionStringName)]
    public interface IAuditLoggingMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<AuditLog> AuditLogs { get; }
    }
}
