using KissU.Modules.AuditLogging.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace KissU.Modules.AuditLogging.MongoDB
{
    [DependsOn(typeof(AbpAuditLoggingDomainModule))]
    [DependsOn(typeof(AbpMongoDbModule))]
    public class AbpAuditLoggingMongoDbModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<AuditLoggingMongoDbContext>(options =>
            {
                options.AddRepository<AuditLog, MongoAuditLogRepository>();
            });
        }
    }
}
